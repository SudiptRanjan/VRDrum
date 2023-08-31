using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FloorTomCollider : MonoBehaviour
{
    Vector3 changedSize, origSize;
    // Start is called before the first frame update
    void Start()
    {
        origSize = new Vector3(1, 1, 1);
        changedSize = new Vector3(0.927690029f, 1, 0.901049972f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FloorTom();
            OnScale();
        }
    }
    private void FloorTom()
    {
        AudioManager.instance.PlaySound(AudioManager.SoundName.FloorTom);
    }
    private void OnScale()
    {
        var tween = transform.DOScale(changedSize, 0.09f).OnComplete(() => { transform.DOScale(origSize, 0.09f); });
        if (tween.IsPlaying()) return;
        transform.DOKill();
    }
    private void OnTriggerEnter(Collider other)
    {
        FloorTom();
        OnScale();
    }
}
