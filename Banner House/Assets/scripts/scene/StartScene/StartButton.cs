using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    //void is a fcn that doesn't return anything....like return 0.
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked()
    {
        //Debug.Log("Button Clicked!");
        FadeToBlack.FadeIn(()=> {
            Debug.Log("Screen is Black!");
            FadeToBlack.FadeOut(); 
        });  //calling the FadeToBlack's method FadeIn
        
    }
}
