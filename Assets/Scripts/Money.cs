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
        //_totalMoney = 200000;
    }

    void Update()
    {
        Stands = GameObject.FindGameObjectsWithTag("Stand");

        foreach (GameObject Stand in Stands)
        {
            _totalMoney += Stand.GetComponent<Stand>().GetMoney();
        }

        TextPro = gameObject.GetComponent<TextMeshProUGUI>();

        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        if (_totalMoney < 1000)
            TextPro.text = _totalMoney.ToString() + "$";
        else if (_totalMoney >= 1000)
            TextPro.text = ((int)_totalMoney / 1000).ToString() + "." + ((int)(_totalMoney % 1000) / 100).ToString() + "K $";
    }


}
