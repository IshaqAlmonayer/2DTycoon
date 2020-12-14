using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Money money;
    public AdvertiseController adController;
    public MenuController MenuController;
    public float _saveFrequency = 10;
    private float _autoSaveTimer = 0;
    public string map;

    private void Awake()
    {
        //load CityData
        LoadCityData();

        //load GameData
        LoadGameData();
    }

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Update()
    {
        _autoSaveTimer -= Time.deltaTime;
    
        if(_autoSaveTimer <= 0)
        {
            SaveSystem.SaveGame(map, money, adController);
            _autoSaveTimer = _saveFrequency;
        }

        //Backbutton Android
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SaveGame();
                Application.Quit();
            }
        }

    }

    public void DeleteSave()
    {
        SaveSystem.DeleteSave(map);
        //Debug.Log("Saved Game Deleted :(");
    }

    public void SaveGame()
    {
        SaveSystem.SaveGame(map, money, adController);
        //Debug.Log("Game Saved :)");
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

    public void LoadGameData()
    {
        GameData data = SaveSystem.LoadGame(map);

        GameObject[] Stands;
        GameObject[] CustomerSpawners;

        Stands = GameObject.FindGameObjectsWithTag("Stand");
        Array.Sort(Stands, CompareObNames);
        CustomerSpawners = GameObject.FindGameObjectsWithTag("CustomerSpawner");

        for (int i = 0; i < Stands.Length; i++)
        {
            Stands[i].GetComponent<Stand>().ShopSellingItemLevel = data.shopSellingItemLevel[i];
            Stands[i].GetComponent<Stand>().ShopTilemapLevel = data.shopTilemapLevel[i];
            Stands[i].GetComponent<Stand>().shopBought = data.shopBought[i];
            Stands[i].GetComponent<Stand>().SellingItemUpgradeCost = data.sellingItmeUpgradeCost[i];
            Stands[i].GetComponent<Stand>().ShopUpgradeCost = data.ShopUpgradeCost[i];
            Stands[i].GetComponent<Stand>().StandWaitingTime = data.StandWaitingTime[i];
            Stands[i].GetComponent<Stand>().productPrice = data.productPrice[i];
            Stands[i].GetComponent<Stand>().TotalStandRevenue = data.TotalStandRevenue[i];
        }

        for (int i = 0; i < CustomerSpawners.Length; i++)
        {
            CustomerSpawners[i].GetComponent<CustomerSpawner>().isActive = data.SpawnerActive[i];
        }

        money._totalMoney = data.totalMoney;
        money.totalShopExpenses = data.totalShopExpenses;
        money.totalAddExpenses = data.totalAddExpenses;

        adController.AddTimer = data.AddTimer;
    }

    //Test
    int CompareObNames(GameObject x, GameObject y)
    {
        return x.name.CompareTo(y.name);
    }

}