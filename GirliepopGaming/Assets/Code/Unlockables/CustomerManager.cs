using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager Instance;

    public List<GameObject> allCustomers;
    public List<GameObject> availableCustomers = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            allCustomers = Instance.allCustomers;
            availableCustomers = Instance.availableCustomers;

            Destroy(Instance.gameObject);
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);

        SetCustomers();
    }



    public void AddCustomer(GameObject customer)
    {
        if (!availableCustomers.Contains(customer))
            availableCustomers.Add(customer);
    }

    public void RemoveCustomer(GameObject customer)
    {
        if (availableCustomers.Contains(customer))
            availableCustomers.Remove(customer);
    }

    public void SetCustomers()
    {
        availableCustomers.Clear();


        foreach (GameObject customer in allCustomers)
        {
            availableCustomers.Add(customer);
        }
    }
}
