using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * This class controls unit behavior in combat.
 * It should be attached to every gameobject that can fight
 */
[RequireComponent(typeof(NavMeshAgent))]
public class UnitController : MonoBehaviour
{
    private Transform currentTarget;    // Current targeted unit
    private NavMeshAgent agent;         // This unit
    private CharacterStats stats;       // This unit's stats

    [SerializeField]
    private CombatUnit unit;

    public Team team;

    private float attackCooldown;

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
    private void Update()
    {
        attackCooldown -= Time.deltaTime;
        if (currentTarget == null)
        {
            SetCurrentTarget();
        }
        else if (CurrentDistance() <= agent.stoppingDistance && attackCooldown <= 0f)
        {
            //Debug.Log("Unit " + name + " is attacking " + currentTarget.name);
            //Attack(currentTarget);
            CharacterStats targetStats = currentTarget.GetComponent<CharacterStats>();
            // Crit damage calculation
            if (Random.Range(0, 100) < 33)
            {
                Debug.Log("Crit!");
                targetStats.TakeDamage(stats.attack * 2);
            }
            else
            {
                targetStats.TakeDamage(stats.attack);
            }
            attackCooldown = 1f / stats.attackRate; // Regulates attack speed
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
    private void OnDestroy()
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

    public void SetTeam(Team t)
    {
        team = t;
    }
}
public enum Team {
        team1,
        team2,
    }