using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTrans : MonoBehaviour
{
    public Transform targetScreen;
    public AudioClip transitionSoundClip;
    public AudioSource buttonSoundSource;

    private void OnMouseUpAsButton()
    {
        Camera.main.transform.position = targetScreen.position;

        buttonSoundSource.clip = transitionSoundClip;
        buttonSoundSource.Play();
    }
}

