using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneLoader : MonoBehaviour
{
    public static CutsceneLoader instance;
    [Header("Put all available cutscenes here")]
    public List<Cutscene> allCutscenes;

    [Space(20)]

    public GameObject fadeBlackground;
    public GameObject textbox;
    public Image characterSprite;
    public CutsceneDialogue text;

    private SpawnCustomers spawnCustomers;

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
            if(spawnCustomers.goodKarma >= scene.goodKarmaReq && scene.goodKarmaReq != 0)
            {
                if(scene.badKarmaReq != 0)
                {
                    if(spawnCustomers.badKarma >= scene.badKarmaReq)
                    {
                        PlayCutscene(scene);
                        allCutscenes.Remove(scene);
                        print("cutscene found:" + " " + scene.name);
                        return;
                    }
                    continue;
                }

                PlayCutscene(scene);
                allCutscenes.Remove(scene);
                print("cutscene found:" + " " + scene.name);
                return;
            }

            if(spawnCustomers.badKarma >= scene.badKarmaReq && scene.badKarmaReq != 0)
            {
                PlayCutscene(scene);
                allCutscenes.Remove(scene);
                print("cutscene found:" + " " + scene.name);
                return;
            }
        }
        spawnCustomers.IsThisActive = true;
    }

    public void PlayCutscene(Cutscene cutscene)
    {
        fadeBlackground.SetActive(true);
        textbox.SetActive(true);

        if(cutscene.cutsceneSprites.Length != 0)
        {
            characterSprite.gameObject.SetActive(true);
            characterSprite.sprite = cutscene.cutsceneSprites[0];
            characterSprite.SetNativeSize();
        }

        text.gameObject.SetActive(true);
        text.lines = cutscene.cutsceneLines;
        text.sprites = cutscene.cutsceneSprites;

    }

    public void CloseCutscene()
    {
        print("end of cutscene");
        fadeBlackground.SetActive(false);
        textbox.SetActive(false);
        characterSprite.gameObject.SetActive(false);
        text.gameObject.SetActive(false);

        CheckCutsceneReqs();
    }
}
