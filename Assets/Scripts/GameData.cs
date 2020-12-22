using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    //Money
    public float totalMoney;
    public float totalShopExpenses;
    public float totalAddExpenses;
    public float totalRevenuePerMinute;

    //Stands
    public int[] shopSellingItemLevel;
    public int[] shopTilemapLevel;
    public bool[] shopBought;
    public float[] sellingItmeUpgradeCost;
    public float[] ShopUpgradeCost;
    public float[] StandWaitingTime;
    public float[] productPrice;
    public float[] TotalStandRevenue;
    
    //Ads
    public bool[] SpawnerActive;
    public float AddTimer;

    //Audio
    public bool MusicStatus;

    public GameData(Money money, AdvertiseController adController)
    {
        GameObject[] Stands;
        GameObject[] CustomerSpawners;

        Stands = GameObject.FindGameObjectsWithTag("Stand");
        Array.Sort(Stands, CompareObNames);
        CustomerSpawners = GameObject.FindGameObjectsWithTag("CustomerSpawner");
        

        //Stand
        shopSellingItemLevel = new int[Stands.Length];
        shopTilemapLevel = new int[Stands.Length];
        shopBought = new bool[Stands.Length];
        sellingItmeUpgradeCost = new float[Stands.Length];
        ShopUpgradeCost = new float[Stands.Length];
        StandWaitingTime = new float[Stands.Length];
        productPrice = new float[Stands.Length];
        TotalStandRevenue = new float[Stands.Length];

        for (int i = 0;i< Stands.Length; i++)
        {
            shopSellingItemLevel[i] = Stands[i].GetComponent<Stand>().ShopSellingItemLevel;
            shopTilemapLevel[i] = Stands[i].GetComponent<Stand>().ShopTilemapLevel;
            shopBought[i] = Stands[i].GetComponent<Stand>().shopBought;
            sellingItmeUpgradeCost[i] = Stands[i].GetComponent<Stand>().SellingItemUpgradeCost;
            ShopUpgradeCost[i] = Stands[i].GetComponent<Stand>().ShopUpgradeCost;
            StandWaitingTime[i] = Stands[i].GetComponent<Stand>().StandWaitingTime;
            productPrice[i] = Stands[i].GetComponent<Stand>().productPrice;
            TotalStandRevenue[i] = Stands[i].GetComponent<Stand>().TotalStandRevenue;
        }

        //money
        totalMoney = money._totalMoney;
        totalShopExpenses = money.totalShopExpenses;
        totalAddExpenses = money.totalAddExpenses;
        totalRevenuePerMinute = money.totalRevenuePerMinute;

        //Ads
        SpawnerActive = new bool[CustomerSpawners.Length];
        
        for (int i = 0; i < CustomerSpawners.Length; i++)
        {
            SpawnerActive[i] = CustomerSpawners[i].GetComponent<CustomerSpawner>().isActive;
        }
        
        AddTimer = adController.AddTimer;

        //Audio
        GameObject AudioController = GameObject.Find("AudioController");
        MusicStatus = AudioController.GetComponent<AudioOnOff>().musicStatus;
    }

    int CompareObNames(GameObject x, GameObject y)
    {
        return x.name.CompareTo(y.name);
    }
}
