using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUI : MonoBehaviour
{
    // References to popups
    public static GameObject PopReady;
    public static GameObject PopPauseGame;
    public static GameObject PopVictory;
    public static GameObject PopDefeat;
    public void Awake()
    {
        PopReady = GameObject.Find("PopReady");
        PopPauseGame = GameObject.Find("PopPauseGame");
        PopVictory = GameObject.Find("PopVictory");
        PopDefeat = GameObject.Find("PopDefeat");
    }
    public void OnEnable()
    {
        PopReady.SetActive(true);
        PopPauseGame.SetActive(false);
        PopVictory.SetActive(false);
        PopDefeat.SetActive(false);
    }
}
