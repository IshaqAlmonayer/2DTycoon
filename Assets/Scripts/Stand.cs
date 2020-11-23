using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{

    public int ShopLevel;
    public float UpgradeCost = 10f;
    public float ShopPrice = 10f;
    public float MaximumUpgradeLevel = 3f;
    public float productPrice = 1f;
    public bool shopBought = false;
    public AudioClip CoinSound;

    private float _layer;
    //Shop Layers:
    //8: BurgerStand
    //9: DoughnutStand
    //10: PizzaStand

    private bool _trigger = false;
    

    private void Start()
    {
        _layer = gameObject.layer;
    }
 
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Customer") && shopBought)
        {
            _trigger = true;
            AudioSource.PlayClipAtPoint(CoinSound, transform.position, 1);
        }
    }

    public float GetMoney()
    {
        if (_trigger == true)
        {
            Debug.Log("Price: " + productPrice * ShopLevel);
            _trigger = false;
            return productPrice * ShopLevel;
        }
        else 
            return 0;

        //if(_trigger == true) { 
        //    if (_layer == 8) //BurgerStand
        //        switch (ShopLevel)
        //        {
        //            case 1:
        //                _trigger = false;
        //                return 1;
        //            case 2:
        //                _trigger = false;
        //                return 2;
        //            case 3:
        //                _trigger = false;
        //                return 3;
        //        }
        //    if (_layer == 9) //DoughnutStand
        //        switch (ShopLevel)
        //        {
        //            case 1:
        //                _trigger = false;
        //                return 2;
        //            case 2:
        //                _trigger = false;
        //                return 3;
        //            case 3:
        //                _trigger = false;
        //                return 4;
        //        }
        //    if (_layer == 10) //PizzaStand
        //        switch (ShopLevel)
        //        {
        //            case 1:
        //                _trigger = false;
        //                return 3;
        //            case 2:
        //                _trigger = false;
        //                return 4;
        //            case 3:
        //                _trigger = false;
        //                return 5;
        //        }
        //}
        //return 0;
    }

}