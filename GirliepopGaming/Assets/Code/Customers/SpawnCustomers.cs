using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnCustomers : MonoBehaviour
{
    public Order Slop;

    public static SpawnCustomers Instance;

    public List<GameObject> possibleCustomers;
    public List<Transform> customerLocations;
    public Transform startPos;


    public int minCustomers;
    public int maxCustomers;

    public DragDish dragDishObject;

    [HideInInspector]
    public Ingredient chosenHintIngredient;
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

    private int _moralityScore;


    public int MoralityScore
    {
        get { return _moralityScore; }
        set
        {
            _moralityScore = value;
            MoralityUI.Instance.UpdateMoralityDisplay(_moralityScore);
        }
    }

    private List<GameObject> remainingCustomersForDay = new List<GameObject>();

    private float currentIntervalTime;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            MoralityScore = Instance.MoralityScore;
            Destroy(Instance.gameObject);
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        currentIntervalTime = spawnInterval;
        audioSource = Camera.main.gameObject.transform.GetChild(1).GetComponent<AudioSource>();

        if (GameManager.Instance.IsMushroomGrown && !GameManager.Instance.mushroomShopUnlocked)
        {
            GameManager.Instance.mushroomShopUnlocked = true;
        }


    }



    private void Update()
    {
        if (!IsThisActive)
        {
            return;
        }

        SpawnCustomer();
    }

    private void SpawnCustomer()
    {

       

        if (isCustomerActive) return;

        // Clean up previous customer if any
        if (currentCustomer != null)
        {
            Destroy(currentCustomer.gameObject);
            currentCustomer = null;
            isCustomerActive = false;
        }

        if (isCustomerActive == false)
        {
            customerNameText.text = ""; // Clear old name BEFORE spawning new customer
            currentCustomer = Instantiate(possibleCustomers[Random.Range(0, possibleCustomers.Count)], startPos.position, Quaternion.identity).GetComponent<Customer>();
            dishDifficulty = Random.Range(0, 2);
            customerNameText.text = currentCustomer.CustomerName;  // Set name immediately after spawn

            switch (dishDifficulty)
            {
                case 0:
                    // Get unlocked ingredients
                    List<Ingredient> unlockedIngredients = GetUnlockedIngredients();

                    // Build a list of hintable ingredients the player actually has
                    List<Ingredient> availableHintIngredients = new List<Ingredient>();

                    // Define which ingredients are eligible for hint orders
                    List<Ingredient> hintableIngredients = new List<Ingredient>
{
    Ingredient.Milk,
    Ingredient.Caramel,
    Ingredient.Jam,
    Ingredient.LoveEssence,
    Ingredient.Choco,
    Ingredient.Fruits,
    Ingredient.Sugar,
    Ingredient.Mandrake,
    Ingredient.MixedNuts
};
                   
                        // Only keep the hintable ingredients the player has unlocked
                        foreach (Ingredient ingr in hintableIngredients)
                    {
                        if (unlockedIngredients.Contains(ingr))
                        {
                            availableHintIngredients.Add(ingr);
                        }
                    }

                    if (availableHintIngredients.Count == 0)
                    {
                        dishDifficulty = 1;
                    }
                    if (dishDifficulty == 1)
                    {
                        break;
                    }
                    else
                    {
                        Ingredient chosenIngredient = availableHintIngredients[Random.Range(0, availableHintIngredients.Count)];
                        chosenHintIngredient = chosenIngredient;


                        switch (chosenIngredient)
                        {
                            case Ingredient.Milk:
                                customerNameText.text = currentCustomer.CustomerName;
                                textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                                + " " + currentCustomer.milkHints[Random.Range(0, currentCustomer.milkHints.Length)];
                                break;
                            case Ingredient.Caramel:
                                customerNameText.text = currentCustomer.CustomerName;
                                textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                                + " " + currentCustomer.caramelHints[Random.Range(0, currentCustomer.caramelHints.Length)];
                                break;
                            case Ingredient.Jam:
                                customerNameText.text = currentCustomer.CustomerName;
                                textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                                + " " + currentCustomer.jamHints[Random.Range(0, currentCustomer.jamHints.Length)];
                                break;
                            case Ingredient.LoveEssence:
                                customerNameText.text = currentCustomer.CustomerName;
                                textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                                + " " + currentCustomer.loveEssenceHints[Random.Range(0, currentCustomer.loveEssenceHints.Length)];
                                break;

                            case Ingredient.Choco:
                                customerNameText.text = currentCustomer.CustomerName;
                                textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                                + " " + currentCustomer.chocolateHints[Random.Range(0, currentCustomer.chocolateHints.Length)];
                                break;
                            case Ingredient.Fruits:
                                customerNameText.text = currentCustomer.CustomerName;
                                textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                                + " " + currentCustomer.mixedFruitHints[Random.Range(0, currentCustomer.mixedFruitHints.Length)];
                                break;
                            case Ingredient.Sugar:
                                customerNameText.text = currentCustomer.CustomerName;
                                textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                                + " " + currentCustomer.sugarHints[Random.Range(0, currentCustomer.sugarHints.Length)];
                                break;
                            case Ingredient.Mandrake:
                                customerNameText.text = currentCustomer.CustomerName;
                                textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                                + " " + currentCustomer.mandrakeHints[Random.Range(0, currentCustomer.mandrakeHints.Length)];
                                break;
                            case Ingredient.MixedNuts:
                                customerNameText.text = currentCustomer.CustomerName;
                                textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                                + " " + currentCustomer.mixedNutsHints[Random.Range(0, currentCustomer.mixedNutsHints.Length)];
                                break;
                        }

                        break;
                    }
                case 1:
                    List<Order> availableOrders = GetOrdersWithUnlockedIngredients(currentCustomer);

                    if (availableOrders.Count == 0)
                    {
                        Debug.LogWarning("No available orders for current customer. Skipping spawn.");
                        dishDifficulty = 0;
                        // You can either call SpawnCustomer() again here or just return and let the next frame handle it
                        return;
                    }
                    else
                    {
                        currentOrder = availableOrders[Random.Range(0, availableOrders.Count)];

                        textBox.text = currentCustomer.PossibleGreetings[Random.Range(0, currentCustomer.PossibleGreetings.Length)]
                            + " " + currentOrder.NameOfOrder;
                    }
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
            bool isCorrect = dragDishObject.order.ingredient1 == chosenHintIngredient ||
                             dragDishObject.order.ingredient2 == chosenHintIngredient;

            if (isCorrect)
            {
                textBox.text = currentCustomer.GoodFeedback;
                audioSource.clip = happyCustomerSound;
                audioSource.volume = happyVolume;
                MoralityScore += 1;
                Debug.Log("Money.Instance is " + (Money.Instance == null ? "null" : "not null"));
                Money.Instance.AddMoney(5);
            }
            else
            {
                textBox.text = currentCustomer.BadFeedback;
                audioSource.clip = angryCustomerSound;
                audioSource.volume = angryVolume;
                MoralityScore -= 1;
                Debug.Log("Money.Instance is " + (Money.Instance == null ? "null" : "not null"));
                Money.Instance.SubtractMoney(2);
            }
        }

        if (dishDifficulty == 1)
        {
            if (dragDishObject.order == currentOrder)
            {
                textBox.text = currentCustomer.GoodFeedback;
                audioSource.clip = happyCustomerSound;
                audioSource.volume = happyVolume;
                MoralityScore += 1;
                Debug.Log("Money.Instance is " + (Money.Instance == null ? "null" : "not null"));
                Money.Instance.AddMoney(5);

            }

            if (dragDishObject.order != currentOrder)
            {
                textBox.text = currentCustomer.BadFeedback;
                audioSource.clip = angryCustomerSound;
                audioSource.volume = angryVolume;
                MoralityScore -= 1;
                Debug.Log("Money.Instance is " + (Money.Instance == null ? "null" : "not null"));
                Money.Instance.SubtractMoney(2);

            }
        }
        if (currentCustomer.CustomerName == "Ostara" &&
       (dragDishObject.order.ingredient1 == Ingredient.Mandrake || dragDishObject.order.ingredient2 == Ingredient.Mandrake))
        {
            AchievementManager.Instance.Unlock("Ostara_mandrake");
        }

        if (currentCustomer.CustomerName == "Alien Sana")
        {
            AchievementManager.Instance.Unlock("Sana_Alien");
        }

          if (currentCustomer.CustomerName == "PuddleFun" &&
         (dragDishObject.order.ingredient1 == Ingredient.UnicornMarrow || dragDishObject.order.ingredient2 == Ingredient.UnicornMarrow))
           {
             AchievementManager.Instance.Unlock("Pony_Racism");
                  }

        if (currentCustomer != null && currentOrder != null)
        {
            if (currentCustomer.CustomerName == "Sheep" && currentOrder.NameOfOrder == "Slop")
            {
                Debug.Log("Slop Gobbler achievement unlocked!");
                AchievementManager.Instance.Unlock("Slop_gobbler");
            }
        }
        else
        {
            Debug.LogWarning("JudgeOrder: currentCustomer or currentOrder is null!");
        }

        // Morality penalties based on forbidden ingredients
        if (dragDishObject.order != null)
        {
            if (dragDishObject.order.ingredient1 == Ingredient.Mandrake || dragDishObject.order.ingredient2 == Ingredient.Mandrake)
            {
                Debug.Log("Mandrake used! -2 Morality");
                MoralityScore -= 2;
            }

            if (dragDishObject.order.ingredient1 == Ingredient.UnicornMarrow || dragDishObject.order.ingredient2 == Ingredient.UnicornMarrow)
            {
                Debug.Log("Unicorn Marrow used! -3 Morality");
                MoralityScore -= 3;
            }
        }

        audioSource.Play();

        currentCustomer.canMove = false;
        StartCoroutine(WaitAndSlideOff());

        dragDishObject.image.sprite = null;
        dragDishObject.order = null;
        dragDishObject.transform.position = dragDishObject.startPos;

    }

    private List<Ingredient> GetUnlockedIngredients()
    {
        return PlayerInventory.Instance.GetUnlockedIngredients();
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

        if (finishedCustomers == MoveDayTime.instance.customerAmount)
        {
            print("day finished");
            MoveDayTime.instance.FinishDay();
            IsThisActive = false;
            gameObject.SetActive(false);
        }
    }
    private List<Order> GetOrdersWithUnlockedIngredients(Customer customer)
    {
        List<Ingredient> unlockedIngredients = GetUnlockedIngredients();
        List<Order> validOrders = new List<Order>();

        foreach (Order order in customer.possibleOrders)
        {
            // Check if both ingredients are unlocked
            bool ingredient1Unlocked = unlockedIngredients.Contains(order.ingredient1);
            bool ingredient2Unlocked = unlockedIngredients.Contains(order.ingredient2);

            if (ingredient1Unlocked && ingredient2Unlocked)
            {
                validOrders.Add(order);
            }
        }

        return validOrders;
    }




}



