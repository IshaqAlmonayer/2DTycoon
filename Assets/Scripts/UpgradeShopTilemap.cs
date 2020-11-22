using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeShopTilemap : MonoBehaviour
{
    public Stand stand;
    public GameObject[] tilemap;
    private int ShopLevel;

    void Start()
    {
        ShopLevel = stand.GetComponent<Stand>().ShopLevel;
        tilemap[ShopLevel].SetActive(true);
    }
   
    public void changeTilemap(int prevShopLevel,int currentShopLevel)
    {
        tilemap[prevShopLevel].SetActive(false);
        tilemap[currentShopLevel].SetActive(true);
    }

}
