using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int mushroomGrowth = 0;
    public bool mushroomCutscenePlayed = false;

    public bool IsMushroomGrown = false;
    public bool mushroomShopUnlocked = false;

    public HashSet<Cutscene> playedCutscenes = new HashSet<Cutscene>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }
}