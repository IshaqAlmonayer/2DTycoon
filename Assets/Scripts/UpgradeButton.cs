using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class UpgradeButton : MonoBehaviour
{
    
    public UnityEngine.UI.Button Button;
    public GameObject Stand;
    public GameObject Money;
    public TextMeshProUGUI LevelText;
    public Text UpgradeCostText;
    public GameObject Tilemap;
    private float _upgradeCost;


    void Start()
    {
        Button.onClick.AddListener(TaskOnClick);
        _upgradeCost = Stand.GetComponent<Stand>().UpgradeCost;

        UpdateUpgradeCostText();

        if (Stand.GetComponent<Stand>().shopBought)
            LevelText.text = "Shop Level: " + Stand.GetComponent<Stand>().ShopLevel + " / " + Stand.GetComponent<Stand>().MaximumUpgradeLevel;
    }

    private void Update()
    {
        if (Money.GetComponent<Money>()._totalMoney >= _upgradeCost 
            && Stand.GetComponent<Stand>().ShopLevel < Stand.GetComponent<Stand>().MaximumUpgradeLevel
            && Stand.GetComponent<Stand>().shopBought == true)
        {
            Button.interactable = true;
        }
        else
            Button.interactable = false;
    }

    void TaskOnClick()
    { 
        if (Money.GetComponent<Money>()._totalMoney >= _upgradeCost && Stand.GetComponent<Stand>().ShopLevel < Stand.GetComponent<Stand>().MaximumUpgradeLevel)
        {
            Money.GetComponent<Money>()._totalMoney -= _upgradeCost;
            Tilemap.GetComponent<UpgradeShopTilemap>().changeTilemap(Stand.GetComponent<Stand>().ShopLevel, Stand.GetComponent<Stand>().ShopLevel + 1);
            Stand.GetComponent<Stand>().ShopLevel++;
            LevelText.text = "Shop Level: " + Stand.GetComponent<Stand>().ShopLevel + " / " + Stand.GetComponent<Stand>().MaximumUpgradeLevel;
            _upgradeCost += Stand.GetComponent<Stand>().UpgradeCost;
            Stand.GetComponent<Stand>().UpgradeCost += Stand.GetComponent<Stand>().UpgradeCost;
            UpdateUpgradeCostText();
        }
        else
            Debug.Log("Not Enough Money");
    }

    void UpdateUpgradeCostText()
    {
        if (Stand.GetComponent<Stand>().ShopLevel < Stand.GetComponent<Stand>().MaximumUpgradeLevel)
            UpgradeCostText.text = "Upgrade Shop (" + _upgradeCost + "$)";
        else
            UpgradeCostText.text = "Shop At Max Level";
    }

}


