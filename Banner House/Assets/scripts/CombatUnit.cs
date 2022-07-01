using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This is the class CombatUnit. It holds basic values used by all units
    To be used by both allies and enemies

    Class made by Dexter Estrada (dexter.estrada99@gmail.com)
*/
[CreateAssetMenu(fileName = "New Unit", menuName = "Units")]
public class CombatUnit : ScriptableObject
{
    // Name and description of unit
    public new string name;
    public string description;

    // Unit in-game sprite
    public Sprite sprite;
    // Unit artwork?
    public Sprite artwork;

    // Combat stats
    public int currentHealth;   // The current health of the unit
    public int maxHealth;       // The max health of the unit
    public int attack;          // The attack power of the unit
    public float attackRate;    // The frequency of attack
}
