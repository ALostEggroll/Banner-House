using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    #region Singleton
    public static CombatManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] public GameObject[] allies;
    [SerializeField] public GameObject[] enemies;
}
