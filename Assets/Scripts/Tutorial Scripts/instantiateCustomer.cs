using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateCustomer : MonoBehaviour
{
    public GameObject CustomerSprite;
    private GameObject Customer;

    public void SpawnCustomer()
    {
        Customer = Instantiate(CustomerSprite, transform.position, Quaternion.identity);
        Customer.GetComponent<CustomerMovement>()._standType = "BurgerStand";
    }

}
