using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestButton : MonoBehaviour
{
    // Start is called before the first frame update
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
            GameObject.Find("StartScreen").SetActive(false);
            FadeToBlack.FadeOut(); 
        });  //calling the FadeToBlack's method FadeIn
    }
}
