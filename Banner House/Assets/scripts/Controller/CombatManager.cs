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

    private List<UnitController> team1 = new List<UnitController>();
    private List<UnitController> team2 = new List<UnitController>();

    
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
