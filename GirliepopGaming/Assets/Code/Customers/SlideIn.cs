using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideIn : MonoBehaviour
{
    public float slideSpeed = 5;

    private Transform targetPos;
    private void Start()
    {
        targetPos = SpawnCustomers.Instance.customerLocations[Random.Range(0,
            SpawnCustomers.Instance.customerLocations.Count - 1)];

        SpawnCustomers.Instance.customerLocations.Remove(targetPos);
        
    }
    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Lerp(transform.position.x, targetPos.position.x, slideSpeed * Time.deltaTime);

        transform.position = pos;
    }
}
