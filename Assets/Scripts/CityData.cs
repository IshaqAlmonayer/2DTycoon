using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


[System.Serializable]
public class CityData
{

    public float[] CitiesPrice;
    public bool[] UnlockedFlag;

    public CityData()
    {
        GameObject[] Cities;
        Cities = GameObject.FindGameObjectsWithTag("City");
        Array.Sort(Cities, CompareObNames);

        CitiesPrice = new float[Cities.Length];
        UnlockedFlag = new bool[Cities.Length];

        for (int i = 0; i < Cities.Length; i++)
        {
            CitiesPrice[i] = Cities[i].GetComponent<City>().price;
            UnlockedFlag[i] = Cities[i].GetComponent<City>().unlocked;
        }
        
    }

    int CompareObNames(GameObject x, GameObject y)
    {
        return x.name.CompareTo(y.name);
    }

}
