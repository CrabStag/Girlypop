using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTrans : MonoBehaviour
{
    public Transform targetScreen;
    public bool IsToShop = false;

    private void OnMouseUpAsButton()
    {
        ScreenTransition();
    }

    public void ScreenTransition()
    {
        Camera.main.transform.position = targetScreen.position;
        if(IsToShop)
        {
            PopoutCard.instance.CancelLinger();
        }
    }
}

