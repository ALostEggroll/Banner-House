using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  This class manages every character's stats
 *  Should be attached to a gameobject
 */
public class CharacterStats : MonoBehaviour
{
    //public CombatUnit CombatUnit;
    // Name and description of unit
    public new string name;
    public string description;
    // Character stats
    public int currentHealth;           // Health tracker
    public int maxHealth;               // The max health of the unit
    public int attack;                  // The attack power of the unit
    public float attackRate;            // The frequency of attack
    public float attackRadius;          // The max distance a unit can start attacking (defines stopping distance for NavMesh)
    public int defense;                 // The unit's resistance to attack
    public float attackSpeedModifier;   // Temporary change in attack frequency

    /*
    // Initializes the character with stats saved in CombatUnit
    private void Awake()
    {
        maxHealth = CombatUnit.maxHealth;
        currentHealth = maxHealth;
        attack = CombatUnit.attack;
        attackRate = CombatUnit.attackRate;
        attackRadius = CombatUnit.attackRadius;
        defense = CombatUnit.defense;
    }
    */

/*
 *  This method handles damage taken by this unit. Takes an int for damage taken
 */
    public void TakeDamage(int damage)
    {
        damage -= defense;
        // Checking if attack did damage
        if (damage < 0)
            damage = 1;
        Debug.Log(transform.name + " took " + damage + " damage");

        currentHealth -= damage;

        Debug.Log(transform.name + " now has " + currentHealth + " health");

        if (currentHealth <= 0)
        {
            // character is now dead
            Debug.Log(transform.name + " has died");
            Object.Destroy(gameObject);
        }
    }

/*
 *  This method handles healing for this unit. Takes an int for health received
 */
    public void AddHealth(int heal)
    {
        currentHealth += heal;
        // Checking if health goes over max health
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        Debug.Log(transform.name + " healed for " + heal + " health");
    }
}
