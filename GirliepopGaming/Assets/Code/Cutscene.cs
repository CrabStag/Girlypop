using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Cutscene", order = 2)]
public class Cutscene : ScriptableObject
{
    [Header("Ensure each line and sprite are in the same corresponding position in array")]

    public string[] cutsceneLines;
    public Sprite[] cutsceneSprites;

    [Header("Set karma requirements for cutscene to pop up. Keep at 0 if not used for this cutscene")]

    public int goodKarmaReq = 0;
    public int badKarmaReq = 0;
}
