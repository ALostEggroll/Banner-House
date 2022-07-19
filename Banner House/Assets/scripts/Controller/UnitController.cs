using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   // For NavMesh

/*
 *  This class controls unit behavior in combat.
 *  It should be attached to every gameobject that can fight
 */
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CharacterStats))]
public class UnitController : MonoBehaviour
{
    private Transform currentTarget;    // Current targeted unit
    private NavMeshAgent agent;         // This unit
    private CharacterStats stats;       // This unit's stats

    [SerializeField]
    private CombatUnit unit;

    public Team team;

    private float attackCooldown;
    
    /*
     *  Setting this unit's team
     */
    public void SetTeam(Team t)
    {
        team = t;
    }

    // Start is called before the first frame update
    void Start()
    {
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

    /*
     *  The combat logic for the unit
     */
    private void Update()
    {
        // Regulates attack rate
        attackCooldown -= Time.deltaTime;
        
        // Searching for an enemy
        if (currentTarget == null)
        {
            SetCurrentTarget();
        }
        // Attacks if unit is close enough to the enemy and attack not in cooldown
        else if (CurrentDistance() <= agent.stoppingDistance && attackCooldown <= 0f)
        {
            //Debug.Log("Unit " + name + " is attacking " + currentTarget.name);
            // Gets reference to target's stats
            CharacterStats targetStats = currentTarget.GetComponent<CharacterStats>();

            // Crit damage calculation
            if (Random.Range(0, 100) < 33)
            {
                Debug.Log("Crit!");
                targetStats.TakeDamage(stats.attack * 2);
            }
            else
            {
                // Base attack damage
                targetStats.TakeDamage(stats.attack);
            }
            attackCooldown = 1f / stats.attackRate; // Resets attack cooldown
        }
        // Travels to enemy if not in attack range
        else
        {
            //Debug.Log("Unit " + name + " is moving to " + currentTarget.name);
            agent.SetDestination(currentTarget.position);
        }
    }

    /*
     *  Removing this unit from the list
     */
    private void OnDestroy()
    {
        CombatManager.Instance.RemoveUnit(this);
    }

    /*
     *  Sets target to closest enemy
     */
    private void SetCurrentTarget()
    {
        currentTarget = FindClosest(CombatManager.Instance.GetTeam(this));
    }


    // This function finds the closest enemy to this unit
    private Transform FindClosest(List<UnitController> enemy)
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

    /*
     * Calculates distance from enemy
     */
    private float CurrentDistance()
    {
        return Vector3.Distance(transform.position, currentTarget.transform.position);
    }
}
// Current defined teams
public enum Team {
        team1,
        team2,
    }