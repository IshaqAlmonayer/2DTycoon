using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CityButton : MonoBehaviour
{
    public City city;
    public bool thisCity;

    void Update()
    {
        if (city.GetComponent<City>().unlocked && !thisCity)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
