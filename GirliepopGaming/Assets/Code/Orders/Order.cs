using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Order", order = 1)]
public class Order : ScriptableObject
{
    public Ingredient ingredient1;
    public Ingredient ingredient2;

    public Sprite image;

}

public enum Ingredient
{
    Milk,
    Caramel,
    Jam,
    Sugar,
    Fruits,
    Choco,
    None
}
