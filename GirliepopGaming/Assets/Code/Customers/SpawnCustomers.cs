using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCustomers : MonoBehaviour
{
    public static SpawnCustomers Instance;

    public List<GameObject> possibleCustomers;
    public List<Transform> customerLocations;
    public Transform startPos;

    public Customer currentCustomer;

    public bool isCustomerActive = false;

    [Range(1, 100)]
    public int spawnInterval = 5;

    private float currentIntervalTime;

    private void Awake()
    {
        Instance = this;

    }

    private void Start()
    {
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
            if(isCustomerActive == false)
            {
                currentCustomer = Instantiate(possibleCustomers[Random.Range(0, possibleCustomers.Count - 1)], startPos.position, Quaternion.identity).GetComponent<Customer>();

                isCustomerActive = true;
            }
            currentIntervalTime = spawnInterval;
        } else
        {
            currentIntervalTime -= Time.deltaTime;
        }
    }
}
