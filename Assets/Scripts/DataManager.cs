using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//Lv, 하트, 보석, 골드 갯수(중요한 정보들) -> 서버에서 처리하고 저장해야함
//클라이언트가 해야할건->서버에서 처리한 정보들을 보여주는 거 뿐?

[System.Serializable]
public class SaveData
{
    public List<string> userDataString = new List<string>();
    public List<int> userDataInt = new List<int>();

    public int playerGold;
    public int playerHeart;
    public int playerJewel;
    public int playerLevel;
}

public class DataManager : MonoBehaviour
{

    // string dataBasePath;

    // void Start()
    // {
    //     dataBasePath = Path.Combine(Application.persistentDataPath, "userData.json");
    //     JsonLoad();
    // }

    // public void JsonLoad()
    // {
    //     SaveData saveData = new SaveData();
    //     Debug.Log("loadData");

    //     if (!File.Exists(dataBasePath))
    //     {
    //         GameManager.instance.playerGold = 0;
    //         GameManager.instance.heartAmount = 10;
    //         JsonSave();
    //     }
    //     else
    //     {
    //         string loadJson = File.ReadAllText(dataBasePath);
    //         saveData = JsonUtility.FromJson<SaveData>(loadJson);

    //         if (saveData != null)
    //         {
    //             for (int i = 0; i < saveData.userDataString.Count; i++)
    //             {
    //                 GameManager.instance.userDataString.Add(saveData.userDataString[i]);
    //             }
    //             for (int i = 0; i < saveData.userDataInt.Count; i++)
    //             {
    //                 GameManager.instance.userDataInt.Add(saveData.userDataInt[i]);
    //             }

    //             GameManager.instance.playerGold = saveData.playerGold;
    //             GameManager.instance.playerHeart = saveData.playerHeart;
    //             GameManager.instance.playerJewel = saveData.playerHeart;
    //             GameManager.instance.playerLevel = saveData.playerHeart;

    //         }
    //     }
    // }
    // public void JsonSave()
    // {
    //     SaveData saveData = new SaveData();

    //     for (int i = 0; i < 10; i++)
    //     {
    //         saveData.userDataString.Add("테스트 데이터 no " + i);
    //     }
    //     for (int i = 0; i < 10; i++)
    //     {
    //         saveData.userDataInt.Add(i);
    //     }
    //     saveData.playerGold = GameManager.instance.playerGold;
    //     saveData.playerHeart = GameManager.instance.playerHeart;
    //     saveData.playerJewel = GameManager.instance.playerJewel;
    //     saveData.playerLevel = GameManager.instance.playerLevel;


    //     string json = JsonUtility.ToJson(saveData, true);

    //     File.WriteAllText(dataBasePath, json);
    // }
}
