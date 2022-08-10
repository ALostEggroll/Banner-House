using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUIButtons : MonoBehaviour
{
    public void ReadyClicked()
    {
        Debug.Log("Combat started");
        CombatManager.Instance.combatStarted = true;
        CombatManager.Instance.combatPaused = false;
        CombatUI.instance.PopReady.SetActive(false);
        CombatUI.instance.PlayButton.SetActive(true);
    }

    public void PauseClicked()
    {
        Debug.Log("Combat paused");
        CombatManager.Instance.combatPaused = true;
        CombatUI.instance.PopPauseGame.SetActive(true);
    }

    public void ResumeClicked()
    {
        Debug.Log("Combat resumed");
        CombatManager.Instance.combatPaused = false;
        CombatUI.instance.PopPauseGame.SetActive(false);
    }
}
