using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvertiseController : MonoBehaviour
{
    public float AddTimer;
    public Animator Animator;
    public CustomerSpawner[] Spawners;

    void Update()
    {
        if (AddTimer > 0)
        {
            AddTimer -= Time.deltaTime;
            Animator.SetBool("AddRunning",true);
        }
        else
        {
            foreach (CustomerSpawner spawner in Spawners)
            {
                spawner.GetComponent<CustomerSpawner>().isActive = false;
            }
            Animator.SetBool("AddRunning", false);
        }
    }

}
