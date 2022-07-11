using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] public List<CharacterCombatController> team1 = new List<CharacterCombatController>();
    [SerializeField] public List<CharacterCombatController> team2 = new List<CharacterCombatController>();

    /*
     * Sorts the NavMesh based on what team they're on
     */
    public void addUnit(CharacterCombatController unit)
    {
        switch (unit.team)
        {
            case team.team1:
                team1.Add(unit);
                break;
            case team.team2:
                team2.Add(unit);
                break;
        }
    }

    /*
     * Returns a list of the enemy
     */
    public List<CharacterCombatController> getEnemy(CharacterCombatController unit)
    {
        switch (unit.team)
        {
            case team.team1:
                return team2;
            case team.team2:
                return team1;
        }
        return null;
    }
}
