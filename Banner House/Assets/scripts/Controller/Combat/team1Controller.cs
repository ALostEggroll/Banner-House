using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class team1Controller : CharacterCombatController
{
    // Start is called before the first frame update
    void Start()
    {
        // Choosing this unit as agent
        agent = GetComponent<NavMeshAgent>();

        // Adding to CombatManager
        CombatManager.Instance.team1.Add(this);
    }

    private void Update()
    {
        if (currentTarget == null)
        {
            // Finding closest target and choose target
            currentTarget = CombatManager.Instance.team2[0].transform;
        }
        else
        {
            agent.SetDestination(currentTarget.position);
        }
    }
}
