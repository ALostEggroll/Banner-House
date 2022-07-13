using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class manages every character's stats
 */
public class CharacterStats : MonoBehaviour
{
    public CombatUnit CombatUnit;

    public int currentHealth { get; private set; }
    public int maxHealth;

    public int attack;
    public float attackRate;
    public float attackRadius;
    public int defense;

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

    public void TakeDamage(int damage)
    {
        damage -= defense;
        // Checking if attack did damage
        if (damage < 0)
            damage = 0;
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

    public void AddHealth(int heal)
    {
        currentHealth += heal;
        // Checking if health goes over max health
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        Debug.Log(transform.name + " healed for " + heal + " health");
    }
}
