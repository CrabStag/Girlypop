using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneLoader : MonoBehaviour
{
    public static CutsceneLoader instance;
    [Header("Put all available cutscenes here")]
    public List<Cutscene> allCutscenes;

    [Space(20)]

    public SpriteRenderer characterSprite;
    public CutsceneDialogue text;
    public Cutscene currentCutscene;

    private SpawnCustomers spawnCustomers;

    //private HashSet<Cutscene> playedCutscenes = new HashSet<Cutscene>();

    private void Awake()
    {
    }

    private void Start()
    {
        if (instance == null)  
        {
            instance = this;
        }
        else if (instance != this)
        {
            allCutscenes = instance.allCutscenes;
            Destroy(instance.gameObject);
            instance = this;
        }
        DontDestroyOnLoad(gameObject);

        spawnCustomers = SpawnCustomers.Instance;
        CheckCutsceneReqs();
        print("hiiii hewooooo");
    }

    public void CheckCutsceneReqs()
    {
        foreach (Cutscene scene in allCutscenes)
        {
            //if (scene.hasPlayed) continue;
            //if (playedCutscenes.Contains(scene)) continue;
            if (GameManager.Instance.playedCutscenes.Contains(scene)) continue;

            if (scene.moralityRequirement != 0)
            {
                if ((scene.moralityRequirement > 0 && spawnCustomers.MoralityScore >= scene.moralityRequirement) ||
                    (scene.moralityRequirement < 0 && spawnCustomers.MoralityScore <= scene.moralityRequirement))
                {
                    //scene.hasPlayed = true;
                    //playedCutscenes.Add(scene);
                    GameManager.Instance.playedCutscenes.Add(scene);
                    PlayCutscene(scene);
                    allCutscenes.Remove(scene);
                    print("cutscene found: " + scene.name);
                    return;
                }
            }
        }

        spawnCustomers.IsThisActive = true;
    }
    public void PlayCutscene(Cutscene cutscene)
    {
        currentCutscene = cutscene;

        if (cutscene.cutsceneSprites.Length != 0)
        {
            characterSprite.gameObject.SetActive(true);
            characterSprite.sprite = cutscene.cutsceneSprites[0];

            if (SpawnCustomers.Instance.currentCustomer != null)
            {
                characterSprite.transform.position = SpawnCustomers.Instance.currentCustomer.transform.position;
            }
        }

        text.gameObject.SetActive(true);
        text.lines = cutscene.cutsceneLines;
        text.sprites = cutscene.cutsceneSprites;
    }

    public void CloseCutscene()
    {
        print("end of cutscene");
        characterSprite.gameObject.SetActive(false);
        text.gameObject.SetActive(false);

        CheckCutsceneReqs();
    }
}
