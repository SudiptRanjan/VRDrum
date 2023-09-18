using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SnareDrumCollider : MonoBehaviour
{
    Vector3 changedSize, origSize;
    public ParticleSystem FireworksAll;
    public Transform particlePoint;

    void Start()
    {
        origSize = new Vector3(1, 1, 0.903320014f);
        changedSize = new Vector3(0.888629973f, 1f, 0.810115457f);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SnareDrum();
            OnScale();
            Explode();
        }
    }
    private void SnareDrum()
    {
        AudioManager.instance.PlaySound(AudioManager.SoundName.SnareDrum);
    }
    void Explode()
    {
        Instantiate(FireworksAll, particlePoint);
        FireworksAll.Play();
    }
    private void OnScale()
    {
        //var tween = transform.DOScale(changedSize, 0.09f).OnComplete(() => { transform.DOScale(origSize, 0.09f); });
        var tween = transform.DOShakeRotation(0.1f, 4, 30, 0, fadeOut: true, ShakeRandomnessMode.Harmonic);
        if (tween.IsPlaying()) return;
        transform.DOKill();
    }


    private void OnCollisionEnter(Collision collision)
    {
        //SnareDrum();
        //OnScale();
        //Explode();

        Vector3 collisionForce = collision.impulse / Time.fixedDeltaTime;
        if (collisionForce.y >= 70)
        {
            SnareDrum();
            OnScale();
            Explode();

        }
    }
}
