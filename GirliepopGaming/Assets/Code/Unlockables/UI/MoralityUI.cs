using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MoralityUI : MonoBehaviour
{
    public static MoralityUI Instance;

    public TextMeshProUGUI moralityText;
    public Image moralityIcon;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        UpdateMoralityDisplay(SpawnCustomers.Instance.MoralityScore);
    }

    public void UpdateMoralityDisplay(int score)
    {
        moralityText.text = score.ToString();
    }
}
