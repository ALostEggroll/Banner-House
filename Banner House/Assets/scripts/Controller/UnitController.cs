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

    public Team team;

    // Start is called before the first frame update
    void Start()
    {
        //FirstLoad();
        // Choosing this unit as agent
        agent = GetComponent<NavMeshAgent>();
        // Getting stats of this unit
        stats = GetComponent<CharacterStats>();
        unit = stats.CombatUnit;

        stats.attackRadius = unit.attackRadius;
        agent.stoppingDistance = stats.attackRadius;

        // Adding to CombatManager
        CombatManager.Instance.AddUnit(this);
    }
    private void Update()
    {
        //UnitLogic();
        if (currentTarget == null)
        {
            SetCurrentTarget();
        }
        else if (CurrentDistance() <= agent.stoppingDistance)
        {
            //Debug.Log("Unit " + name + " is attacking " + currentTarget.name);
            //Attack(currentTarget);
            CharacterStats targetStats = currentTarget.GetComponent<CharacterStats>();
            targetStats.TakeDamage(stats.attack);
        }
        else
        {
            //Debug.Log("Unit " + name + " is moving to " + currentTarget.name);
            agent.SetDestination(currentTarget.position);
        }
    }
    public void SetCurrentTarget()
    {
        // Finding closest target and choose target
        currentTarget = FindClosest(CombatManager.Instance.GetTeam(this));
    }
    private void OnDisable()
    {
        CombatManager.Instance.RemoveUnit(this);
    }

    // This function finds the closest enemy to this unit
    public Transform FindClosest(List<UnitController> enemy)
    {
        if (enemy == null || enemy.Count == 0)
        {
            //Debug.Log("No unit detected in enemy team");
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
}
public enum Team {
        team1,
        team2,
    }