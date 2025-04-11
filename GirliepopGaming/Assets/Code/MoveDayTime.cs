using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDayTime : MonoBehaviour
{
    [HideInInspector]
    public float startXPos = 2.5f;
    [HideInInspector]
    public float endYPos = -9.5f;

    [HideInInspector]
    public int customerAmount;


    public Transform dayEndPos;
    public AudioSource musicSource;
    public AudioClip endOfDayMusic;

    public static MoveDayTime instance;

    [HideInInspector]
    public float stepAmount;

    private void Start()
    {
        instance = this;
        customerAmount = Random.Range(SpawnCustomers.Instance.minCustomers, SpawnCustomers.Instance.maxCustomers + 1);
        stepAmount = (endYPos - startXPos) / customerAmount;

    }

    public void MoveDay()
    {
        transform.position += new Vector3(stepAmount, 0, 0);
    }

    public void FinishDay()
    {
        print("yay");
        Camera.main.transform.position = dayEndPos.position;
        musicSource.clip = endOfDayMusic;
        musicSource.Play();
    }
}
