using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * This class controls unit behavior in combat
 */
public class CharacterCombatController : MonoBehaviour
{
    [SerializeField] Transform currentTarget;    // Current targeted unit
    NavMeshAgent agent;         // This unit

    void Awake()
    {
        // Choosing this unit as agent
        agent = GetComponent<NavMeshAgent>();

        // Finding closest target and choose target
        //currentTarget = CombatManager.instance.enemy.transform;
    }

    void Update()
    {
        agent.SetDestination(currentTarget.position);
    }

    /*
    // This function finds the closest enemy to this unit
    Transform findclosest(GameObject enemy)
    {
        Transform closestUnit = null;
        float distance;
        foreach (GameObject obj in objects)
        {
            float temp = Vector3.Distance(obj.transform.position, transform.position);
            if (temp < distance)
                distance = temp;
        }
    }
    */
}