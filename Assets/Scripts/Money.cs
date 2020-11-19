using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    private TextMeshProUGUI TextPro;
    

    private GameObject[] Stands;
    public float _totalMoney;

    private void Start()
    {
        _totalMoney = 0f;
    }

    void Update()
    {
        Stands = GameObject.FindGameObjectsWithTag("Stand");

        foreach (GameObject Stand in Stands)
        {
            _totalMoney += Stand.GetComponent<Stand>().GetMoney();
        }

        TextPro = gameObject.GetComponent<TextMeshProUGUI>();

        TextPro.text = _totalMoney.ToString() + "$";
    }
}
