using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FloorTomCollider : MonoBehaviour
{
    public ParticleSystem FireworksAll;
    public Transform particlePoint;



    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FloorTom();
            OnScale();
            Explode();
        }
    }

    private void FloorTom()
    {
        AudioManager.instance.PlaySound(AudioManager.SoundName.FloorTom);
    }

    void Explode()
    {
        Instantiate(FireworksAll, particlePoint);
        FireworksAll.Play();
    }

    private void OnScale()
    {
        var tween = transform.DOShakeRotation(0.1f, 2, 30, 0, fadeOut: true, ShakeRandomnessMode.Harmonic);
        if (tween.IsPlaying()) return;
        transform.DOKill();
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        //FloorTom();
        //OnScale();
        //Explode();

        float collisionForce = (collision.impulse / Time.fixedDeltaTime).magnitude;
        if (collisionForce >= 50)
        {
            FloorTom();
            OnScale();
            Explode();
        }
       
    }
}
