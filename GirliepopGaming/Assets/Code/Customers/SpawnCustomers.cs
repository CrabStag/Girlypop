using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnCustomers : MonoBehaviour
{
    public static SpawnCustomers Instance;

    public List<GameObject> possibleCustomers;
    public List<Transform> customerLocations;
    public Transform startPos;

    public Customer currentCustomer;
    public Order currentOrder;
    public DragDish dragDishObject;

    public TextMeshPro textBox;


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

    public void JudgeOrder()
    {
        if(dragDishObject.order == currentOrder)
        {
            textBox.text = "yay yippie";
        }

        if(dragDishObject.order != currentOrder)
        {
            textBox.text = "kys";
        }

        currentCustomer.targetPos = startPos;
        StartCoroutine(currentCustomer.KYStimer(spawnInterval));
        dragDishObject.image.sprite = null;
        dragDishObject.order = null;
        dragDishObject.transform.position = dragDishObject.startPos;

    }

    private void SpawnCustomer()
    {
            if(isCustomerActive == false)
            {
                currentCustomer = Instantiate(possibleCustomers[Random.Range(0, possibleCustomers.Count)], startPos.position, Quaternion.identity).GetComponent<Customer>();
                currentOrder = currentCustomer.possibleOrders[Random.Range(0, currentCustomer.possibleOrders.Count)];

                textBox.text = currentOrder.name;

                isCustomerActive = true;
            }
            currentIntervalTime = spawnInterval;
        }
    }

