using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Script : MonoBehaviour
{
    public Image healthBarBlue;

    // public float CurrentHealth;
    // public float MaxHealth;
    // public PlayerController_Script player;
    public UnitController unit; // unit in battlefield

    public void Start()
    {
        healthBarBlue = GetComponent<Image>();
        // player = FindObjectOfType<PlayerController_Script>();
    }


    public void Update()
    {
        // CurrentHealth = player.Health;
        healthBarBlue.fillAmount = Mathf.Clamp ((float)unit.stats.currentHealth/unit.stats.maxHealth, 0, 1f); // CurrentHealth / MaxHealth;
    }
}
