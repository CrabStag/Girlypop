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
        if (AchievementManager.Instance.IsAchievementUnlocked(achievementId))
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
