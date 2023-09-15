using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FloorTomCollider : MonoBehaviour
{
    //Vector3 changedSize, origSize;
    public ParticleSystem FireworksAll;
    public Transform particlePoint;
    // Start is called before the first frame update
    void Start()
    {
        //origSize = new Vector3(1, 1, 1);
        //changedSize = new Vector3(0.927690029f, 1, 0.901049972f);
    }

    // Update is called once per frame
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
    //private void OnTriggerEnter(Collider other)
    //{
    //    FloorTom();
    //    OnScale();
    //}

    private void OnCollisionEnter(Collision collision)
    {
        //FloorTom();
        //OnScale();
        //Explode();

        Vector3 collisionForce = collision.impulse / Time.fixedDeltaTime;
        if (collisionForce.y >= 50)
        {
            //Debug.Log("collision at y position= =" + collisionForce.y);
            FloorTom();
            OnScale();
            Explode();

        }
        Debug.Log("the contact force is==" + collisionForce);
    }
}
