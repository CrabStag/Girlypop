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
    public Order slopOrder;

    public bool isTutorial = false;

    [HideInInspector]
    public List<Order> discoveredDishes = new List<Order>();

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            discoveredDishes = instance.discoveredDishes;
            
            Destroy(instance.gameObject);
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
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
        bool foundOrder = false;
        foreach (Order order in allDishes)
        {
            if (order.ingredient1 == baseIngredient && order.ingredient2 == toppingIngredient)
            {
                foundOrder = true;
                counterDish.order = order;
                counterDish.image.sprite = order.image;

                if (isTutorial == false)
                {
                    if (discoveredDishes.Contains(order))
                    {
                        PopoutCard.instance.cardImage.sprite = order.regularPopupCard;
                    }
                    else
                    {
                        discoveredDishes.Add(order);
                        Debug.Log($"New dish discovered: {order.NameOfOrder} with ingredients {order.ingredient1} and {order.ingredient2}");
                        if (RecipeAchievementTracker.Instance == null)
                        {
                            Debug.LogError("RecipeAchievementTracker.Instance is null!");
                        }
                        else
                        {
                            RecipeAchievementTracker.Instance.CheckAllAchievements();
                        }
                        PopoutCard.instance.cardImage.sprite = order.newPopupCard;
                    }

                    PopoutCard.instance.cardImage.SetNativeSize();
                    PopoutCard.instance.currentCoroutine = PopoutCard.instance.PopUp();
                    StartCoroutine(PopoutCard.instance.currentCoroutine);
                }

            }
        }

            if (foundOrder == false)
        {
            if (!isTutorial)
            {
                counterDish.order = slopOrder;
                SpawnCustomers.Instance.currentOrder = slopOrder; // <== Add this!

                counterDish.image.sprite = slopOrder.image;

                if (discoveredDishes.Contains(slopOrder))
                {
                    PopoutCard.instance.cardImage.sprite = slopOrder.regularPopupCard;
                }

                if (!discoveredDishes.Contains(slopOrder))
                {
                    discoveredDishes.Add(slopOrder);
                    PopoutCard.instance.cardImage.sprite = slopOrder.newPopupCard;
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
