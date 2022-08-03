using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestButtons : NavigationButtons
{
    public override void Clicked()
    {
        //Debug.Log("Button Clicked!");
        FadeToBlack.FadeIn(()=> {
            //Debug.Log("Screen is Black!");
            GameObject screenToActivate = StartScreen.screenNavigation[nextScreen];
            Debug.Log("From " + currentScreen + " To " + screenToActivate);
            currentScreen.SetActive(false);
            screenToActivate.SetActive(true);
            currentScreen = screenToActivate;
            CombatManager.Instance.SpawnUnits();
            FadeToBlack.FadeOut(); 
        });  //calling the FadeToBlack's method FadeIn
    }
}
