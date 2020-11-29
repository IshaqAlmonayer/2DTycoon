using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject Cloud;
    public float _minSpawnTime;
    public float _maxSpawnTime;

    private float _timer;

    // Update is called once per frame
    void Update()
    {
        if (_timer > 0)
            _timer -= Time.deltaTime;
        else
        {
            Instantiate(Cloud, transform.position, Quaternion.identity);

            _timer += Random.Range(_minSpawnTime, _maxSpawnTime);
        }
    }
}
