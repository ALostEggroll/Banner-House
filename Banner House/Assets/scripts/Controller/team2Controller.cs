using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class team2Controller : UnitController
{
    // Start is called before the first frame update
    void Start()
    {
        FirstLoad();
        // Adding to CombatManager
        CombatManager.Instance.team2.Add(this);
    }
    private void Update()
    {
        UnitLogic();
    }
    public override void SetCurrentTarget()
    {
        base.SetCurrentTarget();
        // Finding closest target and choose target
        currentTarget = FindClosest(CombatManager.Instance.team1);
    }
    private void OnDisable()
    {
        CombatManager.Instance.team2.Remove(this);
    }
}
