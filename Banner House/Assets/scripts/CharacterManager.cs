using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class manages every character's health
 */
public class CharacterManager : MonoBehaviour
{
    public CombatUnit CombatUnit;

    public int currentHealth { get; private set; }
    public int maxHealth;

    public int attack;
    public float attackRate;
    public int defense;

    // Initializes the character with stats saved in CombatUnit
    private void Awake()
    {
        maxHealth = CombatUnit.maxHealth;
        attack = CombatUnit.attack;
        attackRate = CombatUnit.attackRate;
        defense = CombatUnit.defense;
    }

    public void takeDamage(int damage)
    {
        damage -= defense;
        Debug.Log(transform.name + " took " + damage + " damage");
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            // character is now dead
        }
    }
}
