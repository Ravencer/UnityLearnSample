using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KucherukSampleScript : SampleScript
{
    [SerializeField]
    private Vector3 targetRotate;

    private Transform myTransform;


    [Min(0)]
    [SerializeField]
    private float rotateSpeed;
    private const float thresholdAnge = 3;

    private void Start()
    {
        myTransform = transform;
    }

    [ContextMenu("Start")]
    public override void Use()
    {
        StartCoroutine(RotateCoroutine(targetRotate));
    }

    private IEnumerator RotateCoroutine(Vector3 target)
    {
        var targetRotation = Quaternion.Euler(target);
        var valueQuaternion = Quaternion.Angle(transform.rotation, targetRotation);
        while (Quaternion.Angle(transform.rotation, targetRotation) >= thresholdAnge)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
            yield return null;
        }
        transform.rotation = targetRotation;
    }

 
    
    
}
