using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HiHatsCollider : MonoBehaviour
{
    Vector3 changedSize, origSize;
    public ParticleSystem FireworksAll;
    public Transform particlePoint;
    // Start is called before the first frame update
    void Start()
    {
        origSize = new Vector3(0f, 0f, 0f);
        changedSize = new Vector3(12.1796303f, 359.373047f, 347.864624f);
    }

    // Update is called once per frame
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

    //private void OnTriggerEnter(Collider other)
    //{
    //    HiHats();
    //    OnScale();
    //}

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided");
        //HiHats();
        //OnScale();
        //Explode();

        Vector3 collisionForce = collision.impulse / Time.fixedDeltaTime;
        if (collisionForce.y >= 70)
        {
            //Debug.Log("collision at y position= =" + collisionForce.y);
            HiHats();
            OnScale();
            Explode();

        }
        Debug.Log("the contact force is==" + collisionForce);
    }
}

