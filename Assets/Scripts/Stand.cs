using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{

    public float _money = 0f;
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag.Equals("Customer"))
        {
            _money++;
        }

        GetMoney();

    }

    public float GetMoney()
    {
        return _money;
    }
}
