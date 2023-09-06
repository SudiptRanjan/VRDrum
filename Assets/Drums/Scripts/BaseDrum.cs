using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BaseDrum : MonoBehaviour
{
    Vector3 changedSize, origSize;
    //public ParticleSystem FireworksAll;
    //public Transform particlePoint;
    // Start is called before the first frame update
    void Start()
    {
        origSize = new Vector3(1.14999998f, 1.14999998f, 1.14999998f);
        changedSize = new Vector3(1.10933602f, 1.10933602f, 1.10933602f);
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetKeyDown(KeyCode.T))
            {
               BAseDrum();
                OnScale();
            }
        
    }

    private void BAseDrum()
    {
        AudioManager.instance.PlaySound(AudioManager.SoundName.BassDrum);
    }

    private void OnScale()
    {
        var tween = transform.DOScale(changedSize, 0.09f).OnComplete(() => { transform.DOScale(origSize, 0.09f); });

    }
    private void OnCollisionEnter(Collision collision)
    {
        BAseDrum();
        OnScale();
        //Explode();
    }
}
