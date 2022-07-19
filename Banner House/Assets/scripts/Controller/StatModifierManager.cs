using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *
 */
public class StatModifierManager : MonoBehaviour
{
    private static StatModifierManager instance;
    /*
     *  Syncs duration to update method
     */
    IEnumerator ApplyModifierCR(StatModifier statModifier)
    {
        statModifier.onStart();
        // 
        for (float t = 0; t < statModifier.duration; t += Time.deltaTime)
            yield return null;
        statModifier.onEnd();
    }

    /*
     *  
     */
    public static Coroutine ApplyModifier(StatModifier statModifier)
    {
        Debug.Log(instance);
        return instance.StartCoroutine("ApplyModifierCR", statModifier);
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static Coroutine ApplyStrength(UnitController unit, float duration, int amount)
    {
        return ApplyModifier(
            new StatModifier(
                ()=>{
                    unit.stats.attack += amount;
                    Debug.Log("Attack buff applied");
                }, // Apply attack buff. TODO
                ()=>{
                    unit.stats.attack -= amount;
                    Debug.Log("Attack buff removed");
                }, // End attack buff
                duration
            )
        );
    }
}

/*
 *
 */
public class StatModifier
{
    //UnitController unit;
    public delegate void ModifyStats();
    public ModifyStats onStart, onEnd;
    public float duration;
    public StatModifier(ModifyStats onStart, ModifyStats onEnd, float duration)
    {
        //this.unit = unit;
        this.onStart = onStart;
        this.onEnd = onEnd;
        this.duration = duration;
    }
}