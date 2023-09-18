using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RideCymbalCollider : MonoBehaviour
{
    Vector3 changedSize, origSize;
    public ParticleSystem FireworksAll;
    public Transform particlePoint;
    // Start is called before the first frame update
    void Start()
    {
        origSize = new Vector3(0f, 0f, 0f);
        changedSize = new Vector3(334.368103f, 12.13762f, 333.564972f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            RideCymbal();
            OnScale();
            Explode();
        }

    }
    private void RideCymbal()
    {
        AudioManager.instance.PlaySound(AudioManager.SoundName.RideCymbal);
    }
    void Explode()
    {
        Instantiate(FireworksAll, particlePoint);
        FireworksAll.Play();
    }
    private void OnScale()
    {
        //var tween = transform.DORotate(changedSize, 0.09f).OnComplete(() => { transform.DORotate(origSize, 0.09f); });
        var tween = transform.DOShakeRotation(2f, 10, 10, 0, fadeOut: true, ShakeRandomnessMode.Harmonic).OnComplete(() => { transform.DORotate(origSize, 0.09f); }); ;

        if (tween.IsPlaying()) return;
        transform.DOKill();
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        XRGrabInteractable interactable = collision.gameObject.GetComponent<XRGrabInteractable>();
        if(interactable != null)
        {
            //RideCymbal();
            //OnScale();
            //Explode();

            Vector3 collisionForce = collision.impulse / Time.fixedDeltaTime;
            if (collisionForce.y >= 70)
            {
                RideCymbal();
                OnScale();
                Explode();

            }
        }
    
    }
}
