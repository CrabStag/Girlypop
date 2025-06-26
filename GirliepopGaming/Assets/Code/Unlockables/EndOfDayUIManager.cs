using UnityEngine;

public class EndOfDayUIManager : MonoBehaviour
{
    public GameObject startedBasement;
    public GameObject shopBasement;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))  // Press T to toggle UI for test
        {
            ShowShopBasement();
            Debug.Log("ShowShopBasement called");
        }
        if (Input.GetKeyDown(KeyCode.Y))  // Press Y to toggle UI for test
        {
            ShowNormalBasement();
            Debug.Log("ShowNormalBasement called");
        }
    }

    public void ShowNormalBasement()
    {
        startedBasement.SetActive(true);
        shopBasement.SetActive(false);
    }

    public void ShowShopBasement()
    {
        startedBasement.SetActive(false);
        shopBasement.SetActive(true);
    }
}
