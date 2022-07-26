using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationButtons : MonoBehaviour
{
    public static GameObject currentScreen; // The current screen
    public Screens nextScreen;               // Screen in string to type which gameobject to move to
    
    // Transitions from current screen to next screen
    public void Clicked()
    {
        //Debug.Log("Button Clicked!");
        FadeToBlack.FadeIn(()=> {
            //Debug.Log("Screen is Black!");
            GameObject screenToActivate = StartScreen.screenNavigation[nextScreen];
            Debug.Log("From " + currentScreen + " To " + screenToActivate);
            currentScreen.SetActive(false);
            screenToActivate.SetActive(true);
            currentScreen = screenToActivate;
            FadeToBlack.FadeOut(); 
        });  //calling the FadeToBlack's method FadeIn
    }
    // Makes this button associated with the screen that it wants to travel to
    public void Start()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(Clicked);
    }
}
