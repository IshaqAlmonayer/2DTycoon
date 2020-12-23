﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardEeagleSpawner : MonoBehaviour
{
    public GameObject RewardEagle;
    public float _minSpawnTime;
    public float _maxSpawnTime;

    private float _timer;

    private void Start()
    {
        //_timer = 0;
        _timer += Random.Range(_minSpawnTime, _maxSpawnTime);
    }

    void Update()
    {
        
        if (_timer > 0)
            _timer -= Time.deltaTime;
        else
        {
            Instantiate(RewardEagle, transform.position, Quaternion.identity);
            
            _timer += Random.Range(_minSpawnTime, _maxSpawnTime);
        }
    }
}