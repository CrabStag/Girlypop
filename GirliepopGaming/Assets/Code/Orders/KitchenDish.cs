using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenDish : MonoBehaviour
{

    public Ingredient baseIngredient;
    public Ingredient toppingIngredient;

    public SpriteRenderer baseImage;
    public SpriteRenderer toppingImage;

    [Header("Oven Bowl Image sprites (same as above but for the oven screen bowl)")]
    public SpriteRenderer ovenBaseImage;
    public SpriteRenderer ovenToppingImage;

    public GameObject toOvenButton;
    public GameObject OvenBowl;

    public DragDish counterDish;

    public static KitchenDish instance;

    public List<Order> allDishes = new List<Order>();

    public bool isTutorial = false;

    [HideInInspector]
    public List<Order> discoveredDishes = new List<Order>();

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if(toppingIngredient != Ingredient.None && baseIngredient != Ingredient.None)
        {
            if(toOvenButton != null)
                toOvenButton.SetActive(true);
            OvenBowl.SetActive(true);
        } else
        {
            if (toOvenButton != null)
                toOvenButton.SetActive(false);
            OvenBowl.SetActive(false); 

        }
    }

    public void BakeDish()
    {

        foreach (Order order in allDishes)
        {
            if(order.ingredient1 == baseIngredient && order.ingredient2 == toppingIngredient)
            {
                counterDish.order = order;
                counterDish.image.sprite = order.image;

                if (isTutorial == false)
                {
                    if (discoveredDishes.Contains(order))
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
        }
        baseIngredient = Ingredient.None;
        toppingIngredient = Ingredient.None;

        baseImage.sprite = null;
        toppingImage.sprite = null;
    }

}
