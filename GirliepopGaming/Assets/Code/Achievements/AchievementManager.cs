using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Achievement
{
    public string id;            // unique key for the achievement
    [TextArea]
    public string title;         // display title
    [TextArea]
    public string description;  // description text
    public bool unlocked = false;
}

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;

    public List<Achievement> achievements = new List<Achievement>();

    public GameObject achievementPopupPrefab; // drag your popup prefab here in inspector
    public Transform popupParent; // usually a Canvas transform

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        // Optionally load saved achievements here
    }

    public void Unlock(string achievementId)
    {
        Achievement achievement = achievements.Find(a => a.id == achievementId);
        if (achievement != null && !achievement.unlocked)
        {
            achievement.unlocked = true;

            Debug.Log("Achievement unlocked: " + achievementId); //  Log this

            ShowAchievementPopup(achievement);
        }
        else
        {
            Debug.LogWarning("Achievement not found or already unlocked: " + achievementId); //  Log this
        }
    }
    void ShowAchievementPopup(Achievement achievement)
    {
        if (achievementPopupPrefab == null || popupParent == null)
        {
            Debug.LogWarning("Popup prefab or popup parent not assigned!");
            return;
        }

        GameObject popupGO = Instantiate(achievementPopupPrefab, popupParent);
        AchievementPopup popup = popupGO.GetComponent<AchievementPopup>();

        if (popup != null)
        {
            popup.Setup();  // <-- call parameterless Setup
        }
    }
    public bool IsAchievementUnlocked(string achievementId)
    {
        Achievement achievement = achievements.Find(a => a.id == achievementId);
        if (achievement != null)
        {
            return achievement.unlocked;
        }
        return false;
    }
}

