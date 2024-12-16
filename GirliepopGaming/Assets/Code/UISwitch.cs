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
            foreach (GameObject element in UiToTurnOff)
            {
                element.SetActive(false);
            }
        }

        if (UiToTurnOn != null)
        {
            foreach (GameObject element in UiToTurnOn)
            {
                element.SetActive(true);
            }
        }
    }
}
