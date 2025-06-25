using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public static Money Instance;

    public static int currentMoney = 0;
    public TextMeshProUGUI moneyText;  // Assign in inspector

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Money instance initialized");
        }
        else if (Instance != this)
        {
            Debug.Log("Duplicate Money instance destroyed");
            Destroy(gameObject);
            return;
        }
    }


    private void Start()
    {
        UpdateMoneyUI();
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyUI();
    }

    public void SubtractMoney(int amount)
    {
        currentMoney -= amount;
        UpdateMoneyUI();
    }

    private void UpdateMoneyUI()
    {
        if (moneyText != null)
        {
            moneyText.text = currentMoney.ToString();
        }
    }
}
