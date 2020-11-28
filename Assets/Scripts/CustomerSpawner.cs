using System.Collections;
using System.Collections.Generic;
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
    private string[] _newStaticStandTypes =  new string[4];
    public int unlockedStandsNo;
    private GameObject[] Stands;

    void Start()
    {
        unlockedStandsNo = 0;
    }

    void Update()
    {
        if (isActive)
        {
            Stands = GameObject.FindGameObjectsWithTag("Stand");


            foreach (GameObject stand in Stands)
            {
                if (stand.GetComponent<Stand>().shopBought)
                {
                    _newStaticStandTypes[unlockedStandsNo] = stand.GetComponent<Stand>().StandName;
                    unlockedStandsNo++;
                }
            }

            _timer -= Time.deltaTime;

            if (_timer <= 0f)
            {
                _standType = _newStaticStandTypes[Random.Range(0, unlockedStandsNo)];

                //select random number between 0 and the array size
                _randomCustomer = Random.Range(0, numCustomers);

                Customer = Instantiate(Customers[_randomCustomer], transform.position, Quaternion.identity);
                Customer.GetComponent<CustomerMovement>()._standType = _standType;

                _timer += Random.Range(_minSpawnTime, _maxSpawnTime);
            }

            unlockedStandsNo = 0;
        }
    }
}
