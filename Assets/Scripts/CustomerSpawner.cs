using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public int numCustomers;
    public GameObject[] Customers;
    public float _minSpawnTime = 1f;
    public float _maxSpawnTime = 5f;
    public bool isActive;

    private GameObject Customer;
    private float _timer = 0f;
    private int _randomCustomer;
    private string _standType;
    private string[] _newStaticStandTypes;
    public int unlockedStandsNo;
    private GameObject[] Stands;
    private int _randomNumber;

    void Start()
    {
        unlockedStandsNo = 0;
    }

    void Update()
    {
        if (isActive)
        {
            Stands = GameObject.FindGameObjectsWithTag("Stand");
            Array.Sort(Stands, CompareObNames);

            _newStaticStandTypes = new string[Stands.Length];

            foreach (GameObject stand in Stands)
            {
                if (stand.GetComponent<Stand>().shopBought)
                {
                    _newStaticStandTypes[unlockedStandsNo] = stand.GetComponent<Stand>().StandNumber;
                    unlockedStandsNo++;
                }
            }

            _timer -= Time.deltaTime;

            if (_timer <= 0f)
            {
                _randomNumber = UnityEngine.Random.Range(0, unlockedStandsNo);
                _standType = _newStaticStandTypes[_randomNumber];

                //select random number between 0 and the array size
                _randomCustomer = UnityEngine.Random.Range(0, numCustomers);

                Customer = Instantiate(Customers[_randomCustomer], transform.position, Quaternion.identity);
                Customer.GetComponent<CustomerMovement>()._standType = _standType;
                if (unlockedStandsNo > 0)
                {
                    foreach(GameObject stand in Stands)
                    {
                        if(stand.GetComponent<Stand>().StandNumber == _standType)
                            Customer.GetComponent<CustomerMovement>().standWaitTime = stand.GetComponent<Stand>().StandWaitingTime;
                    }
                }

                _timer += UnityEngine.Random.Range(_minSpawnTime, _maxSpawnTime);
            }

            unlockedStandsNo = 0;
        }
    }

    //Test
    int CompareObNames(GameObject x, GameObject y)
    {
        return x.name.CompareTo(y.name);
    }
}
