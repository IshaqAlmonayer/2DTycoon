using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCityButton : MonoBehaviour
{
    public  City city;
    public Money money;

    private float _cityPrice;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        _cityPrice = city.GetComponent<City>().price;

        if (!city.GetComponent<City>().unlocked)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (money.GetComponent<Money>()._totalMoney >= _cityPrice)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
            gameObject.GetComponent<Button>().interactable = false;
    }

    void TaskOnClick()
    {
        money.GetComponent<Money>()._totalMoney -= _cityPrice;
        gameObject.SetActive(false);
        city.GetComponent<City>().unlocked = true;
    }


}