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
    private string[] _newStaticStandTypes =  new string[8];
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


            foreach (GameObject stand in Stands)
            {
                if (stand.GetComponent<Stand>().shopBought)
                {
                    _newStaticStandTypes[unlockedStandsNo] = stand.GetComponent<Stand>().StandName;
                    unlockedStandsNo++;
                    //Debug.Log("stand.GetComponent<Stand>().StandName:["+unlockedStandsNo+ "] " + stand.GetComponent<Stand>().StandName);
                }
            }

            _timer -= Time.deltaTime;

            if (_timer <= 0f)
            {
                //Debug.Log("unlockedStandsNo: " + unlockedStandsNo);
                _randomNumber = Random.Range(0, unlockedStandsNo);
                //Debug.Log("_randomNumber: " + _randomNumber);
                _standType = _newStaticStandTypes[_randomNumber];

                //select random number between 0 and the array size
                _randomCustomer = Random.Range(0, numCustomers);

                Customer = Instantiate(Customers[_randomCustomer], transform.position, Quaternion.identity);
                Customer.GetComponent<CustomerMovement>()._standType = _standType;
                if (unlockedStandsNo > 0)
                {
                    Customer.GetComponent<CustomerMovement>().standWaitTime = Stands[_randomNumber].GetComponent<Stand>().StandWaitingTime;
                }

                //Debug.Log(Stands[_randomNumber].GetComponent<Stand>().StandName + "Stands[" + _randomNumber + "]" + Stands[_randomNumber].GetComponent<Stand>().StandWaitingTime);
                //Debug.Log("Customer.standWaitTime: " + Customer.GetComponent<CustomerMovement>().standWaitTime);
                

                _timer += Random.Range(_minSpawnTime, _maxSpawnTime);
            }

            unlockedStandsNo = 0;
        }
    }
}
