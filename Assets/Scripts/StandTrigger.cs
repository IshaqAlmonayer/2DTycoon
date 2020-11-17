using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandTrigger : MonoBehaviour
{
    public GameObject Customer;

    private Component CustomerScript;
    void Start()
    {
        CustomerScript = Customer.GetComponent<CustomerMovement>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

    }

}
