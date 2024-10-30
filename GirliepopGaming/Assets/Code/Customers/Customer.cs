using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public string CustomerName;
    public SpriteRenderer image;

    public List<Order> possibleOrders = new List<Order>();
    public float slideSpeed = 5;

    [HideInInspector]
    public Transform targetPos;
    private void Start()
    {
        targetPos = SpawnCustomers.Instance.customerLocations[Random.Range(0,
            SpawnCustomers.Instance.customerLocations.Count)];


    }
    private void Update()
    {
        if(transform.position.x != targetPos.position.x)
        {
            SlideToTarget();
        }

    }

    private void SlideToTarget()
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
}