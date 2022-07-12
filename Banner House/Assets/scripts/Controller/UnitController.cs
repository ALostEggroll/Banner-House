using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * This class controls unit behavior in combat
 */
[RequireComponent(typeof(NavMeshAgent))]
public class UnitController : MonoBehaviour
{
    public Transform currentTarget;    // Current targeted unit
    public NavMeshAgent agent;         // This unit
    public CharacterStats stats;       // This unit's stats
    //[SerializeField] public team team { get; set; }

    public CombatUnit unit;

    void Start()
    {
        //attackRadius = unit.attackRadius;
        //agent.stoppingDistance = attackRadius;

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
    public Transform FindClosest(List<UnitController> enemy)
    {
        if (enemy == null || enemy.Count == 0)
        {
            Debug.Log("No unit detected in enemy team");
            return null;
        }

        Transform closestUnit = enemy[0].transform;
        float distance = Vector3.Distance(transform.position, closestUnit.position);
        foreach (UnitController c in enemy)
        {
            float temp = Vector3.Distance(transform.position, c.transform.position);
            if (temp < distance)
            {
                closestUnit = c.transform;
            }
        }
        Debug.Log("Unit " + name + " found " + closestUnit.name);
        return closestUnit;
    }

    public float CurrentDistance()
    {
        return Vector3.Distance(transform.position, currentTarget.transform.position);
    }

    public void UnitLogic()
    {
        if (currentTarget == null)
        {
            SetCurrentTarget();
        }
        else if (CurrentDistance() <= agent.stoppingDistance)
        {
            //Debug.Log("Unit " + name + " is attacking " + currentTarget.name);
            //Attack(currentTarget);
        }
        else
        {
            //Debug.Log("Unit " + name + " is moving to " + currentTarget.name);
            agent.SetDestination(currentTarget.position);
        }
    }

    public virtual void SetCurrentTarget()
    {
        
    }
    public void FirstLoad()
    {
        // Choosing this unit as agent
        agent = GetComponent<NavMeshAgent>();
        // Getting stats of this unit
        stats = GetComponent<CharacterStats>();

        stats.attackRadius = unit.attackRadius;
        agent.stoppingDistance = stats.attackRadius;

    }

    /*
     * Shows attack radius of character
     */
    /*
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stats.attackRadius);
    }
    */
}