using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneLoader : MonoBehaviour
{
    public Cutscene[] allCutscenes;

    private SpawnCustomers spawnCustomers;

    private void Start()
    {
        spawnCustomers = SpawnCustomers.Instance;
        CheckCutsceneReqs();
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
                        //play cutscene
                        print("cutscene found:" + " " + scene.name);
                        return;
                    }
                    continue;
                }

                //play cutscene
                print("cutscene found:" + " " + scene.name);
                return;
            }

            if(spawnCustomers.badKarma >= scene.badKarmaReq && scene.badKarmaReq != 0)
            {
                //play cutscene
                print("cutscene found:" + " " + scene.name);
                return;
            }
        }
    }
}
