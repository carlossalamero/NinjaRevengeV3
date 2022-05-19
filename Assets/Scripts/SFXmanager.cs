
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXmanager : MonoBehaviour
{
    public AudioClip deathSFX;

    public AudioClip NinjadeathSFX;  

    public AudioClip levelSFX;  

    private AudioSource audio_source;

    void Awake()
    {

        audio_source = GetComponent<AudioSource>();

    }   

    public void DeathSound()
    {
        
        audio_source.PlayOneShot(deathSFX);

    }

    public void NinjaSound()
    {


        audio_source.PlayOneShot(NinjadeathSFX);

    }

    public void levelSound()
    {


        audio_source.PlayOneShot(levelSFX);

    }
}
