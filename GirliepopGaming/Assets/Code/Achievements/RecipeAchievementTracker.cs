using System.Collections.Generic;
using UnityEngine;

public class RecipeAchievementTracker : MonoBehaviour
{
    public static RecipeAchievementTracker Instance;

    [System.Serializable]
    public class RecipeAchievement
    {
        public string achievementName; // Just a name/ID for display or reference
        public string achievementId; // The ID used to unlock this achievement in AchievementManager
        public Ingredient ingredientToTrack; // The ingredient we want to track
        public int requiredCount; // How many recipes with this ingredient are needed
        [HideInInspector]
        public bool unlocked = false;  // Track unlock state internally

        public GameObject achievementPopupPrefab; // assign in inspector
        public Transform popupParent; // assign in inspector

    }

    public List<RecipeAchievement> achievementsToTrack = new List<RecipeAchievement>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void CheckAllAchievements()
    {
        foreach (var achievement in achievementsToTrack)
        {
            CheckAchievementProgress(achievement);
        }
    }

    void CheckAchievementProgress(RecipeAchievement achievement)
    {
        if (achievement.unlocked) return; // Already unlocked, skip

        int count = 0;
        foreach (Order dish in KitchenDish.instance.discoveredDishes)
        {
            if (dish.ingredient1 == achievement.ingredientToTrack || dish.ingredient2 == achievement.ingredientToTrack)
            {
                count++;
            }
        }

        Debug.Log($"Checking achievement {achievement.achievementName}: {count}/{achievement.requiredCount}");

        if (count >= achievement.requiredCount)
        {
            achievement.unlocked = true;
            OnAchievementUnlocked(achievement);
        }
    }
    void OnAchievementUnlocked(RecipeAchievement achievement)
    {
        Debug.Log($"Achievement unlocked: {achievement.achievementName}!");
        ShowAchievementPopup(achievement);

    }
    void ShowAchievementPopup(RecipeAchievement achievement)
    {
        if (achievement.achievementPopupPrefab == null || achievement.popupParent == null)
        {
            Debug.LogWarning("Popup prefab or popup parent not assigned!");
            return;
        }

        GameObject popupGO = Instantiate(achievement.achievementPopupPrefab, achievement.popupParent);
        AchievementPopup popup = popupGO.GetComponent<AchievementPopup>();

        if (popup != null)
        {
            popup.Setup();
        }
    }

}
