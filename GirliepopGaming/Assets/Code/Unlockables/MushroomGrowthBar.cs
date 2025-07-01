using UnityEngine;

public class MushroomGrowthBar : MonoBehaviour
{
    public SpriteRenderer[] segments; // Array of SpriteRenderers (not UI Images)
    public GameObject mushroomGrownOverlay;
    public SpriteRenderer mushroomSpriteRenderer; // The mushroom sprite renderer
    public int maxProgress = 160;
    public int stepAmount = 20; // How much each segment represents

    private int growthProgress = 0;
    public GameObject mushText;

    public Cutscene mushroomCutscene; //assignfield
    private bool hasPlayedCutscene = false;

    public AudioSource audioSource;   //assignfield     
    public Animator animator;           //assignfield   

    public static MushroomGrowthBar instance;

    private void Start()
    {
        growthProgress = GameManager.Instance.mushroomGrowth;
        hasPlayedCutscene = GameManager.Instance.mushroomCutscenePlayed;

        //growthProgress = PlayerPrefs.GetInt("MushroomGrowthProgress", 0);
        UpdateBar();
        CheckCompletion();

        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    public void AddProgress()
    {
        Debug.Log("Trying to add progress. Current money: " + Money.currentMoney);
        if (Money.currentMoney >= stepAmount && growthProgress < maxProgress)
        {
            Money.currentMoney -= stepAmount;
            Money.Instance.RefreshUI();
            growthProgress += stepAmount;
            //PlayerPrefs.SetInt("MushroomGrowthProgress", growthProgress);
            GameManager.Instance.mushroomGrowth = growthProgress;
            GameManager.Instance.mushroomCutscenePlayed = hasPlayedCutscene;
            UpdateBar();
            CheckCompletion();

            //sound
            if (audioSource != null)
                audioSource.Play();

            // Trigger animation
            if (animator != null)
            {
                animator.SetTrigger("AddSegment");
            }
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
        Debug.Log("Checking mushroom completion");
        if (growthProgress >= maxProgress && !hasPlayedCutscene)
        {
            Debug.Log("Mushroom is fully grown!");

            if (mushroomGrownOverlay != null)
            {
                mushroomGrownOverlay.SetActive(true);
            }
            else
            {
                Debug.LogWarning("MushroomGrownOverlay is not assigned!");
            }

            if (mushText != null)
            {
                mushText.SetActive(false);
            }
            else
            {
                Debug.LogWarning("MushText GameObject not assigned.");
            }

            if (AchievementManager.Instance != null)
            {
                AchievementManager.Instance.Unlock("MushroomFullyGrown");
            }
            else
            {
                Debug.LogWarning("AchievementManager.Instance is null!");
            }

            if (GameManager.Instance != null)
            {
                GameManager.Instance.IsMushroomGrown = true;  // gamemanager script flag
            }
            else
            {
                Debug.LogError("GameManager.Instance is null! Cannot set IsMushroomGrown flag.");
            }

            foreach (var segment in segments)
            {
                segment.gameObject.SetActive(false);
            }

            if (CutsceneLoader.instance != null && mushroomCutscene != null && !hasPlayedCutscene)
            {
                hasPlayedCutscene = true;
                GameManager.Instance.mushroomCutscenePlayed = true;

                CutsceneLoader.instance.PlayCutscene(mushroomCutscene);
            }
        }
    }


}
