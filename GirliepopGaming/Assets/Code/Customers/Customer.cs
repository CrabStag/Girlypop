using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Customer : MonoBehaviour
{
    public TextMeshPro customerNameText;
    public SpriteRenderer image;

    [Header("Sprites")]
    public Sprite defaultSprite;
    public Sprite angrySprite;
    private bool isAngry = false;

    public List<Order> possibleOrders = new List<Order>();
    public float slideSpeed = 5;

    [Header("Dialogue")]
    public string[] PossibleGreetings;
    public string CustomerName;

    [Header("Easy Hints Per Ingredient")]
    public string[] milkHints;
    public string[] jamHints;
    public string[] caramelHints;
    public string[] loveEssenceHints;

    public string[] chocolateHints;
    public string[] sugarHints;
    public string[] mixedFruitHints;
    public string[] mandrakeHints;
    public string[] mixedNutsHints;

    [Header("Feedback")]
    public string GoodFeedback;
    public string BadFeedback;

    [HideInInspector]
    public Transform targetPos;

    public bool canMove = true;

    private void OnEnable()
    {
        // Always reset to default sprite when the customer is (re)spawned
        image.sprite = defaultSprite;
        isAngry = false;
    }


    private void Start()
    {
        targetPos = SpawnCustomers.Instance.customerLocations[Random.Range(0,
            SpawnCustomers.Instance.customerLocations.Count)];
     
    }

    private void Update()
    {
        if (canMove && transform.position.x != targetPos.position.x)
        {
            SlideToTarget();
        }
    }

    public void SetAngry()
    {
        if (angrySprite != null)
        {
            image.sprite = angrySprite;
            isAngry = true;
        }
    }

    public void SlideToTarget()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Lerp(transform.position.x, targetPos.position.x, slideSpeed * Time.deltaTime);
        transform.position = pos;
    }

    public void ResetToDefaultSprite()
    {
        image.sprite = defaultSprite;
        isAngry = false;
    }

    public IEnumerator KYStimer(int interval)
    {
        yield return new WaitForSeconds(interval);
        SpawnCustomers.Instance.currentCustomer = null;
        SpawnCustomers.Instance.isCustomerActive = false;
        Destroy(gameObject);
    }
} 
