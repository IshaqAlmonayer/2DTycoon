using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopOnHoldInfoButton : MonoBehaviour
{
    public Stand stand;
    public Text text;
    public string InfoType;

    void Start()
    {
        if(InfoType == "Price")
            text.text = stand.GetComponent<Stand>().productPrice.ToString() + "$";
        if(InfoType == "WaitingTime")
            text.text = stand.GetComponent<Stand>().StandWaitingTime.ToString() + " sec";
    }

    private void Update()
    {
        if (InfoType == "Price")
            text.text = stand.GetComponent<Stand>().productPrice.ToString() + "$";
        if (InfoType == "WaitingTime")
            text.text = stand.GetComponent<Stand>().StandWaitingTime.ToString() + " sec";
    }
}
