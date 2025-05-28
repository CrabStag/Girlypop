using UnityEngine;
using TMPro;

public class AchievementPopup : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descText;

    public void Setup(string title, string description)
    {
        titleText.text = title;
        descText.text = description;
        gameObject.SetActive(true);
        Invoke("Hide", 3f); // Hide after 3 seconds
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
    public void OnClick()
    {
        AchievementUI.Instance.OpenMenu();  // Make sure you have a singleton AchievementUI
        Destroy(gameObject);  // Close the popup after clicking
    }
}

