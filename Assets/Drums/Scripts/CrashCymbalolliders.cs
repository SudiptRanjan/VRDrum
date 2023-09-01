using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CrashCymbalolliders : MonoBehaviour
{
    Vector3 changedSize, origSize;
    public ParticleSystem FireworksAll;
    public Transform particlePoint;
    // Start is called before the first frame update
    void Start()
    {
        origSize = new Vector3(0, 0, 0);
        changedSize = new Vector3(2.78166983e-08f, -7.62285879e-08f, 21.170578f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            CrashCymbal();
            OnScale();
            Explode();
        }
    }

    private void CrashCymbal()
    {
        AudioManager.instance.PlaySound(AudioManager.SoundName.CrashCymbal);
    }

    void Explode()
    {
        Instantiate(FireworksAll, particlePoint);
        FireworksAll.Play();
    }
    private void OnScale()
    {
        //var tween = transform.DOScale(changedSize, 0.09f).OnComplete(() => { transform.DOScale(origSize, 0.09f); });
        var tween = transform.DOShakeRotation(3f, 10, 10, 0, fadeOut: true, ShakeRandomnessMode.Harmonic);
        if (tween.IsPlaying()) return;
        transform.DOKill();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    CrashCymbal();
    //    OnScale();
    //}

    private void OnCollisionEnter(Collision collision)
    {
        CrashCymbal();
        OnScale();
        Explode();
    }
}
