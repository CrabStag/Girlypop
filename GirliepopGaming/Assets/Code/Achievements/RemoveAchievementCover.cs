using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAchievementCover : MonoBehaviour
{
    public string achievementId;       // ID to match the achievement
    public GameObject coverUp;         // The grey overlay
    public GameObject nameTextObject;  // Optional: shows the achievement name

    private void Update()
    {
        bool isUnlocked = false;

        // Check AchievementManager first
        if (AchievementManager.Instance != null && AchievementManager.Instance.IsAchievementUnlocked(achievementId))
        {
            isUnlocked = true;
        }
        else
        {
            // Check RecipeAchievementTracker achievements
            if (RecipeAchievementTracker.Instance != null)
            {
                foreach (var recipeAchievement in RecipeAchievementTracker.Instance.achievementsToTrack)
                {
                    if (recipeAchievement.achievementId == achievementId && recipeAchievement.unlocked)
                    {
                        isUnlocked = true;
                        break;
                    }
                }
            }
        }

        if (isUnlocked)
        {
            RevealAchievement();
        }
    }

    public void RevealAchievement()
    {
        coverUp.SetActive(false);

        if (nameTextObject != null)
            nameTextObject.SetActive(true);
    }
}
