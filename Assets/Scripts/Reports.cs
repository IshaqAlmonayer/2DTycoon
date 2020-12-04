using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Reports : MonoBehaviour
{
    public Text[] ShopRevenueText;
    public Text[] ShopProductPrice;
    public Text ShopExpenses;
    public Text AddExpenses;
    public Money money;

    private GameObject[] Stands;


    private void Start()
    {
        Stands = GameObject.FindGameObjectsWithTag("Stand");
        Array.Sort(Stands, CompareObNames);
    }

    void Update()
    {
        for(int i = 0;i<Stands.Length;i++)
        {
            ShopRevenueText[i].text = Stands[i].GetComponent<Stand>().TotalStandRevenue.ToString() + "$";
            if (Stands[i].GetComponent<Stand>().shopBought)
            {
                ShopProductPrice[i].text = Stands[i].GetComponent<Stand>().productPrice.ToString() + "$";
            }
            else
            {
                ShopProductPrice[i].text = "0$";
            }
        }

        ShopExpenses.text = money.GetComponent<Money>().totalShopExpenses.ToString() + "$";
        AddExpenses.text = money.GetComponent<Money>().totalAddExpenses.ToString() + "$";

    }

    //Test
    int CompareObNames(GameObject x, GameObject y)
    {
        return x.name.CompareTo(y.name);
    }
}
