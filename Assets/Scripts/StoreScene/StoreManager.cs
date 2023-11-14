using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public GameObject mainStore;
    public GameObject backBtn;

    public GameObject jewelShop;

    void Start()
    {
        mainStore.SetActive(true);
        jewelShop.SetActive(false);
        backBtn.SetActive(false);
    }

    public void GoBack()
    {
        mainStore.SetActive(true);
        jewelShop.SetActive(false);
        jewelShop.SetActive(false);
    }

    public void showJewelShop()
    {
        backBtn.SetActive(true);
        jewelShop.SetActive(true);
        mainStore.SetActive(false);
    }
}
