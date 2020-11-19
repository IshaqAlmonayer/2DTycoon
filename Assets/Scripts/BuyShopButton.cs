using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyShopButton : MonoBehaviour
{

    public GameObject Money;
    public GameObject Stand;
    public UnityEngine.UI.Button Button;
    public Text shopPriceText;

    private float _shopPrice;

    private void Start()
    {
        Button.onClick.AddListener(TaskOnClick);
        _shopPrice = Stand.GetComponent<Stand>().ShopPrice;
        shopPriceText.text = "Buy Shop (" + _shopPrice + "$)";
    }

    void Update()
    {
        if (Money.GetComponent<Money>()._totalMoney >= _shopPrice)
        {
            Button.interactable = true;
        }
        else
            Button.interactable = false;
    }

    void TaskOnClick()
    {
        Money.GetComponent<Money>()._totalMoney -= _shopPrice;
        Stand.GetComponent<Stand>().shopBought = true;
    }
}
