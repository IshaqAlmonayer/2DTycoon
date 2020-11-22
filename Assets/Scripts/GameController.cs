using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Money money;
    public float _saveFrequency = 100;
    private float _autoSaveTimer = 0;


    private void Awake()
    {
        GameData data = SaveSystem.LoadGame();

        GameObject[] Stands;

        Stands = GameObject.FindGameObjectsWithTag("Stand");

        for (int i = 0; i < Stands.Length; i++)
        {
            Stands[i].GetComponent<Stand>().ShopLevel = data.shopLevel[i];
            Stands[i].GetComponent<Stand>().shopBought = data.shopBought[i];
            Stands[i].GetComponent<Stand>().UpgradeCost = data.shopUpgradeCost[i];
        }

        money._totalMoney = data.totalMonay;
    }

    void Start()
    {
        
    }

    private void Update()
    {
        _autoSaveTimer -= Time.deltaTime;
    
        if(_autoSaveTimer <= 0)
        {
            SaveSystem.SaveGame(money);
            _autoSaveTimer = _saveFrequency;
            //Debug.Log("Game Saved :)");
        }

    }

    public void DeleteSave()
    {
        SaveSystem.DeleteSave();
        //Debug.Log("Saved Game Deleted :(");
    }

    public void SaveGame()
    {
        SaveSystem.SaveGame(money);
        //Debug.Log("Game Saved :)");
    }

}
