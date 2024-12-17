using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopoutCard : MonoBehaviour
{
    public float foldOutSpeed;

    public RectTransform canvas;
    public RectTransform backdrop;
    public Image cardImage;

    public static PopoutCard instance;
    public enum SideOfScreen
    {
        LEFT,
        BOTTOM,
        RIGHT,
        TOP
    };

    public SideOfScreen sideOfScreen;

    private GameObject menu;

    private Vector3 foldedInPos;
    private Vector3 foldedOutPos;

    public bool isFoldedIn = true;

    private void Start()
    {
        instance = this;
        SetupMenu();

    }

    private void Update()
    {
        if (isFoldedIn)
        {
            menu.transform.position = Vector3.Lerp(menu.transform.position, foldedOutPos, Time.deltaTime * foldOutSpeed);
        }
        else
        {
            menu.transform.position = Vector3.Lerp(menu.transform.position, foldedInPos, Time.deltaTime * foldOutSpeed);
        }

    }

    public void MoveMenu()
    {
        if (isFoldedIn)
        {
            isFoldedIn = false;
        }
        else
        {
            isFoldedIn = true;
        }

    }

    public void SetupMenu()
    {
        menu = gameObject;

        switch (sideOfScreen)
        {
            case SideOfScreen.LEFT:
                foldedInPos = new Vector3(0 - (backdrop.rect.width / 2), backdrop.position.y, backdrop.position.z);
                foldedOutPos = new Vector3(foldedInPos.x + (backdrop.rect.width * backdrop.localScale.x), foldedInPos.y, foldedInPos.z);

                break;
            case SideOfScreen.BOTTOM:
                foldedInPos = new Vector3(backdrop.position.x, 0 - (backdrop.rect.height / 2), backdrop.position.z);
                foldedOutPos = new Vector3(foldedInPos.x, foldedInPos.y + backdrop.rect.height, 0);

                break;
            case SideOfScreen.RIGHT:
                foldedInPos = new Vector3(canvas.rect.width + (backdrop.rect.width / 2), backdrop.position.y, backdrop.position.z);
                foldedOutPos = new Vector3(foldedInPos.x - (backdrop.rect.width * backdrop.localScale.x), foldedInPos.y, foldedInPos.z);

                break;
            case SideOfScreen.TOP:
                foldedInPos = new Vector3(backdrop.position.x, canvas.rect.height + (backdrop.rect.height / 2), 0);
                foldedOutPos = new Vector3(foldedInPos.x, foldedInPos.y - backdrop.rect.height, 0);

                break;
        }

        menu.transform.position = foldedInPos;
    }

}

