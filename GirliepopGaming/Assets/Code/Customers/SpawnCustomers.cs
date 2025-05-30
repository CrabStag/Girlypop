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
    public TextMeshPro customerNameText;
    public GameObject textBoxImage;

    public bool IsThisActive = false;
    public bool isCustomerActive = false;

    [Range(1, 100)]
    public int spawnInterval = 1;

    public AudioClip happyCustomerSound;
    [Range(0, 100)]
    public float happyVolume = 100;
    public AudioClip angryCustomerSound;
    [Range(0, 100)]
    public float angryVolume = 100;

    private AudioSource audioSource;

    private int ingredientDecider;
    private int dishDifficulty;

    public int goodKarma = 0;
    public int badKarma = 0;

    private float currentIntervalTime;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            goodKarma = Instance.goodKarma;
            badKarma = Instance.badKarma;
            Destroy(Instance.gameObject);
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        currentIntervalTime = spawnInterval;
        audioSource = Camera.main.gameObject.transform.GetChild(1).GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(!IsThisActive)
        {
            return;
        }

        SpawnCustomer();
    }

    private void SpawnCustomer()
    {
        if (isCustomerActive == false)
        {
            customerNameText.text = ""; // Clear old name BEFORE spawning new customer
            currentCustomer = Instantiate(possibleCustomers[Random.Range(0, possibleCustomers.Count)], startPos.position, Quaternion.identity).GetComponent<Customer>();
            dishDifficulty = Random.Range(0, 2);
            customerNameText.text = currentCustomer.CustomerName;  // Set name immediately after spawn

            switch (dishDifficulty)
            {
                case 0:
                    ingredientDecider = Random.Range(0, 9);

                    switch (ingredientDecider)
                    {
                        case 0:
                            customerNameText.text = currentCustomer.CustomerName;
                            textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                            + " " + currentCustomer.milkHints[Random.Range(0, currentCustomer.milkHints.Length)];
                            break;
                        case 1:
                            customerNameText.text = currentCustomer.CustomerName;
                            textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                            + " " + currentCustomer.caramelHints[Random.Range(0, currentCustomer.caramelHints.Length)];
                            break;
                        case 2:
                            customerNameText.text = currentCustomer.CustomerName;
                            textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                            + " " + currentCustomer.jamHints[Random.Range(0, currentCustomer.jamHints.Length)];
                            break;
                        case 3:
                            customerNameText.text = currentCustomer.CustomerName;
                            textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                            + " " + currentCustomer.loveEssenceHints[Random.Range(0, currentCustomer.loveEssenceHints.Length)];
                            break;

                        case 4:
                            customerNameText.text = currentCustomer.CustomerName;
                            textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                            + " " + currentCustomer.chocolateHints[Random.Range(0, currentCustomer.chocolateHints.Length)];
                            break;
                        case 5:
                            customerNameText.text = currentCustomer.CustomerName;
                            textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                            + " " + currentCustomer.mixedFruitHints[Random.Range(0, currentCustomer.mixedFruitHints.Length)];
                            break;
                        case 6:
                            customerNameText.text = currentCustomer.CustomerName;
                            textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                            + " " + currentCustomer.sugarHints[Random.Range(0, currentCustomer.sugarHints.Length)];
                            break;
                        case 7:
                            customerNameText.text = currentCustomer.CustomerName;
                            textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                            + " " + currentCustomer.mandrakeHints[Random.Range(0, currentCustomer.mandrakeHints.Length)];
                            break;
                        case 8:
                            customerNameText.text = currentCustomer.CustomerName;
                            textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                            + " " + currentCustomer.mixedNutsHints[Random.Range(0, currentCustomer.mixedNutsHints.Length)];
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
            textBoxImage.SetActive(true);
        }
        currentIntervalTime = spawnInterval;
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
                        goodKarma += 1;
                    }

                    if (dragDishObject.order.ingredient1 != Ingredient.Milk)
                    {
                        textBox.text = currentCustomer.BadFeedback;
                        audioSource.clip = angryCustomerSound;
                        audioSource.volume = angryVolume;
                        badKarma += 1;
                    }
                    break;
                case 1:
                    if (dragDishObject.order.ingredient1 == Ingredient.Caramel)
                    {
                        textBox.text = currentCustomer.GoodFeedback;
                        audioSource.clip = happyCustomerSound;
                        audioSource.volume = happyVolume;
                        goodKarma += 1;

                    }

                    if (dragDishObject.order.ingredient1 != Ingredient.Caramel)
                    {
                        textBox.text = currentCustomer.BadFeedback;
                        audioSource.clip = angryCustomerSound;
                        audioSource.volume = angryVolume;
                        badKarma += 1;

                    }
                    break;
                case 2:
                    if (dragDishObject.order.ingredient1 == Ingredient.Jam)
                    {
                        textBox.text = currentCustomer.GoodFeedback;
                        audioSource.clip = happyCustomerSound;
                        audioSource.volume = happyVolume;
                        goodKarma += 1;

                    }

                    if (dragDishObject.order.ingredient1 != Ingredient.Jam)
                    {
                        textBox.text = currentCustomer.BadFeedback;
                        audioSource.clip = angryCustomerSound;
                        audioSource.volume = angryVolume;
                        badKarma += 1;

                    }
                    break;
                case 3:
                    if (dragDishObject.order.ingredient2 == Ingredient.LoveEssence)
                    {
                        textBox.text = currentCustomer.GoodFeedback;
                        audioSource.clip = happyCustomerSound;
                        audioSource.volume = happyVolume;
                        goodKarma += 1;

                    }

                    if (dragDishObject.order.ingredient2 != Ingredient.LoveEssence)
                    {
                        textBox.text = currentCustomer.BadFeedback;
                        audioSource.clip = angryCustomerSound;
                        audioSource.volume = angryVolume;
                        badKarma += 1;

                    }
                    break;


                case 4:
                    if (dragDishObject.order.ingredient2 == Ingredient.Choco)
                    {
                        textBox.text = currentCustomer.GoodFeedback;
                        audioSource.clip = happyCustomerSound;
                        audioSource.volume = happyVolume;
                        goodKarma += 1;

                    }

                    if (dragDishObject.order.ingredient2 != Ingredient.Choco)
                    {
                        textBox.text = currentCustomer.BadFeedback;
                        audioSource.clip = angryCustomerSound;
                        audioSource.volume = angryVolume;
                        badKarma += 1;

                    }
                    break;
                case 5:
                    if (dragDishObject.order.ingredient2 == Ingredient.Fruits)
                    {
                        textBox.text = currentCustomer.GoodFeedback;
                        audioSource.clip = happyCustomerSound;
                        audioSource.volume = happyVolume;
                        goodKarma += 1;

                    }

                    if (dragDishObject.order.ingredient2 != Ingredient.Fruits)
                    {
                        textBox.text = currentCustomer.BadFeedback;
                        audioSource.clip = angryCustomerSound;
                        audioSource.volume = angryVolume;
                        badKarma += 1;

                    }
                    break;
                case 6:
                    if (dragDishObject.order.ingredient2 == Ingredient.Sugar)
                    {
                        textBox.text = currentCustomer.GoodFeedback;
                        audioSource.clip = happyCustomerSound;
                        audioSource.volume = happyVolume;
                        goodKarma += 1;

                    }

                    if (dragDishObject.order.ingredient2 != Ingredient.Sugar)
                    {
                        textBox.text = currentCustomer.BadFeedback;
                        audioSource.clip = angryCustomerSound;
                        audioSource.volume = angryVolume;
                        badKarma += 1;

                    }
                    break;
                case 7:
                    if (dragDishObject.order.ingredient2 == Ingredient.Mandrake)
                    {
                        textBox.text = currentCustomer.GoodFeedback;
                        audioSource.clip = happyCustomerSound;
                        audioSource.volume = happyVolume;
                        goodKarma += 1;

                    }

                    if (dragDishObject.order.ingredient2 != Ingredient.Mandrake)
                    {
                        textBox.text = currentCustomer.BadFeedback;
                        audioSource.clip = angryCustomerSound;
                        audioSource.volume = angryVolume;
                        badKarma += 1;

                    }
                    break;
                case 8:
                    if (dragDishObject.order.ingredient2 == Ingredient.MixedNuts)
                    {
                        textBox.text = currentCustomer.GoodFeedback;
                        audioSource.clip = happyCustomerSound;
                        audioSource.volume = happyVolume;
                        goodKarma += 1;

                    }

                    if (dragDishObject.order.ingredient2 != Ingredient.MixedNuts)
                    {
                        textBox.text = currentCustomer.BadFeedback;
                        audioSource.clip = angryCustomerSound;
                        audioSource.volume = angryVolume;
                        badKarma += 1;

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
                goodKarma += 1;

            }

            if (dragDishObject.order != currentOrder)
            {
                textBox.text = currentCustomer.BadFeedback;
                audioSource.clip = angryCustomerSound;
                audioSource.volume = angryVolume;
                badKarma += 1;

            }
        }
        audioSource.Play(); 

        currentCustomer.canMove = false; 
        StartCoroutine(WaitAndSlideOff()); 

        dragDishObject.image.sprite = null;
        dragDishObject.order = null;
        dragDishObject.transform.position = dragDishObject.startPos;

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
        // CLEAR TEXTBOXES HERE
        textBox.text = "";
        customerNameText.text = "";
        textBoxImage.SetActive(false);
        StartCoroutine(currentCustomer.KYStimer(3));

        if(finishedCustomers == MoveDayTime.instance.customerAmount)
        {
            print("day finished");
            MoveDayTime.instance.FinishDay();
            IsThisActive = false;
            gameObject.SetActive(false);
        }
    }


}

