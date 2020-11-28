using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvertiseController : MonoBehaviour
{
    public float AddTimer;
    public CustomerSpawner[] Spawners;

    void Update()
    {
        if (AddTimer > 0)
        {
            AddTimer -= Time.deltaTime;
        }
        else
        {
            foreach (CustomerSpawner spawner in Spawners)
            {
                spawner.GetComponent<CustomerSpawner>().isActive = false;
            }
        }
    }

}
