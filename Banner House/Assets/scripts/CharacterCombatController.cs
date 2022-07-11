using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * This class controls unit behavior in combat
 */
[RequireComponent(typeof(NavMeshAgent))]
public class CharacterCombatController : MonoBehaviour
{
    Transform currentTarget;    // Current targeted unit
    NavMeshAgent agent;         // This unit
    public team team { get; set; }

    void Awake()
    {
        // Choosing this unit as agent
        agent = GetComponent<NavMeshAgent>();

        // Adding to CombatManager
        CombatManager.Instance.addUnit(this);

        // Finding closest target and choose target
        currentTarget = CombatManager.Instance.getEnemy(this)[0].transform;
    }

    void Update()
    {
        agent.SetDestination(currentTarget.position);
    }

    // This function finds the closest enemy to this unit
    Transform findclosest(List<CharacterCombatController> enemy)
    {
        if (enemy == null)
        { 
            return null;
        }

        Transform closestUnit = enemy[0].transform;
        //float distance = Vector3.Distance(closestUnit);
        /*
        foreach (GameObject obj in objects)
        {
            float temp = Vector3.Distance(obj.transform.position, transform.position);
            if (temp < distance)
                distance = temp;
        }
        */
        return closestUnit;
    }
}
public enum team
{
    team1,
    team2,
}