using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *
 */
public class WarriorController : UnitController
{
    public override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.Q))
        {
            StatModifierManager.ApplyStrength(this, 5f, 5);
        }
    }
}
