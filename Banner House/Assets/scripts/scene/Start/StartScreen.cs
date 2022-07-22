using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public static Dictionary<Screens, GameObject> screenNavigation;
    // Start is called before the first frame update
    void Start()
    {
        NavigationButtons.currentScreen = gameObject;
        screenNavigation = new Dictionary<Screens, GameObject>();
        screenNavigation.Add(Screens.StartScreen, GameObject.Find("StartScreen"));

        screenNavigation.Add(Screens.HomeScreen, GameObject.Find("HomeScreen"));
        screenNavigation[Screens.HomeScreen].SetActive(false);

        screenNavigation.Add(Screens.QuestScreen, GameObject.Find("QuestScreen"));
        screenNavigation[Screens.QuestScreen].SetActive(false);

        screenNavigation.Add(Screens.ShopScreen, GameObject.Find("ShopScreen"));
        screenNavigation[Screens.ShopScreen].SetActive(false);
    }
}
public enum Screens {StartScreen, HomeScreen, QuestScreen, ShopScreen}