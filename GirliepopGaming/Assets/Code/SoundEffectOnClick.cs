using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectOnClick : MonoBehaviour
{
    public AudioClip soundClip;

    [Range(0, 100)]
    public float volume = 100f;

    [Header("Index number for finding audio source. Leave at 0 for main one")]
    public int childIndex = 0;

    private AudioSource buttonSoundSource;

    private void Start()
    {
        buttonSoundSource = Camera.main.gameObject.transform.GetChild(childIndex).GetComponent<AudioSource>();
    }

    private void OnMouseUpAsButton()
    {
        PlaySound();
    }

    public void PlaySound()
    {
        buttonSoundSource.clip = soundClip;
        buttonSoundSource.volume = volume / 100;
        buttonSoundSource.Play();
    }
}
