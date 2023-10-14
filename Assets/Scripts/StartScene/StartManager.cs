using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{

    public GameObject startBtn;
    public GameObject settingBtn;
    public GameObject settingMenu;
    public GameObject blackpanel;
    public GameObject CloseMenuBtn;
    AudioSource btnSound;

    //5초 뒤 버튼이 나와야함
    void Start()
    {
        //처음에는 startBtn이랑 settingBtn안보임
        blackpanel.SetActive(false);
        settingMenu.SetActive(false);
        startBtn.SetActive(false);
        settingBtn.SetActive(false);
        Invoke("ShowBtns", 1.0f);
        btnSound = GetComponent<AudioSource>();
        DontDestroyOnLoad(btnSound);

    }

    void ShowBtns()
    {
        startBtn.SetActive(true);
        settingBtn.SetActive(true);
    }

    public void ShowSettingMenu()
    {
        startBtn.SetActive(false);
        settingBtn.SetActive(false);
        blackpanel.SetActive(true);
        settingMenu.SetActive(true);
        CloseMenuBtn.SetActive(true);
    }

    public void CloseSettingMenu()
    {
        startBtn.SetActive(true);
        settingBtn.SetActive(true);
        blackpanel.SetActive(false);
        settingMenu.SetActive(false);
        CloseMenuBtn.SetActive(false);
    }

    public void showCopyrightSite()
    {
        Application.OpenURL("https://kakorolling.github.io/UnchiWebsite/Copyright.html");
    }

    public void showFAQSite()
    {
        Application.OpenURL("https://kakorolling.github.io/UnchiWebsite/FAQ.html");
    }

    public void GoNextScene()
    {
        btnSound.Play();
        LoadingManager.LoadScene("RoomScene");
    }

}
