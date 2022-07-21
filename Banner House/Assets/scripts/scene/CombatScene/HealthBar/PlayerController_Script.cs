// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerController_Script : MonoBehaviour
// {
//     public static PlayerController_Script instance;
//     public float Health;
//     public float MaxHealth;
//     public HealthBar_Script healthbar_script;

//     public void Start()
//     {
//         instance = this;
//         Health = MaxHealth;
//     }

//     // Start is called before the first frame update
//     public void TakeDamage()
//     {
//         Health -= Mathf.Min(Random.value, Health/4f);
//         healthbar_script.UpdateHealthBar();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Space))
//         {
//             TakeDamage();
//         }
//     }
// }