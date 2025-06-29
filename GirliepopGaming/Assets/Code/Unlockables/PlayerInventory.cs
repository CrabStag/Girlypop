using System;
using System.Collections.Generic;
using UnityEngine;



public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    private HashSet<Ingredient> unlockedIngredients = new HashSet<Ingredient>();

    // Event triggered when a new ingredient is added
    public event Action<Ingredient> OnIngredientUnlocked;

    private void Awake()
    {

        Debug.Log("PlayerInventory Awake called");
        // PlayerPrefs.DeleteAll();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadStarterIngredients();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool HasIngredient(Ingredient ingredient)
    {
        return unlockedIngredients.Contains(ingredient);
    }

    public void AddIngredient(Ingredient ingredient)
    {
        if (unlockedIngredients.Add(ingredient))
        {
            Debug.Log($"Ingredient unlocked: {ingredient}");
            OnIngredientUnlocked?.Invoke(ingredient);
           // SaveIngredients();
        }
    }

    public List<Ingredient> GetUnlockedIngredients()
    {
        return new List<Ingredient>(unlockedIngredients);
    }

    // ----------- Save/Load Ingredients (Optional) ------------

    // private const string SaveKey = "UnlockedIngredients";

    // private void SaveIngredients()
    //{
    // Convert unlocked ingredients to comma-separated string
    //  string saveString = string.Join(",", unlockedIngredients);
    //    PlayerPrefs.SetString(SaveKey, saveString);
    //  PlayerPrefs.Save();
    //}

    // private void LoadIngredients()
    // {
    //    unlockedIngredients.Clear();

    //    if (PlayerPrefs.HasKey(SaveKey))
    //    {
    //        string savedData = PlayerPrefs.GetString(SaveKey);
    //        if (!string.IsNullOrEmpty(savedData))
    //        {
    //            string[] ingredients = savedData.Split(',');
    //            foreach (string ingr in ingredients)
    //           {
    //               if (Enum.TryParse(ingr, out Ingredient ingredient))
    //               {
    //                   unlockedIngredients.Add(ingredient);
    //               }
    //  }
    //  }
    // }
    private void LoadStarterIngredients()
    {
        unlockedIngredients.Clear();

        // Add your starter ingredients here
        AddIngredient(Ingredient.Milk);
        AddIngredient(Ingredient.Sugar);
        AddIngredient(Ingredient.Caramel);
        AddIngredient(Ingredient.Choco);
        AddIngredient(Ingredient.Jam);
        AddIngredient(Ingredient.Fruits);

        Debug.Log("Loaded starter ingredients: " + string.Join(", ", unlockedIngredients));
    }
         
}
