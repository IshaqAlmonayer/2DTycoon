using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public float totalMonay;
    public int[] shopLevel;
    public bool[] shopBought;
    public float[] shopUpgradeCost;

    public GameData(Money money)
    {
        GameObject[] Stands;

        Stands = GameObject.FindGameObjectsWithTag("Stand");
        
        shopLevel = new int[Stands.Length];
        shopBought = new bool[Stands.Length];
        shopUpgradeCost = new float[Stands.Length];

        for (int i = 0;i< Stands.Length; i++)
        {
            shopLevel[i] = Stands[i].GetComponent<Stand>().ShopLevel;
            shopBought[i] = Stands[i].GetComponent<Stand>().shopBought;
            shopUpgradeCost[i] = Stands[i].GetComponent<Stand>().UpgradeCost;
        }

        totalMonay = money._totalMoney;
    }
}
