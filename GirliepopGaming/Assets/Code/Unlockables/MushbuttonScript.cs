using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushbuttonScript : MonoBehaviour
{
    public MushroomGrowthBar growthBar;

    private void OnMouseDown()
    {
        if (growthBar != null)
        {
            growthBar.AddProgress();
        }
    }
}
