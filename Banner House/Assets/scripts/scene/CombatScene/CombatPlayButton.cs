using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayButton : MonoBehaviour
{
    public void playCombat()
    {
        //CombatManager.combatStarted = true;
        Time.timeScale = 1f;
    }
}
