using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioSource audioSource;

    public Sound[] clips;

    private void Awake()
    {


        instance = this;

    }
    public void PlaySound(SoundName name)
    {
        foreach (var item in clips)
        {
            if (item.name == name)
            {
                audioSource.PlayOneShot(item.clip);
                break;
            }
        }
    }

    [System.Serializable]
    public class Sound
    {
        public SoundName name;
        public AudioClip clip;
    }

    public enum SoundName
    {
        HighTom, MediumTom, FloorTom, SnareDrum, BassDrum, HiHats, CrashCymbal, RideCymbal,Stick
    }

   
}

//AudioManager.instance.PlaySound(AudioManager.SoundName.BounceBall);

//Vector3(-0.56099999, -0.0250000004, 0.442000002)