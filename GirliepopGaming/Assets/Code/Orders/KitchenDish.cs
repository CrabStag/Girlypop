using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenDish : MonoBehaviour
{

    public Ingredient baseIngredient;
    public Ingredient toppingIngredient;

    public SpriteRenderer baseImage;
    public SpriteRenderer toppingImage;

    public DragDish counterDish;

    public static KitchenDish instance;

    public List<Order> allDishes = new List<Order>();

    private void Start()
    {
        instance = this;
    }

    public void BakeDish()
    {
        //TODO: find dish based on ingredient combination
        foreach (Order order in allDishes)
        {
            if(order.ingredient1 == baseIngredient && order.ingredient2 == toppingIngredient)
            {
                counterDish.order = order;
                counterDish.image.sprite = order.image;
                print(counterDish.order);
                print(order);
            }
        }
    }

}
