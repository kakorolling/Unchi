using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    private static StartManager _instance;
    public static StartManager instance
    {
        get
        {
            if (_instance == null) _instance = new StartManager();
            return _instance;
        }
    }

    //시작화면에 보이는거
    public GameObject startBtn;
    public GameObject settingBtn;

    //로그인하기 위한 
    public GameObject accountMenu;

    //회원가입을 위한
    public GameObject signupMenu;

    //설정 메뉴
    public GameObject CloseMenuBtn;
    public GameObject blackpanel;
    public GameObject settingMenu;
    public GameObject LoginMenu;

    //사운드
    AudioSource btnSound;


    //이메일, 비밀번호
    public TMP_InputField loginEmailInput;
    public TMP_InputField loginPasswordInput;
    public TMP_InputField signupEmailInput;
    public TMP_InputField signupPasswordInput;

    void Start()
    {
        //처음에는 startBtn이랑 settingBtn안보임
        blackpanel.SetActive(false);
        settingMenu.SetActive(false);
        startBtn.SetActive(false);
        settingBtn.SetActive(false);
        LoginMenu.SetActive(false);
        accountMenu.SetActive(false);
        Invoke("ShowBtns", 1.0f);     //5초 뒤 버튼이 나와야함
        btnSound = GetComponent<AudioSource>();
        DontDestroyOnLoad(btnSound);
    }

    //1초 뒤 버튼 나옴
    void ShowBtns()
    {
        startBtn.SetActive(true);
        settingBtn.SetActive(true);
    }

    //처음 로그인 창
    public void ShowLoginPage()
    {
        accountMenu.SetActive(true);
        blackpanel.SetActive(true);
        startBtn.SetActive(false);
        settingBtn.SetActive(false);
    }

    public void CancelLogin()
    {
        accountMenu.SetActive(false);
        blackpanel.SetActive(false);
        startBtn.SetActive(true);
        settingBtn.SetActive(true);
    }

    public void LoginAuthAccount()
    {
        Debug.Log(loginEmailInput.text);
        Debug.Log(loginPasswordInput.text);
        AuthManager.instance.Login(loginEmailInput.text, loginPasswordInput.text);
    }

    //회원가입 창
    public void ShowSignupPage()
    {
        accountMenu.SetActive(false);
        LoginMenu.SetActive(true);
    }

    public void CancelSignup()
    {
        LoginMenu.SetActive(false);
        blackpanel.SetActive(false);
        startBtn.SetActive(true);
        settingBtn.SetActive(true);
    }

    public void CreateAccount()
    {

        AuthManager.instance.CreateAccount(signupEmailInput.text, signupPasswordInput.text);
    }

    //세팅 메뉴 보이면
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

    //세팅 메뉴
    public void ShowCopyrightSite()
    {
        Application.OpenURL("https://kakorolling.github.io/UnchiWebsite/Copyright.html");
    }

    public void ShowFAQSite()
    {
        Application.OpenURL("https://kakorolling.github.io/UnchiWebsite/FAQ.html");
    }

    public void Logout()
    {
        AuthManager.instance.LogOut();
    }

    //게임 시작버튼
    public void PressStartGame()
    {
        btnSound.Play();

        if (!AuthManager.instance.CheckLogin())
        {
            ShowLoginPage();
        }
        else
        {
            LoadingManager.LoadScene("RoomScene");
        }
    }

}
