using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  A class that holds references for every unit in the combat screen
 *  Units are separated into two teams
 */
public class CombatManager : MonoBehaviour
{
    #region Singleton
    private static CombatManager _instance;
    public static CombatManager Instance
    {
        get { return _instance; }
        private set { _instance = value; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(gameObject);
    }
    #endregion

    // The Player's team
    [SerializeField] private List<UnitController> team1 = new List<UnitController>();
    // The Enemy team
    [SerializeField] private List<UnitController> team2 = new List<UnitController>();

    public bool combatStarted;
    public bool combatPaused;

    public void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Combat Started");
            combatStarted = true;
            Time.timeScale = 1f;
        }
        */
        if (combatStarted && team1.Count == 0)
        {
            Debug.Log("Team 1 is defeated");
            combatStarted = false;
            combatPaused = true;
        }
        else if (combatStarted && team2.Count == 0)
        {
            Debug.Log("Team 2 is defeated");
            combatStarted = false;
            combatPaused = true;
        }
    }
    public void spawnTeams(Vector3 position)
    {
        foreach (UnitController unit in team1)
            unit.team = Team.team1;
        foreach (UnitController unit in team2)
            unit.team = Team.team2;
    }
    public void spawnTeams(Vector3 position, List<UnitController> allies, List<UnitController> enemies)
    {
        foreach (UnitController unit in team1)
            unit.team = Team.team1;
        foreach (UnitController unit in team2)
            unit.team = Team.team2;
    }
    public void startCombat()
    {
        combatStarted = true;
    }

    public void stopCombat()
    {
        combatStarted = false;
    }

    public void resumeCombat()
    {
        combatPaused = false;
    }

    public void pauseCombat()
    {
        combatPaused = true;
    }
    
/*
 *  Adds a unit to this class
 */
    public void AddUnit(UnitController unit)
    {
        switch (unit.team)
        {
            case Team.team1:
                team1.Add(unit);
                break;
            case Team.team2:
                team2.Add(unit);
                break;
        }
    }

/*
 *  Removes a unit from this class
 */
    public void RemoveUnit(UnitController unit)
    {
        switch (unit.team)
        {
            case Team.team1:
                team1.Remove(unit);
                break;
            case Team.team2:
                team2.Remove(unit);
                break;
        }
    }

/*
 *  Returns a list of enemies
 */
    public List<UnitController> GetTeam(UnitController unit)
    {
        switch (unit.team)
        {
            case Team.team1:
                return team2;
            case Team.team2:
                return team1;
        }
        return null;
    }
}
