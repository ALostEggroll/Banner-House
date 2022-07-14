using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    static FadeToBlack instance;  // singleton instance, private variable
    float targetAlpha = 0;        //controls the target transparency. Default = 0. 
    Image blackMask;
    public delegate void FadeToBlackAction();  // delegate or a  lambda expression where it takes no parameters and returns void.
    //then we keep track of this thru an instance variable called action. Encourages flexibility.
    static FadeToBlackAction action;    //

    // Start is called before the first frame update
    void Start()
    {
        instance = this; //setting the variable equals to itself, will behave as a static refrence to your object.
        blackMask = GetComponent<Image>();   //this method, GetComponent, grabs and gives you the component of the type.
    }

    // Update is called once per frame
    void Update()
    {
        Color color = blackMask.color;
        color.a = Mathf.MoveTowards(color.a, targetAlpha, Time.deltaTime * 1); //transitioning gradient from transparency to black
        blackMask.color = color;  //updating the color

        if (color.a ==1 && action != null)   //if we have an action and the screen is black,
        {
            action();  //run the action
            
            //getting rid of the action.
            action = null;
        }
    }

    //other classes would want to use this FadeToBlack
    public static void FadeIn(FadeToBlackAction act = null)
    {
        instance.targetAlpha = 1;   //targetAlpha isn't static so need to couple it with the instance static variable.

        //Thus, when we call FadeIn, we setting the static variable, action , of the delegate to the input parameter.
        action = act;

        
    }

    public static void FadeOut()
    {
        instance.targetAlpha = 0; 
    }
}
