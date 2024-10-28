using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeButton : MonoBehaviour
{
    public GameObject bakedDish;

    private SpriteRenderer image;

    private void Start()
    {
        image = bakedDish.GetComponent<SpriteRenderer>();
    }

    private void OnMouseUpAsButton()
    {
        KitchenDish.instance.BakeDish();
    }
}
