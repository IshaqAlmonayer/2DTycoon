﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{

    public int ShopSellingItemLevel;
    public int ShopTilemapLevel;
    public float SellingItemUpgradeCost;
    public float ShopUpgradeCost;
    public string SellingItem;
    public float ShopPrice;
    public float MaximumSellingItemUpgradeLevel;
    public float MaximumTilemapUpgradeLevel;
    public float productPrice;
    public bool shopBought = false;
    public string StandNumber;
    public float StandWaitingTime;
    public float TotalStandRevenue;
    public AudioClip CoinSound;

    private bool _trigger = false;
    

    private void Start()
    {

    }
 
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Customer") && shopBought)
        {
            _trigger = true;
            TotalStandRevenue += productPrice;
            AudioSource.PlayClipAtPoint(CoinSound, transform.position, 1);
        }
    }

    public float GetMoney()
    {
        if (_trigger == true)
        {
            _trigger = false;
            return productPrice;
        }
        else 
            return 0;
    }

}