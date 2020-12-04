using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeShopButton : MonoBehaviour
{

    public Stand Stand;
    public Money Money;
    public Button Button;
    public Text ShopLevelText;
    public Text ShopUpgradePriceText;
    public GameObject Tilemap;

    // Start is called before the first frame update
    void Start()
    {
        Button.onClick.AddListener(TaskOnClick);
        if (Stand.GetComponent<Stand>().shopBought == true)
        {
            setDefaults();
        }
        else
            gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Stand.GetComponent<Stand>().shopBought == true)
        {
            if (Money.GetComponent<Money>()._totalMoney >= Stand.GetComponent<Stand>().ShopUpgradeCost
                && Stand.GetComponent<Stand>().ShopTilemapLevel < Stand.GetComponent<Stand>().MaximumTilemapUpgradeLevel)
            {
                Button.interactable = true;
                setDefaults();
            }
            else
            {
                Button.interactable = false;
                setDefaults();
            }
        }
    }

    void TaskOnClick()
    {
        
        if (Money.GetComponent<Money>()._totalMoney >= Stand.GetComponent<Stand>().ShopUpgradeCost && Stand.GetComponent<Stand>().ShopTilemapLevel < Stand.GetComponent<Stand>().MaximumTilemapUpgradeLevel)
        {
            Money._totalMoney -= Stand.GetComponent<Stand>().ShopUpgradeCost;
            Money.totalShopExpenses += Stand.GetComponent<Stand>().ShopUpgradeCost;
            Tilemap.GetComponent<UpgradeShopTilemap>().changeTilemap(Stand.GetComponent<Stand>().ShopTilemapLevel, Stand.GetComponent<Stand>().ShopTilemapLevel + 1);
            Stand.GetComponent<Stand>().ShopTilemapLevel++;
            Stand.GetComponent<Stand>().ShopUpgradeCost += Stand.GetComponent<Stand>().ShopUpgradeCost;
            if(Stand.GetComponent<Stand>().StandWaitingTime > 1 )
                Stand.GetComponent<Stand>().StandWaitingTime -= 1;
            Stand.GetComponent<Stand>().productPrice += 1;
            ShopLevelText.text = "Shop Level: " + Stand.GetComponent<Stand>().ShopTilemapLevel + " / " + Stand.GetComponent<Stand>().MaximumTilemapUpgradeLevel;
            ShopUpgradePriceText.text = "Upgrade Shop (" + Stand.GetComponent<Stand>().ShopUpgradeCost + "$)";
        }
    }

    public void setDefaults()
    {
        if (Stand.GetComponent<Stand>().ShopTilemapLevel < Stand.GetComponent<Stand>().MaximumTilemapUpgradeLevel)
        {
            ShopUpgradePriceText.text = "Upgrade Shop (" + Stand.GetComponent<Stand>().ShopUpgradeCost + "$)";
        } else
            ShopUpgradePriceText.text = "Shop at Max Level";

        ShopLevelText.text = "Shop Level: " + Stand.GetComponent<Stand>().ShopTilemapLevel + " / " + Stand.GetComponent<Stand>().MaximumTilemapUpgradeLevel;
    }
}
