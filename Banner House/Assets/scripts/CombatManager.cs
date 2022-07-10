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

    [SerializeField] public GameObject ally;
    [SerializeField] public GameObject enemy;
}
