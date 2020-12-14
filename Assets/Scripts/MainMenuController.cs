using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public int position;

    private void Start()
    {
        LoadCityData();
    }

    public void LoadCityData()
    {
        CityData cityData = SaveSystem.LoadCityData();
        GameObject[] Cities;

        Cities = GameObject.FindGameObjectsWithTag("City");
        Array.Sort(Cities, CompareObNames);

        for (int i = 0; i < Cities.Length; i++)
        {
            Cities[i].GetComponent<City>().price = cityData.CitiesPrice[i];
            Cities[i].GetComponent<City>().unlocked = cityData.UnlockedFlag[i];
        }
    }

    int CompareObNames(GameObject x, GameObject y)
    {
        return x.name.CompareTo(y.name);
    }

}
