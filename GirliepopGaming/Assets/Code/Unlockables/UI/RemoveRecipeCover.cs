using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveRecipeCover : MonoBehaviour
{
    public Order panelDish;
    public GameObject CoverUp;
    public GameObject NameTextObject;

    private void Update()
    {
        if(KitchenDish.instance.discoveredDishes.Contains(panelDish))
        {
            RevealRecipe();
        }
    }

    public void RevealRecipe()
    {
        CoverUp.SetActive(false);
        NameTextObject.SetActive(true);
    }
}
