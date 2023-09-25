using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject openMenuBtn;
    public GameObject closeMenuBtn;
    public GameObject menuPanelObj;


    public void OpenMenu()
    {
        menuPanelObj.SetActive(true);
        openMenuBtn.SetActive(false);
        closeMenuBtn.SetActive(true);
    }

    public void CloseMenu()
    {
        menuPanelObj.SetActive(false);
        openMenuBtn.SetActive(true);
        closeMenuBtn.SetActive(false);
    }
}
