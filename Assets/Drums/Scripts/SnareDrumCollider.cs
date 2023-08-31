using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SnareDrumCollider : MonoBehaviour
{
    Vector3 changedSize, origSize;
    // Start is called before the first frame update
    void Start()
    {
        origSize = new Vector3(1, 1, 0.903320014f);
        changedSize = new Vector3(0.888629973f, 1f, 0.810115457f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SnareDrum();
            OnScale();
        }
    }
    private void SnareDrum()
    {
        AudioManager.instance.PlaySound(AudioManager.SoundName.SnareDrum);
    }
    private void OnScale()
    {
        //var tween = transform.DOScale(changedSize, 0.09f).OnComplete(() => { transform.DOScale(origSize, 0.09f); });
        var tween = transform.DOShakeRotation(0.1f, 4, 30, 0, fadeOut: true, ShakeRandomnessMode.Harmonic);
        if (tween.IsPlaying()) return;
        transform.DOKill();
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    SnareDrum();
    //    OnScale();
    //}
    private void OnCollisionEnter(Collision collision)
    {
        SnareDrum();
        OnScale();
    }
}
