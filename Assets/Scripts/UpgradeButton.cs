﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

//Upgrade Selling Item Button
public class UpgradeButton : MonoBehaviour
{
    
    public UnityEngine.UI.Button Button;
    public GameObject Stand;
    public GameObject Money;
    public Text SellingItemLevelText;
    public Text UpgradeCostText;
    private float _SellingItemUpgradeCost;

    //Image
    public Image Image;
    public Sprite[] ImageSprites;


    void Start()
    {
        Button.onClick.AddListener(TaskOnClick);
        _SellingItemUpgradeCost = Stand.GetComponent<Stand>().SellingItemUpgradeCost;

        UpdateUpgradeCostText();

        SellingItemLevelText.text = Stand.GetComponent<Stand>().SellingItem + " Level: " + Stand.GetComponent<Stand>().ShopSellingItemLevel + " / " + Stand.GetComponent<Stand>().MaximumSellingItemUpgradeLevel;

        if(Stand.GetComponent<Stand>().ShopSellingItemLevel > 1 )
            Image.GetComponent<Image>().sprite = ImageSprites[Stand.GetComponent<Stand>().ShopSellingItemLevel - 1];
    }

    private void Update()
    {
        if (Money.GetComponent<Money>()._totalMoney >= _SellingItemUpgradeCost
            && Stand.GetComponent<Stand>().ShopSellingItemLevel < Stand.GetComponent<Stand>().MaximumSellingItemUpgradeLevel
            && Stand.GetComponent<Stand>().shopBought == true)
        {
            Button.interactable = true;
        }
        else
            Button.interactable = false;
    }

    void TaskOnClick()
    { 
        if (Money.GetComponent<Money>()._totalMoney >= _SellingItemUpgradeCost && Stand.GetComponent<Stand>().ShopSellingItemLevel < Stand.GetComponent<Stand>().MaximumSellingItemUpgradeLevel)
        {
            Money.GetComponent<Money>()._totalMoney -= _SellingItemUpgradeCost;
            Money.GetComponent<Money>().totalShopExpenses += Stand.GetComponent<Stand>().SellingItemUpgradeCost;
            Stand.GetComponent<Stand>().ShopSellingItemLevel++;
            Image.GetComponent<Image>().sprite = ImageSprites[Stand.GetComponent<Stand>().ShopSellingItemLevel - 1];
            Stand.GetComponent<Stand>().productPrice += 1;
            SellingItemLevelText.text = Stand.GetComponent<Stand>().SellingItem + " Level " + Stand.GetComponent<Stand>().ShopSellingItemLevel + " / " + Stand.GetComponent<Stand>().MaximumSellingItemUpgradeLevel;
            _SellingItemUpgradeCost += Stand.GetComponent<Stand>().SellingItemUpgradeCost;
            Stand.GetComponent<Stand>().SellingItemUpgradeCost += Stand.GetComponent<Stand>().SellingItemUpgradeCost;
            UpdateUpgradeCostText();
        }
        else
            Debug.Log("Not Enough Money");
    }

    void UpdateUpgradeCostText()
    {
        if (Stand.GetComponent<Stand>().ShopSellingItemLevel < Stand.GetComponent<Stand>().MaximumSellingItemUpgradeLevel)
            UpgradeCostText.text = "Upgrade " + Stand.GetComponent<Stand>().SellingItem + " (" + NormaliseMoneyText(_SellingItemUpgradeCost) + " $)";
        else
            UpgradeCostText.text = Stand.GetComponent<Stand>().SellingItem +" is at Max Level";
    }

    private string NormaliseMoneyText(float amount)
    {
        if (amount < 1000)
            return amount.ToString();
        else
        {
            return ((int)amount / 1000).ToString() + "." + ((int)(amount % 1000) / 100).ToString() + "K";
        }
    }

}


