using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{

    public int ShopSellingItemLevel;
    public int ShopTilemapLevel;
    public float SellingItemUpgradeCost;
    public float ShopUpgradeCost;
    public string SellingItem;
    public float ShopPrice;
    public float MaximumSellingItemUpgradeLevel;
    public float MaximumTilemapUpgradeLevel;
    public float productPrice;
    public bool shopBought = false;
    public string StandName;
    public float StandWaitingTime;
    public AudioClip CoinSound;

    //Shop Layers:
    //8: BurgerStand
    //9: DoughnutStand
    //10: PizzaStand

    private bool _trigger = false;
    

    private void Start()
    {

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
            //Debug.Log("Price: " + productPrice * ShopSellingItemLevel);
            _trigger = false;
            return productPrice;
        }
        else 
            return 0;
    }

}