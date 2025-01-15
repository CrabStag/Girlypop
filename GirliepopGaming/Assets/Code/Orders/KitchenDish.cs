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

    [HideInInspector]
    public List<Order> discoveredDishes = new List<Order>();

    private void Start()
    {
        instance = this;
    }

    public void BakeDish()
    {
        foreach (Order order in allDishes)
        {
            if(order.ingredient1 == baseIngredient && order.ingredient2 == toppingIngredient)
            {
                counterDish.order = order;
                counterDish.image.sprite = order.image;
                print(counterDish.order);
                print(order);

                if(discoveredDishes.Contains(order))
                {
                    PopoutCard.instance.cardImage.sprite = order.regularPopupCard;
                }

                if (!discoveredDishes.Contains(order))
                {
                    discoveredDishes.Add(order);
                    PopoutCard.instance.cardImage.sprite = order.newPopupCard;
                }
                PopoutCard.instance.cardImage.SetNativeSize();
                PopoutCard.instance.currentCoroutine = PopoutCard.instance.PopUp();
                StartCoroutine(PopoutCard.instance.currentCoroutine);

            }
        }
        baseIngredient = Ingredient.None;
        toppingIngredient = Ingredient.None;

        baseImage.sprite = null;
        toppingImage.sprite = null;
    }

}
