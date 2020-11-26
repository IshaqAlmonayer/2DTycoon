using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public float totalMonay;
    public int[] shopSellingItemLevel;
    public int[] shopTilemapLevel;
    public bool[] shopBought;
    public float[] sellingItmeUpgradeCost;
    public float[] ShopUpgradeCost;

    public GameData(Money money)
    {
        GameObject[] Stands;

        Stands = GameObject.FindGameObjectsWithTag("Stand");

        shopSellingItemLevel = new int[Stands.Length];
        shopTilemapLevel = new int[Stands.Length];
        shopBought = new bool[Stands.Length];
        sellingItmeUpgradeCost = new float[Stands.Length];
        ShopUpgradeCost = new float[Stands.Length];

        for (int i = 0;i< Stands.Length; i++)
        {
            shopSellingItemLevel[i] = Stands[i].GetComponent<Stand>().ShopSellingItemLevel;
            shopTilemapLevel[i] = Stands[i].GetComponent<Stand>().ShopTilemapLevel;
            shopBought[i] = Stands[i].GetComponent<Stand>().shopBought;
            sellingItmeUpgradeCost[i] = Stands[i].GetComponent<Stand>().SellingItemUpgradeCost;
            ShopUpgradeCost[i] = Stands[i].GetComponent<Stand>().ShopUpgradeCost;
        }

        totalMonay = money._totalMoney;
    }
}
