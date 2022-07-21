using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationButtons : MonoBehaviour
{
    public static GameObject currentScreen;
    public GameObject screenToActivate;
    public void Clicked()
    {
        //Debug.Log("Button Clicked!");
        FadeToBlack.FadeIn(()=> {
            Debug.Log("Screen is Black!");
            currentScreen.SetActive(false);
            screenToActivate.SetActive(true);
            currentScreen = screenToActivate;
            FadeToBlack.FadeOut(); 
        });  //calling the FadeToBlack's method FadeIn
    }
}
