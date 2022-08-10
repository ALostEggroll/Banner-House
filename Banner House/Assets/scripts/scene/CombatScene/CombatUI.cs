using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUI : MonoBehaviour
{
    public static CombatUI instance;
    // References to popups
    public GameObject PopReady;
    public GameObject PopPauseGame;
    public GameObject PopVictory;
    public GameObject PopDefeat;
    public GameObject PlayButton;
    public void Start()
    {
        instance = this;
        /*
        PopReady = GameObject.Find("PopReady");
        PopPauseGame = GameObject.Find("PopPauseGame");
        PopVictory = GameObject.Find("PopVictory");
        PopDefeat = GameObject.Find("PopDefeat");
        PlayButton = GameObject.Find("PlayButton");
        */
    }
    public void OnEnable()
    {
        PopReady.SetActive(true);
        PopPauseGame.SetActive(false);
        PopVictory.SetActive(false);
        PopDefeat.SetActive(false);
        PlayButton.SetActive(false);
    }
}
