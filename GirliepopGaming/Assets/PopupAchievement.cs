using UnityEngine;

public class AchievementAnimPopup : MonoBehaviour
{
    public GameObject achievementsMenuPanel;

    private Animator animator;
    private bool isClickable = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        gameObject.SetActive(false); // start hidden
    }

    public void ShowPopup()
    {
        gameObject.SetActive(true);
        animator.Play("PopupAppear", 0, 0f); // play from start
        isClickable = true;
    }

    private void OnMouseDown()
    {
        if (!isClickable) return;

        isClickable = false;
        gameObject.SetActive(false); // hide popup

        OpenAchievementMenu();
    }

    private void OpenAchievementMenu()
    {
        achievementsMenuPanel.SetActive(true);
    }
}
