using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientButton : MonoBehaviour
{
    public IngredientType ingredientType;

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
                break;
            case IngredientType.Topping:
                break;

        }
    }

}

public enum IngredientType
{
    Base,
    Topping
}
