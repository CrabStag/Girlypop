using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public string CustomerName;
    public SpriteRenderer image;

    public List<Order> possibleOrders = new List<Order>();
    public float slideSpeed = 5;

    [Header("Dialogue")]
    public string[] PossibleGreetings;

    [Header("Easy Hints Per Ingredient")]
    public string[] milkHints;
    public string[] jamHints;
    public string[] caramelHints;
    public string[] chocolateHints;
    public string[] sugarHints;
    public string[] mixedFruitHints;

    [Header("Feedback")]
    public string GoodFeedback;
    public string BadFeedback;

    [HideInInspector]
    public Transform targetPos;

    public bool canMove = true; // Ensure this is inside the class

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

    public void SlideToTarget()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Lerp(transform.position.x, targetPos.position.x, slideSpeed * Time.deltaTime);
        transform.position = pos;
    }

    public IEnumerator KYStimer(int interval)
    {
        yield return new WaitForSeconds(interval);
        SpawnCustomers.Instance.currentCustomer = null;
        SpawnCustomers.Instance.isCustomerActive = false;
        Destroy(gameObject);
    }
} // <-- Ensure the class ends properly here
