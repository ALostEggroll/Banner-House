using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUIButtons : MonoBehaviour
{
    [SerializeField] private GameObject PopReady;
    [SerializeField] private GameObject PopPauseGame;
    [SerializeField] private GameObject PopVictory;
    [SerializeField] private GameObject PopDefeat;

    public void ReadyClicked()
    {
        CombatManager.Instance.combatStarted = true;
        CombatManager.Instance.combatPaused = false;
        PopReady.SetActive(false);
    }

    public void PauseClicked()
    {
        CombatManager.Instance.combatPaused = true;
        PopPauseGame.SetActive(true);
    }

    public void ResumeClicked()
    {
        CombatManager.Instance.combatPaused = false;
        PopPauseGame.SetActive(false);
    }
}
