using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavManager : MonoBehaviour
{
    //싱글톤
    private static NavManager _instance;
    public static NavManager instance
    {
        get
        {
            if (_instance == null) _instance = new NavManager();
            return _instance;
        }
    }

    public GameObject chargeHeartMenu;
    public GameObject chargeJewelMenu;
    public GameObject navBar;

    public GameObject menuBtn;
    public GameObject settingBtn;
    public GameObject closeBtn;

    public GameObject menuItem;


    public GameObject blackPanel;
    public GameObject SettingMenu;



    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3)
        {
            navBar.SetActive(true);
            menuBtn.SetActive(true);
        }
        else
        {
            navBar.SetActive(false);
            menuBtn.SetActive(false);
        }
        chargeHeartMenu.SetActive(false);
        chargeJewelMenu.SetActive(false);
        settingBtn.SetActive(false);
        closeBtn.SetActive(false);
        menuItem.SetActive(false);
        blackPanel.SetActive(false);
        SettingMenu.SetActive(false);
        //DontDestroyOnLoad(navBar);
    }

    public void ShowChargeHeartMenu()
    {
        chargeHeartMenu.SetActive(true);
        chargeJewelMenu.SetActive(false);
        CloseMenu();
        CancelJewelMenu();
    }

    public void CancelHeartMenu()
    {
        chargeHeartMenu.SetActive(false);
    }

    public void ShowChargeJewelMenu()
    {
        chargeJewelMenu.SetActive(true);
        chargeHeartMenu.SetActive(false);
        CloseMenu();
        CancelHeartMenu();
    }

    public void GoShopScene()
    {
        LoadingManager.LoadScene("StoreScene");
    }

    public void CancelJewelMenu()
    {
        chargeJewelMenu.SetActive(false);
    }

    public void ShowMenu()
    {
        menuBtn.SetActive(false);
        settingBtn.SetActive(true);
        closeBtn.SetActive(true);
        menuItem.SetActive(true);
        CancelHeartMenu();
        CancelJewelMenu();
    }

    public void GoMissionScene()
    {

    }
    public void GoCardScene()
    {

    }
    public void GoRoomScene()
    {

    }
    public void GoSearchScene()
    {

    }
    public void GoItemScene()
    {

    }


    public void CloseMenu()
    {
        menuBtn.SetActive(true);
        settingBtn.SetActive(false);
        closeBtn.SetActive(false);
        menuItem.SetActive(false);
    }


    public void ShowSettingMenu()
    {
        blackPanel.SetActive(true);
        SettingMenu.SetActive(true);
    }

    public void ShowProfile()
    {

    }

    public void ShowCopyrightSite()
    {
        Application.OpenURL("https://kakorolling.github.io/UnchiWebsite/Copyright.html");
    }

    public void ShowFAQSite()
    {
        Application.OpenURL("https://kakorolling.github.io/UnchiWebsite/FAQ.html");
    }

    public void ShowHomeSite()
    {
        Application.OpenURL("https://kakorolling.github.io/UnchiWebsite/Hompage.html");
    }

    public void CloseSettingMenu()
    {
        SettingMenu.SetActive(false);
        blackPanel.SetActive(false);
    }

}
