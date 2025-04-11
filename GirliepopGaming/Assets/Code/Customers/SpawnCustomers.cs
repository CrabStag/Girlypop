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

    public int minCustomers;
    public int maxCustomers;

    public DragDish dragDishObject;

    [HideInInspector]
    public Customer currentCustomer;
    [HideInInspector]
    public Order currentOrder;
    [HideInInspector]
    public int finishedCustomers = 0;

    public TextMeshPro textBox;


    public bool isCustomerActive = false;

    [Range(1, 100)]
    public int spawnInterval = 5;

    public AudioClip happyCustomerSound;
    [Range(0, 100)]
    public float happyVolume = 100;
    public AudioClip angryCustomerSound;
    [Range(0, 100)]
    public float angryVolume = 100;

    private AudioSource audioSource;

    private int ingredientDecider;
    private int dishDifficulty;

    private float currentIntervalTime;

    private void Awake()
    {
        Instance = this;

    }

    private void Start()
    {
        currentIntervalTime = spawnInterval;
        audioSource = Camera.main.gameObject.transform.GetChild(1).GetComponent<AudioSource>();
    }

    private void Update()
    {
        SpawnCustomer();
    }

    public void JudgeOrder()
    {
        if (dishDifficulty == 0)
        {
            switch (ingredientDecider)
            {
                case 0:
                    if (dragDishObject.order.ingredient1 == Ingredient.Milk)
                    {
                        textBox.text = currentCustomer.GoodFeedback;
                        audioSource.clip = happyCustomerSound;
                        audioSource.volume = happyVolume;
                    }

                    if (dragDishObject.order.ingredient1 != Ingredient.Milk)
                    {
                        textBox.text = currentCustomer.BadFeedback;
                        audioSource.clip = angryCustomerSound;
                        audioSource.volume = angryVolume;
                    }
                    break;
                case 1:
                    if (dragDishObject.order.ingredient1 == Ingredient.Caramel)
                    {
                        textBox.text = currentCustomer.GoodFeedback;
                        audioSource.clip = happyCustomerSound;
                        audioSource.volume = happyVolume;
                    }

                    if (dragDishObject.order.ingredient1 != Ingredient.Caramel)
                    {
                        textBox.text = currentCustomer.BadFeedback;
                        audioSource.clip = angryCustomerSound;
                        audioSource.volume = angryVolume;
                    }
                    break;
                case 2:
                    if (dragDishObject.order.ingredient1 == Ingredient.Jam)
                    {
                        textBox.text = currentCustomer.GoodFeedback;
                        audioSource.clip = happyCustomerSound;
                        audioSource.volume = happyVolume;
                    }

                    if (dragDishObject.order.ingredient1 != Ingredient.Jam)
                    {
                        textBox.text = currentCustomer.BadFeedback;
                        audioSource.clip = angryCustomerSound;
                        audioSource.volume = angryVolume;
                    }
                    break;
                case 3:
                    if (dragDishObject.order.ingredient2 == Ingredient.Choco)
                    {
                        textBox.text = currentCustomer.GoodFeedback;
                        audioSource.clip = happyCustomerSound;
                        audioSource.volume = happyVolume;
                    }

                    if (dragDishObject.order.ingredient2 != Ingredient.Choco)
                    {
                        textBox.text = currentCustomer.BadFeedback;
                        audioSource.clip = angryCustomerSound;
                        audioSource.volume = angryVolume;
                    }
                    break;
                case 4:
                    if (dragDishObject.order.ingredient2 == Ingredient.Fruits)
                    {
                        textBox.text = currentCustomer.GoodFeedback;
                        audioSource.clip = happyCustomerSound;
                        audioSource.volume = happyVolume;
                    }

                    if (dragDishObject.order.ingredient2 != Ingredient.Fruits)
                    {
                        textBox.text = currentCustomer.BadFeedback;
                        audioSource.clip = angryCustomerSound;
                        audioSource.volume = angryVolume;
                    }
                    break;
                case 5:
                    if (dragDishObject.order.ingredient2 == Ingredient.Sugar)
                    {
                        textBox.text = currentCustomer.GoodFeedback;
                        audioSource.clip = happyCustomerSound;
                        audioSource.volume = happyVolume;
                    }

                    if (dragDishObject.order.ingredient2 != Ingredient.Sugar)
                    {
                        textBox.text = currentCustomer.BadFeedback;
                        audioSource.clip = angryCustomerSound;
                        audioSource.volume = angryVolume;
                    }
                    break;
            }
        }

        if (dishDifficulty == 1)
        {
            if (dragDishObject.order == currentOrder)
            {
                textBox.text = currentCustomer.GoodFeedback;
                audioSource.clip = happyCustomerSound;
                audioSource.volume = happyVolume;
            }

            if (dragDishObject.order != currentOrder)
            {
                textBox.text = currentCustomer.BadFeedback;
                audioSource.clip = angryCustomerSound;
                audioSource.volume = angryVolume;
            }
        }
        audioSource.Play(); // Play feedback sound

        currentCustomer.canMove = false; // Stop immediate movement
        StartCoroutine(WaitAndSlideOff()); // Start waiting before leaving

        // Reset drag dish object
        dragDishObject.image.sprite = null;
        dragDishObject.order = null;
        dragDishObject.transform.position = dragDishObject.startPos;

    }

    private void SpawnCustomer()
    {
        if (isCustomerActive == false)
        {
            currentCustomer = Instantiate(possibleCustomers[Random.Range(0, possibleCustomers.Count)], startPos.position, Quaternion.identity).GetComponent<Customer>();
            dishDifficulty = Random.Range(0, 2);

            switch (dishDifficulty)
            {
                case 0:
                    ingredientDecider = Random.Range(0, 6);

                    switch (ingredientDecider)
                    {
                        case 0:
                            textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                            + " " + currentCustomer.milkHints[Random.Range(0, currentCustomer.milkHints.Length)];
                            break;
                        case 1:
                            textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                            + " " + currentCustomer.caramelHints[Random.Range(0, currentCustomer.caramelHints.Length)];
                            break;
                        case 2:
                            textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                            + " " + currentCustomer.jamHints[Random.Range(0, currentCustomer.jamHints.Length)];
                            break;
                        case 3:
                            textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                            + " " + currentCustomer.chocolateHints[Random.Range(0, currentCustomer.chocolateHints.Length)];
                            break;
                        case 4:
                            textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                            + " " + currentCustomer.mixedFruitHints[Random.Range(0, currentCustomer.mixedFruitHints.Length)];
                            break;
                        case 5:
                            textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                            + " " + currentCustomer.sugarHints[Random.Range(0, currentCustomer.sugarHints.Length)];
                            break;
                    }

                    break;
                case 1:
                    currentOrder = currentCustomer.possibleOrders[Random.Range(0, currentCustomer.possibleOrders.Count)];

                    textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                        + " " + currentOrder.NameOfOrder;

                    break;
            }

            isCustomerActive = true;
        }
        currentIntervalTime = spawnInterval;
    }
    private IEnumerator WaitAndSlideOff()
    {
        yield return new WaitForSeconds(2f); // Wait before leaving

        currentCustomer.targetPos = startPos; // Set target position to exit
        currentCustomer.canMove = true; // Allow movement again

        yield return new WaitUntil(() => Vector3.Distance(currentCustomer.transform.position, startPos.position) < 0.1f);

        MoveDayTime.instance.MoveDay();
        finishedCustomers += 1;
        // Ensure exact position & destroy after moving
        currentCustomer.transform.position = startPos.position;
        StartCoroutine(currentCustomer.KYStimer(spawnInterval));

        if(finishedCustomers == MoveDayTime.instance.customerAmount)
        {
            print("day finished");
            MoveDayTime.instance.FinishDay();
            gameObject.SetActive(false);
        }
    }


}

