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
    private float _upgradeCost;

    void Start()
    {
        Button.onClick.AddListener(TaskOnClick);
        _upgradeCost = Stand.GetComponent<Stand>().UpgradeCost;
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
            Stand.GetComponent<Stand>().ShopLevel++;
            LevelText.text = "Shop Level: " + Stand.GetComponent<Stand>().ShopLevel;
            _upgradeCost += Stand.GetComponent<Stand>().UpgradeCost;
            
            if(Stand.GetComponent<Stand>().ShopLevel < Stand.GetComponent<Stand>().MaximumUpgradeLevel)
                UpgradeCostText.text = "Upgrade Shop (" + _upgradeCost + "$)";
            else
                UpgradeCostText.text = "Shop At Max Level";
            
            Money.GetComponent<Money>()._totalMoney -= 10;
        }
        else
            Debug.Log("Not Enough Money");
    }

}


