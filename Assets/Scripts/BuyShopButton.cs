using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyShopButton : MonoBehaviour
{

    public GameObject Money;
    public GameObject Stand;
    public UnityEngine.UI.Button Button;
    public Text shopPriceText;
    public GameObject Tilemap;
    public TextMeshProUGUI ShopLevelText;
    public TextMeshProUGUI SellingItemLevelText;

    private float _shopPrice;

    private void Start()
    {
        if (Stand.GetComponent<Stand>().shopBought == false)
        {
            Button.onClick.AddListener(TaskOnClick);
            _shopPrice = Stand.GetComponent<Stand>().ShopPrice;
            shopPriceText.text = "Buy Shop (" + _shopPrice + "$)";
            ShopLevelText.text = "Shop Level " + Environment.NewLine + Stand.GetComponent<Stand>().ShopTilemapLevel + " / " + Stand.GetComponent<Stand>().MaximumTilemapUpgradeLevel;
        }
        else
            gameObject.SetActive(false);
        
    }

    void Update()
    {
        if (Stand.GetComponent<Stand>().shopBought == false)
        {
            if (Money.GetComponent<Money>()._totalMoney >= _shopPrice)
            {
                Button.interactable = true;
            }
            else
                Button.interactable = false;
        }
    }

    void TaskOnClick()
    {
        Money.GetComponent<Money>()._totalMoney -= _shopPrice;
        Stand.GetComponent<Stand>().shopBought = true;
        Tilemap.GetComponent<UpgradeShopTilemap>().changeTilemap(Stand.GetComponent<Stand>().ShopTilemapLevel, Stand.GetComponent<Stand>().ShopTilemapLevel + 1);
        Stand.GetComponent<Stand>().ShopTilemapLevel++;
        Stand.GetComponent<Stand>().ShopSellingItemLevel++;
        SellingItemLevelText.text = Stand.GetComponent<Stand>().SellingItem + " Level " + Environment.NewLine + Stand.GetComponent<Stand>().ShopSellingItemLevel + " / " + Stand.GetComponent<Stand>().MaximumSellingItemUpgradeLevel;
        ShopLevelText.text = "Shop Level " + Environment.NewLine + Stand.GetComponent<Stand>().ShopTilemapLevel + " / " + Stand.GetComponent<Stand>().MaximumTilemapUpgradeLevel;
    }
}
