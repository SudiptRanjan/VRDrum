using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HiHatsCollider : MonoBehaviour
{
    Vector3 changedSize, origSize;
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
        }
    }
    private void HiHats()
    {
        AudioManager.instance.PlaySound(AudioManager.SoundName.HiHats);
    }

    private void OnScale()
    {
        var tween = transform.DOShakeRotation(3f, 12, 10, 0, fadeOut: true, ShakeRandomnessMode.Harmonic);

        //var tween = transform.DORotate(changedSize, 0.09f).OnComplete(() => { transform.DORotate(origSize, 0.09f); });
        if (tween.IsPlaying()) return;
        transform.DOKill();
    }

    private void OnTriggerEnter(Collider other)
    {
        HiHats();
        OnScale();
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Collided");
    //    HiHats();
    //    OnScale();
    //}
}

