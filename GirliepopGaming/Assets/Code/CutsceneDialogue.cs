using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class CutsceneDialogue : MonoBehaviour
{
    public TextMeshProUGUI textObject;
    [HideInInspector]
    public string[] lines;
    [HideInInspector]
    public Sprite[] sprites;
    public float textSpeed;

    public UnityEvent executeOnFinish;

    private int index;
    private CutsceneLoader cutsceneLoader;


    private void Start()
    {
        cutsceneLoader = CutsceneLoader.instance;
        textObject.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textObject.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textObject.text = lines[index];

            }

        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    public IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textObject.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textObject.text = string.Empty;
            cutsceneLoader.characterSprite.sprite = sprites[index];
            cutsceneLoader.characterSprite.SetNativeSize();
            StartCoroutine(TypeLine());
        }
        else
        {
            textObject.text = string.Empty;
            index = 0;
            executeOnFinish.Invoke();
            //gameObject.SetActive(false);



        }
    }
}
