using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Order", order = 1)]
public class Order : ScriptableObject
{
    public string NameOfOrder;

    public Ingredient ingredient1;
    public Ingredient ingredient2;

    public Sprite image;
    public Sprite newPopupCard;
    public Sprite regularPopupCard;

}

public enum Ingredient
{
    Milk,
    Sugar,
    Caramel,
    Choco,
    Jam,
    Fruits,
    Mandrake,
    MixedNuts,
    LoveEssence,
    GraveViola,
    CrystalMethite,
    UnicornMarrow,
    Poison,
    None 
}
