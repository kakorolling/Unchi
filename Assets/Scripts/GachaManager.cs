using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class GachaManager : MonoBehaviour
{
    //1연만 돌리면 아무거나 나와도 됨
    //10연 돌리면 SR 1장 이상은 반드시 나와야 함
    List<string> listSsr = new List<string> { "SSR1", "SSR2", "SSR3" };
    List<string> listSr = new List<string> { "SR1", "SR2", "SR3", "SR4", "SR5", "SR6", "SR7", "SR8", "SR9", "SR10" };
    List<string> listR = new List<string> { "R1", "R2", "R3", "R4", "R5", "R6", "R7", "R8", "R9", "R10", "R11", "R12", "R13", "R14", "R15", "R16", "R17", "R18", "R19", "R20" };
    //리스트 만들기

    public Button btnOne;
    public Button btnTen;
    private System.Random random = new();

    string gachaList(int gachaIdx)
    {
        if (gachaIdx < 3)
        {
            int resultIdx = random.Next(listSsr.Count);
            string resultCard = listSsr[resultIdx];
            return resultCard;
        }
        else if (gachaIdx < 13)
        {
            int resultIdx = random.Next(listSr.Count);
            string resultCard = listSr[resultIdx];
            return resultCard;
        }
        else
        {
            int resultIdx = random.Next(listR.Count);
            string resultCard = listR[resultIdx];
            return resultCard;
        }
    }
    public void gacha1()
    {
        int gacha1Idx = random.Next(100);
        string gacha1result = gachaList(gacha1Idx);
        Debug.Log(gacha1result);
    }
    public void gacha10()
    {
        int[] gacha10Arr = new int[10];
        string[] gacha10result = new string[10];
        for (int i = 0; i < 10; i++)
        {
            gacha10Arr[i] = random.Next(100);
        }
        for (int i = 0; i < 10; i++)
        {
            gacha10result[i] = gachaList(gacha10Arr[i]);
        }
        string resultIdx = "";
        string resultTxt = "";
        foreach (var num in gacha10Arr)
        {
            resultIdx += num + " ";
        }
        foreach (var txt in gacha10result)
        {
            resultTxt += txt + " ";
        }
        Debug.Log(resultTxt);

    }

}
