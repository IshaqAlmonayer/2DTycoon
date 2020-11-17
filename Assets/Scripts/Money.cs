using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    private TextMeshProUGUI TextPro;
    

    private GameObject[] Stands;
    private float _money;
    private float _totalMoney;

    void Update()
    {
        Stands = GameObject.FindGameObjectsWithTag("Stand");

        foreach (GameObject Stand in Stands)
        {
            _money += Stand.GetComponent<Stand>().GetMoney();
        }

        _totalMoney = _money;

        _money = 0;

        TextPro = gameObject.GetComponent<TextMeshProUGUI>();

        TextPro.text = _totalMoney.ToString() + "$";
    }
}
