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
    public TextMeshProUGUI LevelText;

    private float _shopPrice;

    private void Start()
    {
        if (Stand.GetComponent<Stand>().shopBought == false)
        {
            Button.onClick.AddListener(TaskOnClick);
            _shopPrice = Stand.GetComponent<Stand>().ShopPrice;
            shopPriceText.text = "Buy Shop (" + _shopPrice + "$)";
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
        Tilemap.GetComponent<UpgradeShopTilemap>().changeTilemap(Stand.GetComponent<Stand>().ShopLevel, Stand.GetComponent<Stand>().ShopLevel + 1);
        Stand.GetComponent<Stand>().ShopLevel++;
        LevelText.text = "Shop Level: " + Stand.GetComponent<Stand>().ShopLevel + " / " + Stand.GetComponent<Stand>().MaximumUpgradeLevel;
    }
}
