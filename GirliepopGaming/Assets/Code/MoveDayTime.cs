using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDayTime : MonoBehaviour
{
    [HideInInspector]
    public float startXPos = 2.5f;
    [HideInInspector]
    public float endYPos = -9.5f;

    [HideInInspector]
    public int customerAmount;

    public EndOfDayUIManager uiManager; 

    public Transform dayEndPos;
   

    public static MoveDayTime instance;

    [HideInInspector]
    public float stepAmount;

    private void Start()
    {
        instance = this;
        customerAmount = Random.Range(SpawnCustomers.Instance.minCustomers, SpawnCustomers.Instance.maxCustomers + 1);
        stepAmount = (endYPos - startXPos) / customerAmount;

    }

    public void MoveDay()
    {
        transform.position += new Vector3(stepAmount, 0, 0);
    }

    public void FinishDay()
    {
        Debug.Log("FinishDay() called");
        print("yay");

        if (dayEndPos == null)
            Debug.LogError("dayEndPos is null!");
        if (Camera.main == null)
            Debug.LogError("Camera.main is null!");
        if (uiManager == null)
            Debug.LogError("uiManager is null!");
        if (GameManager.Instance == null)
            Debug.LogError("GameManager.Instance is null!");

        Camera.main.transform.position = dayEndPos.position;

        Debug.Log("Mushroom Shop Unlocked? " + GameManager.Instance.mushroomShopUnlocked);
        if (GameManager.Instance.mushroomShopUnlocked)
        {
            uiManager.ShowShopBasement(); // show mushroom shop
        }
        else
        {
            uiManager.ShowNormalBasement(); // show normal end-of-day UI
        }
    }
}
