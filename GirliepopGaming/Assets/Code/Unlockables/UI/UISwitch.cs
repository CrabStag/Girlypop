using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwitch : MonoBehaviour
{
    public GameObject[] UiToTurnOff;
    public GameObject[] UiToTurnOn;

    private void OnMouseUpAsButton()
    {
        if (UiToTurnOff != null)
        {
            TurnOffUI();
        }

        if (UiToTurnOn != null)
        {
            TurnOnUI();
        }
    }

    public void TurnOffUI()
    {
        foreach (GameObject element in UiToTurnOff)
        {
            element.SetActive(false);
        }
    }

    public void TurnOnUI()
    {
        foreach (GameObject element in UiToTurnOn)
        {
            element.SetActive(true);
        }
    }
}
