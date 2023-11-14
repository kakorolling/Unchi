using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Text.Json;
using Newtonsoft.Json;


public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public static GameManager instance { get => _instance; }

    // IEnumerator CheckMsgQueue()
    // {
    //     while (true)
    //     {
    //         if (TcpClientMngr.inst.queueMsg.IsEmpty)
    //         {
    //             yield return null;
    //             continue;
    //         }
    //         TcpClientMngr.inst.queueMsg.TryDequeue(out string msg);
    //         Queue<string> dataQueue = new Queue<string>(msg.Split('/'));
    //         switch (dataQueue.Dequeue())
    //         {
    //             case "SignIn":// SignIn/succeed/name/serializedInventory, SignIn/failed
    //                 if (dataQueue.Dequeue() == "succeed")
    //                 {
    //                     Debug.Log("로그인 성공");
    //                     //로그인 성공 이후 계정의 데이터를 받아와야한다. 이후 씬로드
    //                     SetAccount(dataQueue);
    //                     LoadingManager.LoadScene("RoomScene");
    //                 }
    //                 else
    //                 {
    //                     StartManager.instance.AlertMsg("로그인 실패했습니다. 다시 확인해주세요.");
    //                 }
    //                 break;
    //             case "SignOut":
    //                 if (dataQueue.Dequeue() == "succeed")
    //                 {

    //                     StartManager.instance.AlertMsg("로그아웃 성공했습니다.");
    //                 }
    //                 else
    //                 {
    //                     StartManager.instance.AlertMsg("로그아웃 실패했습니다.");
    //                 }
    //                 break;
    //             case "SignUp":
    //                 if (dataQueue.Dequeue() == "succeed")
    //                 {
    //                     StartManager.instance.AlertMsg("회원가입 성공했습니다.");
    //                 }
    //                 else
    //                 {
    //                     StartManager.instance.AlertMsg("회원가입 실패했습니다. 다시 확인해주세요.");
    //                 }
    //                 break;
    //         }
    //     }

    //     string name;
    //     List<Item> inventory;
    //     void SetAccount(Queue<string> dataQueue)
    //     {
    //         name = dataQueue.Dequeue();
    //         inventory = new List<Item>();
    //         while (dataQueue.TryDequeue(out string itemData))
    //         {
    //             inventory.Add(JsonConvert.DeserializeObject(itemData) as Item);
    //         }

    //     }
    // }

    void Awake()
    {
        Init();
        if (_instance != null) Destroy(gameObject);
        _instance = this;
        DontDestroyOnLoad(gameObject); //씬이 전환되더라도 파괴되지 않음
    }

    // public List<string> userDataString = new List<string>();
    // public List<int> userDataInt = new List<int>();

    // public int playerGold;
    // public int playerHeart;
    // public int playerJewel;
    // public int playerLevel;

    // //하트 충전
    // public int heartAmount = 0; //보유 하트 개수
    // private const int MAX_HEART = 10; //하트는 최대 10개까지
    // private DateTime appQuitTime = new DateTime(1970, 1, 1).ToLocalTime();
    // public int heartRechargeInterval = 900; //하트 개당 충전 시간은 15분(900초)
    // private Coroutine heartRechargeCoroutine = null;
    // private int rechargeRemainTime = 0;

    // public TMP_Text level;
    // public TMP_Text heart;
    // public TMP_Text jewel;

    // void Awake()
    // {
    //     Init();
    //     if (_instance != null) Destroy(gameObject);
    //     _instance = this;
    //     DontDestroyOnLoad(gameObject); //씬이 전환되더라도 파괴되지 않음
    // }

    // public void OnApplicationFocus(bool value)
    // {
    //     Debug.Log("OnApplicationFocus(): " + value);
    //     if (value)
    //     {
    //         LoadHeartInfo();
    //         LoadAppQuitTime();
    //         SetRechartgeScheduler();
    //     }
    //     else
    //     {
    //         SaveHeartInfo();
    //         SaveAppQuitTime();
    //     }
    // }

    // public void OnApplicationQuit() // 게임 종료 시 실행되는 함수
    // {
    //     Debug.Log("GoodsRechargeTester: OnApplicationQuit()");
    //     SaveHeartInfo();
    //     SaveAppQuitTime();
    // }

    // public void OnClickUseHeart()
    // {
    //     //버튼 이벤트에 이 함수를 연동한다.
    //     Debug.Log("OnClickUseHeart");
    //     UseHeart();
    // }

    // public void Init() //게임 초기화, 중간 이탈, 중간 복귀 시 실행되는함수
    // {

    //     heartAmount = 0;
    //     rechargeRemainTime = 0;
    //     appQuitTime = new DateTime(1970, 1, 1).ToLocalTime();
    //     Debug.Log("heartRechargeTimer : " + rechargeRemainTime + "s");
    // }

    // public bool LoadHeartInfo()
    // {
    //     bool result = false;
    //     try
    //     {
    //         if (PlayerPrefs.HasKey("HeartAmount"))
    //         {
    //             Debug.Log("PlayerPrefs has key : HeartAmount");
    //             if (heartAmount < 0)
    //             {
    //                 heartAmount = 0;
    //             }
    //         }
    //         else
    //         {
    //             heartAmount = MAX_HEART;
    //         }
    //         Debug.Log("Loaded HeartAmount: " + heartAmount);
    //         result = true;
    //     }
    //     catch (System.Exception e)
    //     {
    //         Debug.LogError("LeadHeartInfo Failed (" + e.Message + ")");
    //     }
    //     return result;
    // }

    // public bool SaveHeartInfo()
    // {
    //     Debug.Log("SaveHeartInfo");
    //     bool result = false;
    //     try
    //     {
    //         PlayerPrefs.SetInt("HeartAmount", heartAmount);
    //         PlayerPrefs.Save();
    //         Debug.Log("Saved HeartAmount : " + heartAmount);
    //         result = true;
    //     }
    //     catch (System.Exception e)
    //     {
    //         Debug.LogError("SaveHeartInfo Failed (" + e.Message + ")");
    //     }
    //     return result;
    // }

    // public bool LoadAppQuitTime()
    // {
    //     Debug.Log("LoadAppQuitTime");
    //     bool result = false;
    //     try
    //     {
    //         if (PlayerPrefs.HasKey("AppQuitTime"))
    //         {
    //             Debug.Log("PlayerPrefs has key : AppQuitTime");
    //             var playerappQuitTime = string.Empty;
    //             playerappQuitTime = PlayerPrefs.GetString("AppQuitTime");
    //             appQuitTime = DateTime.FromBinary(Convert.ToInt64(appQuitTime));
    //         }
    //         Debug.Log(string.Format("Loaded AppQuitTime : {0}", appQuitTime.ToString()));
    //         result = true;
    //     }
    //     catch (System.Exception e)
    //     {
    //         Debug.LogError("LoadAppQuitTime Failed (" + e.Message + ")");
    //     }
    //     return result;
    // }
    // public bool SaveAppQuitTime()
    // {
    //     Debug.Log("SaveAppQuitTime");
    //     bool result = false;
    //     try
    //     {
    //         var playerappQuitTime = DateTime.Now.ToLocalTime().ToBinary().ToString();
    //         PlayerPrefs.SetString("AppQuitTime", playerappQuitTime);
    //         PlayerPrefs.Save();
    //         Debug.Log("Saved AppQuitTime : " + DateTime.Now.ToLocalTime().ToString());
    //         result = true;
    //     }
    //     catch (System.Exception e)
    //     {
    //         Debug.LogError("SaveAppQuitTime Failed (" + e.Message + ")");
    //     }
    //     return result;
    // }
    // public void SetRechartgeScheduler(Action onFinish = null)
    // //다시 한번 확인 요망
    // {

    //     if (heartRechargeCoroutine != null)
    //     {
    //         StopCoroutine(heartRechargeCoroutine);
    //     }
    //     var timeDifferenceInSec = (int)((DateTime.Now.ToLocalTime() - appQuitTime).TotalSeconds);
    //     Debug.Log("TimeDifference In Sec :" + timeDifferenceInSec + "s");
    //     var heartToAdd = timeDifferenceInSec / heartRechargeInterval;
    //     Debug.Log("Heart to add : " + heartToAdd);
    //     var remainTime = timeDifferenceInSec % heartRechargeInterval;
    //     Debug.Log("RemainTime : " + remainTime);
    //     heartAmount += heartToAdd;
    //     if (heartAmount >= MAX_HEART)
    //     {
    //         heartAmount = MAX_HEART;
    //     }
    //     else
    //     {
    //         heartRechargeCoroutine = StartCoroutine(DoRechargeTimer(remainTime, onFinish));
    //     }
    //     Debug.Log("HeartAmount : " + heartAmount);
    // }

    // public void UseHeart(Action onFinish = null)
    // {
    //     if (heartAmount <= 0)
    //     {
    //         return;
    //     }
    //     heartAmount--;
    //     //DataManager.instan

    //     if (heartRechargeCoroutine == null)
    //     {
    //         heartRechargeCoroutine = StartCoroutine(DoRechargeTimer(heartRechargeInterval));
    //     }
    //     if (onFinish != null)
    //     {
    //         onFinish();
    //     }
    // }

    // private IEnumerator DoRechargeTimer(int remainTime, Action onFinish = null)
    // {
    //     Debug.Log("DoRechargeTimer");
    //     if (rechargeRemainTime <= 0)
    //     {
    //         rechargeRemainTime = heartRechargeInterval;
    //     }
    //     else
    //     {
    //         rechargeRemainTime = remainTime;
    //     }
    //     Debug.Log("heartRechargeTimer : " + rechargeRemainTime + "s");

    //     while (rechargeRemainTime > 0)
    //     {
    //         Debug.Log("heartRechargeTimer : " + rechargeRemainTime + "s");
    //         //heartRechargeTimer.text = string.Format("Timer : {0} s", m_RechargeRemainTime);
    //         rechargeRemainTime -= 1;
    //         yield return new WaitForSeconds(1f);
    //     }
    //     heartAmount++;
    //     if (heartAmount >= MAX_HEART)
    //     {
    //         heartAmount = MAX_HEART;
    //         rechargeRemainTime = 0;
    //         //heartRechargeTimer.text = string.Format("Timer : {0} s", m_RechargeRemainTime);
    //         Debug.Log("HeartAmount reached max amount");
    //         heartRechargeCoroutine = null;
    //     }
    //     else
    //     {
    //         heartRechargeCoroutine = StartCoroutine(DoRechargeTimer(heartRechargeInterval, onFinish));
    //     }
    //     //heartAmountLabel.text = string.Format("Hearts : {0}", m_HeartAmount.ToString());
    //     Debug.Log("HeartAmount : " + heartAmount);
    // }


    // public void userState() //UI에 보여줄거
    // {
    //     level.text = "13";
    //     heart.text = heartAmount + "/10";
    //     jewel.text = "1500";
    // }
    // void Start()
    // {

    // }


    // void Update()
    // {
    //     userState();

    // }
}

// class Account
// {
//     string name;
//     List<Item> inventory;

// }
public class Item
{

}


