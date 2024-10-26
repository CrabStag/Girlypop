using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCustomers : MonoBehaviour
{
    public static SpawnCustomers Instance;

    public List<Customer> possibleCustomers;
    public List<Transform> customerLocations;
    public Transform startPos;

    [Range(1, 100)]
    public int spawnInterval = 5;

    [HideInInspector]
    public int capacity;

    private float currentIntervalTime;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        capacity = customerLocations.Count;
        currentIntervalTime = spawnInterval;    
    }

    private void Update()
    {
        SpawnCustomer();
    }

    private void SpawnCustomer()
    {
        if(currentIntervalTime < 0)
        {
            if(customerLocations.Count > 0)
            {
                Customer currentCustomer = Instantiate(possibleCustomers[Random.Range(0, possibleCustomers.Count - 1)], startPos.position, Quaternion.identity);
                GameManager.instance.currentCustomer = currentCustomer;
            }
            currentIntervalTime = spawnInterval;
        } else
        {
            currentIntervalTime -= Time.deltaTime;
        }
    }
}
