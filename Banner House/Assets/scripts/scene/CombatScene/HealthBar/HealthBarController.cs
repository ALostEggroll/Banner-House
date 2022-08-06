//using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    //public Image healthBarBlue;

    //Changing from 'healthBarBlue' b/c added in a new sprite called HealthBarFill_Enemy
    // Transform : type -> transforming the scale of the health bar fill sprite
    public Transform healthBarFill;

    //Created options in the inspector under HealthBarController script
    public Sprite playerBackground, enemyBackground, playerFill, enemyFill;

    // public float CurrentHealth;
    // public float MaxHealth;
    // public PlayerController_Script player;

    //Class name = UnitController (also name of script)
    public UnitController unit; // unit in battlefield

    public void Start()
    {
        //healthBarBlue = GetComponent<Image>();
        // player = FindObjectOfType<PlayerController_Script>();
        transform.localRotation = Quaternion.identity;
    }


    public void Update()
    {
        // CurrentHealth = player.Health;
        float fillAmount = Mathf.Clamp ((float)unit.stats.currentHealth/unit.stats.maxHealth, 0, 1f); // CurrentHealth / MaxHealth;
        healthBarFill.localScale = new Vector3(fillAmount, 1, 1);    // using vector<x,y,z> components wrt scale values of health bar.

    }

    public void SetPlayerColors()
    {
        GetComponent<SpriteRenderer>().sprite = playerBackground; //background of the health bar
        healthBarFill.GetComponent<SpriteRenderer>().sprite = playerFill;  //ally's health bar fill
        
    }

    public void SetEnemyColors()
    {
        GetComponent<SpriteRenderer>().sprite = playerBackground;  //background of the healthbar
        healthBarFill.GetComponent<SpriteRenderer>().sprite = enemyFill; //enemy's health bar fill
    }

    // public static = global and don't need an instance reference
    //GameObject = return type (similar to 'void')
    //CreateHealthBar = name of the fcn
    // Unit = character, vector3 offset = position of the health bar wrt character
    public static GameObject CreateHealthBar(UnitController unit, Vector3 offset)
    {
        //create the health bar prefab:
        //Resources was a folder created in 'Prefabs', and created a prefab called 'HealthBar' within it.
        GameObject prefab=Resources.Load<GameObject>("HealthBar");

        //copy 'prefab' and place it in the scene.
        //instantiated 'prefab' to a variable = newHealthBar
        GameObject newHealthBar = GameObject.Instantiate<GameObject>(prefab);

        //transform = a default member variable of every mono behaviour. (all position, scaling ..etc. including parent)
        //transform is actually a component of the inspector. We don't need to 'Get it' b/c a universal component found in every game object.
        //newHealthBar.transform.parent = 'HealthBar' in the heirachy in 'TK's Awesome Sandbox scene '
        newHealthBar.transform.parent = unit.transform;

        //offsets the local position of the health bar....
        //the health bar will move wrt transform parent.
        newHealthBar.transform.localPosition = offset;

        //set the health bar to track the character (unit)
        newHealthBar.GetComponent<HealthBarController>().unit = unit;

        return newHealthBar;
    }



    public static GameObject CreateHealthBar(UnitController unit)
    {
        return CreateHealthBar(unit, Vector3.up * 5);
    }

}
