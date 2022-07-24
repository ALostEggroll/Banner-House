using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  This class manages the UI navigation. To add a new screen, add it to the dictionary and enum
 *  and disable if not currently being used.
 */
public class StartScreen : MonoBehaviour
{
    // References to all screens that the player can access
    public static Dictionary<Screens, GameObject> screenNavigation;
    void Start()
    {
        // Initializes NavigationButtons with start screen
        NavigationButtons.currentScreen = gameObject;
        
        // Creating and adding screens to a dictionary for reference
        screenNavigation = new Dictionary<Screens, GameObject>();
        screenNavigation.Add(Screens.StartScreen, GameObject.Find("StartScreen"));

        screenNavigation.Add(Screens.HomeScreen, GameObject.Find("HomeScreen"));
        screenNavigation[Screens.HomeScreen].SetActive(false);

        screenNavigation.Add(Screens.QuestScreen, GameObject.Find("QuestScreen"));
        screenNavigation[Screens.QuestScreen].SetActive(false);

        screenNavigation.Add(Screens.ShopScreen, GameObject.Find("ShopScreen"));
        screenNavigation[Screens.ShopScreen].SetActive(false);

        screenNavigation.Add(Screens.CombatUI, GameObject.Find("CombatUI"));
        screenNavigation[Screens.CombatUI].SetActive(false);

        screenNavigation.Add(Screens.MatchSummary, GameObject.Find("MatchSummary"));
        screenNavigation[Screens.MatchSummary].SetActive(false);
    }
}
// Drop down reference to all screens
public enum Screens {StartScreen, HomeScreen, QuestScreen, ShopScreen, CombatUI, MatchSummary}