using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NavigationButtons.currentScreen = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
