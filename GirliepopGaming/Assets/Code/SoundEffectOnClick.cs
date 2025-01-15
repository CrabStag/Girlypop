using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectOnClick : MonoBehaviour
{
    public AudioClip transitionSoundClip;

    [Range(0, 100)]
    public float volume = 100f;

    private AudioSource buttonSoundSource;

    private void Start()
    {
        buttonSoundSource = Camera.main.GetComponentInChildren<AudioSource>();
    }

    private void OnMouseUpAsButton()
    {
        PlaySound();
    }

    public void PlaySound()
    {
        buttonSoundSource.clip = transitionSoundClip;
        buttonSoundSource.volume = volume / 100;
        buttonSoundSource.Play();
    }
}
