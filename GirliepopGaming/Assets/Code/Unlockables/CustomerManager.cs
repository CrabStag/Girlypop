using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager Instance;

    public List<Customer> allCustomers = new List<Customer>();
    public List<Customer> availableCustomers = new List<Customer>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    public void InitializeCustomerPool()
    {
        availableCustomers.Clear();

        // Fill availableCustomers with a fresh copy of allCustomers for the new day
        foreach (var customer in allCustomers)
        {
            availableCustomers.Add(customer);
        }
    }


    public void AddCustomer(Customer customer)
    {
        if (!availableCustomers.Contains(customer))
            availableCustomers.Add(customer);
    }

    public void RemoveCustomer(Customer customer)
    {
        if (availableCustomers.Contains(customer))
            availableCustomers.Remove(customer);
    }
}
