using System.Collections.Generic;
using UnityEngine;

public class RecipeAchievementTracker : MonoBehaviour
{
    [System.Serializable]
    public class RecipeAchievement
    {
        public string achievementId; // The ID used to unlock this achievement in AchievementManager
        public Ingredient ingredientToTrack; // The ingredient we want to track
        public int requiredCount; // How many recipes with this ingredient are needed
    }

    public List<RecipeAchievement> achievementsToTrack = new List<RecipeAchievement>();

    private void Update()
    {
        // Continuously check if achievements should be unlocked
        foreach (var achievement in achievementsToTrack)
        {
            CheckAchievementProgress(achievement);
        }
    }

    void CheckAchievementProgress(RecipeAchievement achievement)
    {
        int count = 0;

        // Loop through discovered dishes
        foreach (Order dish in KitchenDish.instance.discoveredDishes)
        {
            if (dish.ingredient1 == achievement.ingredientToTrack || dish.ingredient2 == achievement.ingredientToTrack)
            {
                count++;
            }
        }

        // Unlock achievement if condition met
        if (count >= achievement.requiredCount)
        {
            AchievementManager.Instance.Unlock(achievement.achievementId);
        }
    }
}
