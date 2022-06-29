using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    This is a sample class that can display the values of the different units in the game

    This class was made by Dexter Estrada (dexter.estrada99@gmail.com)
*/

public class CombatUnitDisplay : MonoBehaviour
{
    // The unit being referenced
    public CombatUnit unit;
    
    // The name and description of the unit
    public Text unitName;
    public Text description;

    // The artwork of the image
    public Image portrait;

    // The combat stats to display
    public Text currentHealth;
    public Text maxHealth;
    public Text attack;
    public Text attackRate;

    // Use this for initializaton
    void Start () 
    {
        unitName.text = unit.unitName;
        description.text = unit.description;

        portrait.sprite = unit.artwork;

        currentHealth.text = unit.currentHealth.ToString();
        maxHealth.text = unit.maxHealth.ToString();
        attack.text = unit.attack.ToString();
        attackRate.text = unit.attackRate.ToString();
    }
}
