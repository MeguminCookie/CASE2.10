using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnShake(float duration, float strength)
    {
        DOTween.RewindAll();
        transform.DOShakePosition(duration, strength);
        transform.DOShakeRotation(duration, strength);
    }

   
}
