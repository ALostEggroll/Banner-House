using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    #region Singleton
    private static CombatManager instance;
    public static CombatManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] public GameObject[] allies;
    [SerializeField] public GameObject[] enemies;
}
