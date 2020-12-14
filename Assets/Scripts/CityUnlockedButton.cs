using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityUnlockedButton : MonoBehaviour
{
    public City city;

    void Start()
    {
        if (city.GetComponent<City>().unlocked)
            gameObject.GetComponent<Button>().interactable = true;
        else
            gameObject.GetComponent<Button>().interactable = false;
    }
}
