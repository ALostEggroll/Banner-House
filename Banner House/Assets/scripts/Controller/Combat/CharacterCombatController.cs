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
    public Transform currentTarget;    // Current targeted unit
    public NavMeshAgent agent;         // This unit
    //[SerializeField] public team team { get; set; }
    public float attackRadius;

    public CombatUnit unit;

    void Start()
    {
        attackRadius = unit.attackRadius;
        // Choosing this unit as agent
        //agent = GetComponent<NavMeshAgent>();

        /*
        // Adding to CombatManager
        CombatManager.Instance.addUnit(this);

        // Finding closest target and choose target
        currentTarget = CombatManager.Instance.getEnemy(this)[0].transform;
        */
    }

    void Update()
    {
        //agent.SetDestination(currentTarget.position);
    }

    // This function finds the closest enemy to this unit
    public Transform FindClosest(List<CharacterCombatController> enemy)
    {
        if (enemy == null || enemy.Count == 0)
        {
            Debug.Log("No unit detected in enemy team");
            return null;
        }

        Transform closestUnit = enemy[0].transform;
        float distance = Vector3.Distance(transform.position, closestUnit.position);
        foreach (CharacterCombatController c in enemy)
        {
            float temp = Vector3.Distance(transform.position, c.transform.position);
            if (temp < distance)
            {
                closestUnit = c.transform;
            }
        }
        Debug.Log("Unit " + name + " found " + closestUnit.name + " Following");
        return closestUnit;
    }

    /*
     * Shows attack radius of character
     */
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}