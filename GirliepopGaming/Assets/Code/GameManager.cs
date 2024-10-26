using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Customer currentCustomer;

    private void Start()
    {
        instance = this;
    }


}
