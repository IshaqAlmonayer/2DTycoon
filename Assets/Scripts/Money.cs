using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    private TextMeshProUGUI TextPro;
    

    private GameObject[] Stands;
    public float totalShopExpenses;
    public float totalAddExpenses;
    public float TotalRevenuePastMinute;
    public float currentTotalRevenue;
    public float totalRevenuePerMinute;
    public float _totalMoney;

    private float _timer = 60;
    
    public float moneyPerMinute;

    private void Start()
    {
        _totalMoney = 100000;
        //Debug.Log("totalRevenuePerMinute: " + totalRevenuePerMinute);
    }

    void Update()
    {
        Stands = GameObject.FindGameObjectsWithTag("Stand");

        foreach (GameObject Stand in Stands)
        {
            _totalMoney += Stand.GetComponent<Stand>().GetMoney();
        }

        foreach (GameObject Stand in Stands)
        {
            currentTotalRevenue += Stand.GetComponent<Stand>().TotalStandRevenue;
        }

        if(_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            totalRevenuePerMinute = currentTotalRevenue - TotalRevenuePastMinute;
            Debug.Log("totalRevenuePerMinute: " + totalRevenuePerMinute);
            TotalRevenuePastMinute = currentTotalRevenue;
            _timer = 60f;
        }

        currentTotalRevenue = 0;

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