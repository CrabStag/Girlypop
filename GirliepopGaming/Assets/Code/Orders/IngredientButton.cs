using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngredientType
{
    Base,
    Topping
}

public class IngredientButton : MonoBehaviour
{
    public IngredientType ingredientType;
    public Ingredient ingredient;
    public Sprite bowlImage;

    private void Start()
    {
        UpdateVisibility();

        // Subscribe to ingredient unlock event to update button when new ingredient added
        if (PlayerInventory.Instance != null)
        {
            PlayerInventory.Instance.OnIngredientUnlocked += OnIngredientUnlocked;
        }
    }

    private void OnDestroy()
    {
        if (PlayerInventory.Instance != null)
        {
            PlayerInventory.Instance.OnIngredientUnlocked -= OnIngredientUnlocked;
        }
    }

    private void OnIngredientUnlocked(Ingredient newIngredient)
    {
        if (newIngredient == ingredient)
        {
            UpdateVisibility();
        }
    }

    private void OnEnable()
    {
        if (PlayerInventory.Instance != null)
            PlayerInventory.Instance.OnIngredientUnlocked += CheckVisibility;
    }

    private void OnDisable()
    {
        if (PlayerInventory.Instance != null)
            PlayerInventory.Instance.OnIngredientUnlocked -= CheckVisibility;
    }

    private void CheckVisibility(Ingredient unlockedIngredient)
    {
        // Refresh visibility whenever an ingredient is unlocked
        gameObject.SetActive(PlayerInventory.Instance.HasIngredient(ingredient));
    }

    // Show/hide button based on if player has ingredient unlocked
    public void UpdateVisibility()
    {
        bool hasIngredient = PlayerInventory.Instance != null && PlayerInventory.Instance.HasIngredient(ingredient);
        gameObject.SetActive(hasIngredient);
    }

    public void PlaceIngredientInBowl()
    {
        switch (ingredientType)
        {
            case IngredientType.Base:
                print(ingredientType);

                KitchenDish.instance.baseIngredient = ingredient;
                KitchenDish.instance.baseImage.sprite = bowlImage;
                KitchenDish.instance.ovenBaseImage.sprite = bowlImage;
                break;

            case IngredientType.Topping:
                print(ingredientType);

                KitchenDish.instance.toppingIngredient = ingredient;
                KitchenDish.instance.toppingImage.sprite = bowlImage;
                KitchenDish.instance.ovenToppingImage.sprite = bowlImage;
                break;
        }
    }

}
