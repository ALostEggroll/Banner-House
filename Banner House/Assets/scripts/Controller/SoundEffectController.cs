using System.Dynamic;
using System.ComponentModel.Design.Serialization;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectController : MonoBehaviour

{
    //creating a reference to an audio clip for button when pressed
    public AudioClip buttonClick;

    //static instance reference for this class
    public static SoundEffectController instance;

    public static void PlayButtonClick()
    {
        AudioSource.PlayClipAtPoint(instance.buttonClick, instance.transform.position);
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
}
