using UnityEngine;

public class MushroomGrowthBar : MonoBehaviour
{
    public SpriteRenderer[] segments; // Array of SpriteRenderers (not UI Images)
    public Sprite grownMushroomSprite;
    public SpriteRenderer mushroomSpriteRenderer; // The mushroom sprite renderer
    public int maxProgress = 160;
    public int stepAmount = 20; // How much each segment represents

    private int growthProgress = 0;

    private void Start()
    {
        growthProgress = PlayerPrefs.GetInt("MushroomGrowthProgress", 0);
        UpdateBar();
        CheckCompletion();
    }

    public void AddProgress()
    {
        Debug.Log("Trying to add progress. Current money: " + Money.currentMoney);
        if (Money.currentMoney >= stepAmount && growthProgress < maxProgress)
        {
            Money.currentMoney -= stepAmount;
            Money.Instance.RefreshUI();
            growthProgress += stepAmount;
            PlayerPrefs.SetInt("MushroomGrowthProgress", growthProgress);
            UpdateBar();
            CheckCompletion();
        }
        else
        {
            Debug.Log("Not enough money or bar is full");
        }
    }

    private void UpdateBar()
    {
        int filledSegments = growthProgress / stepAmount;

        for (int i = 0; i < segments.Length; i++)
        {
            segments[i].enabled = i < filledSegments; // Enable or disable sprite renderers
        }
    }

    private void CheckCompletion()
    {
        if (growthProgress >= maxProgress)
        {
            mushroomSpriteRenderer.sprite = grownMushroomSprite;
            gameObject.SetActive(false);
            AchievementManager.Instance.Unlock("MushroomFullyGrown");
        }
    }
}
