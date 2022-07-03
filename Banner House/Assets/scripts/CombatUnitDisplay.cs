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
    public Text unitClass;

    // The artwork of the image
    public Image portrait;

    // The combat stats to display
    public Text maxHealth;
    public Text attack;
    public Text attackRate;

    // Use this for initializaton
    void Start () 
    {
        unitName.text = unit.name;
        description.text = unit.description;
        unitClass.text = nameof(unit.classType);

        portrait.sprite = unit.artwork;

        maxHealth.text = unit.maxHealth.ToString();
        attack.text = unit.attack.ToString();
        attackRate.text = unit.attackRate.ToString();
    }
}
