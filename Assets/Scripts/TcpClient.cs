using System.Collections.Concurrent;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using UnityEngine;

public class TcpClientMngr : MonoBehaviour
{
    public static TcpClientMngr inst;
    void Awake()
    {
        inst = this;
    }
    void OnApplicationQuit()
    {
        EndConnection();
    }

    public ConcurrentQueue<string> queueMsg = new ConcurrentQueue<string>();

    TcpClient tcpClient;
    NetworkStream stream;

    public bool TryStartConnection(string ipServer, int port)
    {
        //클라이언트가 서버한테 연결 시도
        IPEndPoint address = new IPEndPoint(IPAddress.Parse(ipServer), port);
        tcpClient = new TcpClient();
        try { tcpClient.Connect(address); } catch { return false; }
        stream = tcpClient.GetStream();
        Thread thReceive = new Thread(Receive);
        thReceive.Start();
        Thread thCheckConnection = new Thread(CheckConnection);
        thCheckConnection.Start();

        return true;
    }
    public void EndConnection()
    {
        //클라이언트가 서버랑 통신 종료하겠다 말하는거
        stream.Close();
        tcpClient.Close();
        swReceive = true;
        Debug.Log("tcp 종료됨");
    }

    int lengthBuf;
    byte[] buffer = new byte[8192];
    bool swReceive = false;
    void Receive()
    {
        while (!swReceive)
        {
            if (stream.DataAvailable)
            {
                lengthBuf = stream.Read(buffer, 0, buffer.Length);
                byte[] data = new Byte[lengthBuf];
                Buffer.BlockCopy(buffer, 0, data, 0, lengthBuf);
                BindData(data);
            }
        }
    }

    byte[] dataBound = new byte[0];
    int lengthData = 0;
    void BindData(byte[] data)
    {
        //받은 데이터 정리
        byte[] dataPiece;
        if (lengthData == 0)
        {
            dataBound = new byte[0];
            lengthData = (int)BitConverter.ToUInt16(data, 0);

            dataPiece = new byte[data.Length - 2];
            Buffer.BlockCopy(data, 2, dataPiece, 0, dataPiece.Length);
        }
        else
        {
            dataPiece = data;
        }

        if (dataBound.Length + dataPiece.Length >= lengthData)
        {//
            byte[] result = new byte[lengthData];
            Buffer.BlockCopy(dataBound, 0, result, 0, dataBound.Length);
            Buffer.BlockCopy(dataPiece, 0, result, dataBound.Length, lengthData - dataBound.Length);
            queueMsg.Enqueue(Encoding.UTF8.GetString(result));

            if (dataBound.Length + dataPiece.Length > lengthData)
            {//초과했을 때
                byte[] dataNew = new byte[dataBound.Length + dataPiece.Length - lengthData];
                Buffer.BlockCopy(dataPiece, lengthData - dataBound.Length, dataNew, 0, dataNew.Length);
                lengthData = 0;
                BindData(dataNew);
            }
            else
            {
                lengthData = 0;
            }
        }
        else
        {
            byte[] dataBoundNew = new byte[dataBound.Length + dataPiece.Length];
            Buffer.BlockCopy(dataBound, 0, dataBoundNew, 0, dataBound.Length);
            Buffer.BlockCopy(dataPiece, 0, dataBoundNew, dataBound.Length, dataPiece.Length);
            dataBound = dataBoundNew;
        }
    }

    public void Send(string msg)
    {
        //클라이언트->서버로 데이터 보냄(리퀘스트)
        byte[] data = Encoding.UTF8.GetBytes(msg);
        byte[] lengthData = BitConverter.GetBytes(Convert.ToUInt16(data.Length));
        byte[] package = new byte[data.Length + 2];
        Buffer.BlockCopy(lengthData, 0, package, 0, 2);
        Buffer.BlockCopy(data, 0, package, 2, data.Length);
        stream.Write(package, 0, package.Length);
    }

    private void CheckConnection()
    {
        //서버랑 연결 안되어있으면 연결 끊어버림
        while (true)
        {
            Thread.Sleep(1000);
            if (tcpClient.Client.Poll(1, SelectMode.SelectRead))
            {
                Debug.Log("서버연결끊김.");
                EndConnection();
                break;
            }
        }
    }
}
