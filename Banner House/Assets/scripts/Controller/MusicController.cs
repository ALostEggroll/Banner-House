using System.ComponentModel;
using System.IO.MemoryMappedFiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    //creating the features for the audio clip container in the inspector
    public AudioClip combatMusic, endgameMusic, titleMusic;

    public static MusicController instance;

    public float targetVolume = 0f;

    AudioClip targetAudioClip;

    AudioSource audioSource; 

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if(targetAudioClip != audioSource.clip)
            targetVolume = 0;
        else 
            targetVolume=1; 

        if(audioSource.volume==0)
        {
             audioSource.clip = targetAudioClip;
             audioSource.Play();
        }
           
        //Mathf is a class  
        //Time is a class
        audioSource.volume = Mathf.MoveTowards(audioSource.volume, targetVolume, Time.deltaTime);

        //Test Temp
        if (Input.GetKeyDown(KeyCode.Q))
            PlayTitleMusic();
        if (Input.GetKeyDown(KeyCode.W))
            PlayCombatMusic();
        if (Input.GetKeyDown(KeyCode.E))
            PlayEndgameMusic();
    }

    public static void PlayTitleMusic()
    {
        instance.targetAudioClip = instance.titleMusic;

    }

    public static void PlayEndgameMusic()
    {
        instance.targetAudioClip = instance.endgameMusic;

    }

    public static void PlayCombatMusic()
    {
        instance.targetAudioClip = instance.combatMusic;

    }
}
