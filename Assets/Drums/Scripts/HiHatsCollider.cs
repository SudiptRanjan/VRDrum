using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HiHatsCollider : MonoBehaviour
{
    Vector3 changedSize, origSize;
    public ParticleSystem FireworksAll;
    public Transform particlePoint;

    void Start()
    {
        origSize = new Vector3(0f, 0f, 0f);
        changedSize = new Vector3(12.1796303f, 359.373047f, 347.864624f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            HiHats();
            OnScale();
            Explode();
        }
    }
    private void HiHats()
    {
        AudioManager.instance.PlaySound(AudioManager.SoundName.HiHats);
    }

    void Explode()
    {
        Instantiate(FireworksAll, particlePoint);

        FireworksAll.Play();
    }
    private void OnScale()
    {
        var tween = transform.DOShakeRotation(3f, 12, 10, 0, fadeOut: true, ShakeRandomnessMode.Harmonic).OnComplete(() => { transform.DORotate(origSize, 0.09f); });

        //var tween = transform.DORotate(changedSize, 0.09f).OnComplete(() => { transform.DORotate(origSize, 0.09f); });
        if (tween.IsPlaying()) return;
        transform.DOKill();
    }

  

    private void OnCollisionEnter(Collision collision)
    {
       
        //HiHats();
        //OnScale();
        //Explode();

        float collisionForce =( collision.impulse / Time.fixedDeltaTime).magnitude;
        if (collisionForce >= 50)
        {
            HiHats();
            OnScale();
            Explode();

        }
    }
}

