using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowUp : MonoBehaviour
{

    public Money money;
    public Stand stand;

    public Sprite[] ImageSprites = new Sprite[2];


    void Update()
    {
        if (!stand.GetComponent<Stand>().shopBought && money.GetComponent<Money>()._totalMoney > stand.GetComponent<Stand>().ShopPrice)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = ImageSprites[1];
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if (stand.GetComponent<Stand>().shopBought
               && ( 
               (money.GetComponent<Money>()._totalMoney >= stand.GetComponent<Stand>().ShopUpgradeCost 
                            && stand.GetComponent<Stand>().ShopTilemapLevel < stand.GetComponent<Stand>().MaximumTilemapUpgradeLevel)
               || (money.GetComponent<Money>()._totalMoney >= stand.GetComponent<Stand>().SellingItemUpgradeCost 
                            && stand.GetComponent<Stand>().ShopSellingItemLevel < stand.GetComponent<Stand>().MaximumSellingItemUpgradeLevel)
                  )
               )
             {
                gameObject.GetComponent<SpriteRenderer>().sprite = ImageSprites[0];
                gameObject.GetComponent<Renderer>().enabled = true;
             }
            else
            {
                gameObject.GetComponent<Renderer>().enabled = false;
            }
    }
}
