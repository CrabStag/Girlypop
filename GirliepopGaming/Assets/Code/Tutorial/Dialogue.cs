using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textObject;
    public string[] lines;
    public float textSpeed;

    public UnityEvent executeOnFinish;

    private int index;

    private void Start()
    {
        textObject.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(textObject.text == lines[index])
            {
                NextLine();
            } else
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
        if(index < lines.Length - 1)
        {
            index++;
            textObject.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            executeOnFinish.Invoke();
            gameObject.SetActive(false);



        }
    }
}
