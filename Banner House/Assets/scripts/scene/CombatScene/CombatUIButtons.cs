using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUIButtons : MonoBehaviour
{
    public void ReadyClicked()
    {
        CombatManager.Instance.combatStarted = true;
        CombatManager.Instance.combatPaused = false;
        CombatUI.PopReady.SetActive(false);
    }

    public void PauseClicked()
    {
        CombatManager.Instance.combatPaused = true;
        CombatUI.PopPauseGame.SetActive(true);
    }

    public void ResumeClicked()
    {
        CombatManager.Instance.combatPaused = false;
        CombatUI.PopPauseGame.SetActive(false);
    }
}
