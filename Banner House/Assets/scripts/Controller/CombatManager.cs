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

    public List<UnitController> team1 = new List<UnitController>();
    public List<UnitController> team2 = new List<UnitController>();

}
