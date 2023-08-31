using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOfDrum : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            HighTom();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            MediumTom();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            FloorTom();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SnareDrum();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            BassDrum();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            HiHats();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            CrashCymbal();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            RideCymbal();
        }

    }

    private void HighTom()
    {
        AudioManager.instance.PlaySound(AudioManager.SoundName.HighTom);
    }

    private void MediumTom()
    {
        AudioManager.instance.PlaySound(AudioManager.SoundName.MediumTom);
    }

    private void FloorTom()
    {
        AudioManager.instance.PlaySound(AudioManager.SoundName.FloorTom);
    }

    private void SnareDrum()
    {
        AudioManager.instance.PlaySound(AudioManager.SoundName.SnareDrum);
    }

    private void BassDrum()
    {
        AudioManager.instance.PlaySound(AudioManager.SoundName.BassDrum);
    }

    private void HiHats()
    {
        AudioManager.instance.PlaySound(AudioManager.SoundName.HiHats);
    }

    private void CrashCymbal()
    {
        AudioManager.instance.PlaySound(AudioManager.SoundName.CrashCymbal);
    }

    private void RideCymbal()
    {
        AudioManager.instance.PlaySound(AudioManager.SoundName.RideCymbal);
    }


}
