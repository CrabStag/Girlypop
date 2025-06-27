using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int mushroomGrowth = 0;
    public bool mushroomCutscenePlayed = false;

    public bool IsMushroomGrown = false;
    public bool mushroomShopUnlocked = false;


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