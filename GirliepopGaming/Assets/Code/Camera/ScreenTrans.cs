using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTrans : MonoBehaviour
{
    public Transform targetScreen;

    private void OnMouseUpAsButton()
    {
        Camera.main.transform.position = targetScreen.position;
    }
}

