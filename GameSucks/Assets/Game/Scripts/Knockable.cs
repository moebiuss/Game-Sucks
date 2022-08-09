using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Knockable : MonoBehaviour
{
    [SerializeField] protected Vector3 FallAngle;
    [SerializeField] protected float FallSpeed;
    [SerializeField] protected Vector3 FallSpot;
    
    void Start()
    {

    }
    public void KnockedOver()
    {
        transform.DORotate(FallAngle, FallSpeed);
        if(FallSpot != Vector3.zero)
        transform.DOMove(FallSpot,FallSpeed);
        foreach (var item in GetComponentsInChildren<Rigidbody>())
        {
            item.isKinematic = false;
            item.AddForce(Vector3.up*10);
        }
    }
    void Update()
    {

    }
}
