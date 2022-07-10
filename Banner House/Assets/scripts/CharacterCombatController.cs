using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * This class controls unit behavior in combat
 */
public class CharacterCombatController : MonoBehaviour
{
    Transform currentTarget;    // Current targeted unit
    NavMeshAgent agent;         // This unit

    // Start is called before the first frame update
    void Start()
    {
        // Choosing this unit as agent
        agent = GetComponent<NavMeshAgent>();

        // Finding closest target and choose target

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This function finds the closest enemy to this unit
    Transform findclosest()
    {

    }
}
