using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IngredientCheck : MonoBehaviour
{
    public UnityEvent ExecuteOnAllIngredients;
    private void Update()
    {
        if (KitchenDish.instance.baseIngredient != Ingredient.None && KitchenDish.instance.toppingIngredient != Ingredient.None)
        {
            ExecuteOnAllIngredients.Invoke();
            Destroy(this);
        }
    }
}

