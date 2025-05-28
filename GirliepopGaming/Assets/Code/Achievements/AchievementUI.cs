using UnityEngine;

public class AchievementUI : MonoBehaviour
{
    public static AchievementUI Instance;

    public GameObject menuPanel;

    private void Awake()
    {
        Instance = this;
        menuPanel.SetActive(false);
    }

    public void OpenMenu()
    {
        menuPanel.SetActive(true);
    }

    public void CloseMenu()
    {
        menuPanel.SetActive(false);
    }
}
