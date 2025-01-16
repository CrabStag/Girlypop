using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientButton : MonoBehaviour
{
    public IngredientType ingredientType;
    public Ingredient ingredient;
    public Sprite bowlImage;

    public void PlaceIngredientInBowl()
    {
        switch(ingredientType)
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

public enum IngredientType
{
    Base,
    Topping
}
