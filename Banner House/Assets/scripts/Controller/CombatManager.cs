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
    [SerializeField] private SpawnManager team1Spawner;
    // The Enemy team
    [SerializeField] private List<UnitController> team2 = new List<UnitController>();
    [SerializeField] private SpawnManager team2Spawner;
    public GameObject character;
    public GameObject otherCharacter;

    public bool combatStarted;
    public bool combatPaused;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            List<GameObject> allyObjects = new List<GameObject>();
            List<GameObject> enemyObjects = new List<GameObject>();
            Instantiate(character);
            allyObjects.Add(character);
            Instantiate(otherCharacter);
            enemyObjects.Add(otherCharacter);
            List<UnitController> allies = new List<UnitController>();
            List<UnitController> enemies = new List<UnitController>();
            foreach(GameObject ally in allyObjects)
                allies.Add(ally.GetComponent<UnitController>());
            foreach(GameObject enemy in enemyObjects)
                enemies.Add(enemy.GetComponent<UnitController>());
            InitializeTeams(allies, enemies);
            team1Spawner.SpawnTeam(allyObjects);
            team2Spawner.SpawnTeam(enemyObjects);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Combat Started");
            combatStarted = true;
        }
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
    public void InitializeTeams(List<UnitController> allies, List<UnitController> enemies)
    {
        InitializeTeam1(allies);
        InitializeTeam2(enemies);
    }
    public void InitializeTeam1(List<UnitController> allies)
    {
        Debug.Log("Initializing team1");
        team1 = allies;
        foreach (UnitController unit in team1)
        {
            unit.team = Team.team1;
        }
    }
    public void InitializeTeam2(List<UnitController> enemies)
    {
        Debug.Log("Initializing team2");
        team2 = enemies;
        foreach (UnitController unit in team2)
        {
            unit.team = Team.team2;
        }
    }
    public void StartCombat()
    {
        combatStarted = true;
    }

    public void StopCombat()
    {
        combatStarted = false;
    }

    public void ResumeCombat()
    {
        combatPaused = false;
    }

    public void PauseCombat()
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
