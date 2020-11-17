﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public int numCustomers;
    public GameObject[] Customers;
    public GameObject Customer;
    public Component Script;
    public float _minSpawnTime = 1f;
    public float _maxSpawnTime = 5f;
    
    private float _timer = 0f;
    private int _randomCustomer;
    private string _standType;
    private string[] _staticStandTypes = new string[2];

    void Start()
    {
        //define the types of stands that we have
        _staticStandTypes[0] = "BurgerStand";
        _staticStandTypes[1] = "DaughnutStand";
        //_staticStandTypes[2] = "PizzaStand";
        //_staticStandTypes[3] = "IcecreamStand";
        //_staticStandTypes[4] = "FalafelStand";
    }

    void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0f)
        {
            
            _standType = _staticStandTypes[Random.Range(0, _staticStandTypes.Length)];

            //select random number between 0 and the array size
            _randomCustomer = Random.Range(0, numCustomers);

            Customer = Instantiate(Customers[_randomCustomer], transform.position, Quaternion.identity);
            Customer.GetComponent<CustomerMovement>()._standType = _standType;

            _timer += Random.Range(_minSpawnTime, _maxSpawnTime);
        }
    }
}
