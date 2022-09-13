using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public static Currency instance;

    // The money the player holds
    public int currency {get; private set;}

    // Simple adder that adds currency to existing currency
    public void AddCurrency(int addCurrency)
    {
        currency += addCurrency;
    }

    // Simple subtractor that checks if there's not enough currency to spend
    public void SubtractCurrency(int subCurrency)
    {
        if ((currency - subCurrency) >= 0)
        {
            currency -= subCurrency;
        }
        else
        {
            // Warning for not enough currency
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        currency = 0;
    }
}
