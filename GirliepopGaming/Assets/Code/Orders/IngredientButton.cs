using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientButton : MonoBehaviour
{
    public IngredientType ingredientType;
    public Ingredient ingredient;
    public Sprite bowlImage;

    private SpriteRenderer image;

    private void Start()
    {
        image = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        image.color = Color.green;
    }

    private void OnMouseExit()
    {
        image.color = Color.white;
    }

    private void OnMouseUpAsButton()
    {
        switch(ingredientType)
        {
            case IngredientType.Base:
                print(ingredientType);

                KitchenDish.instance.baseIngredient = ingredient;
                KitchenDish.instance.baseImage.sprite = bowlImage;
                break;
            case IngredientType.Topping:
                print(ingredientType);

                KitchenDish.instance.toppingIngredient = ingredient;
                KitchenDish.instance.toppingImage.sprite = bowlImage;
                break;

        }
    }

}

public enum IngredientType
{
    Base,
    Topping
}
