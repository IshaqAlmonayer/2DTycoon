using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopDescription : MonoBehaviour
{
    
    public Stand stand;
    public string shopName;

    private Text DescriptionText;

    private void Start()
    {
        DescriptionText = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        if (!stand.shopBought)
        {
            DescriptionText.text = "?????";
        }
        else {
            switch (shopName) {
                case "BurgerShop":
                    DescriptionText.text = "Can you smell it? The smell of the best Burger in town because this is the only burger place there is.";
                    break;
                case "DoughnutShop":
                    DescriptionText.text = "Donut worry, be happy. puns... those make me nuts and want to eat some doughnuts.";
                    break;
                case "PizzaShop":
                    DescriptionText.text = "Do you Know Lisa from the simpsons? well this is not her this is a diffirent liza that knows how to make pizza.";
                    break;
                case "JuiceShop":
                    DescriptionText.text = "have you Ever tasted watermelon with chocolate? well of course you haven't, and if you did eww.. what were you thinking?";
                    break;
                case "IceCreamShop":
                    DescriptionText.text = "I scream you scream we scream. Come get some Icecream.";
                    break;
                case "RamenShop":
                    DescriptionText.text = "this place sells ramen we used this name just because it sounded funny.";
                    break;
                case "FishShop":
                    DescriptionText.text = "no fishes were harmed in the making of this game.";
                    break;
                case "FrenchFriesShop":
                    DescriptionText.text = "french? belgian? who knows? we all love them so no one cares.";
                    break;
                case "ClothesShop":
                    DescriptionText.text = "bill gates buys his shirts from here.";
                    break;
                case "BookShop":
                    DescriptionText.text = "did you know that on land the Giant Armadillo is the mamal with the most teeth? no you didn't because you don't read books.";
                    break;
                case "CafeShop":
                    DescriptionText.text = "Better than that star and bucks coffe house. it's called cafe e becase a,b,c and d were taken.";
                    break;
                case "GuitarShop":
                    DescriptionText.text = "not actual platinum!! dont sue us because you miss understood.";
                    break;
                case "MoviesShop":
                    DescriptionText.text = "Wanna watch some good old movies? well if you couldn't find any on the internet come buy some dvds from here.";
                    break;
                case "PetShop":
                    DescriptionText.text = "always Take care of your pet.";
                    break;
                case "FlowerShop":
                    DescriptionText.text = "here comes the sun do do do do... this song really gets stuck in your head.";
                    break;
                case "SportsShop":
                    DescriptionText.text = "You should workout instead of playing videogames.";
                    break;
                case "ToyShop":
                    DescriptionText.text = "to infinity and beyond.";
                    break;
                case "ElectronicStand":
                    DescriptionText.text = "want a computer? take one, want a laser mouse? take one, want a keyboard? take one. all of that is just for 555$ + shipping.";
                    break;
                case "Bakery":
                    DescriptionText.text = "to be honest i'm out of ideas, so just Come Buy Bread And Cake.";
                    break;
                case "PizzaShop2":
                    DescriptionText.text = "Do you remember liza? well this is her cousin terissa. it seems making pizza is a gift in this family.";
                    break;
                case "GiftShop":
                    DescriptionText.text = "it's almost the holidays!! or is it? time is really weird in this town. anyway buy some presents for the people you love.";
                    break;
                case "CandyShop":
                    DescriptionText.text = "eat as much sweets as you want, but remember to brush your teeth three times a day or you will be visiting your dentist soon..";
                    break;
                case "HotDogShop":
                    DescriptionText.text = "you made it to here? you're awesome, take a free hot dog its on us.";
                    break;
            }
        }
    }
}
