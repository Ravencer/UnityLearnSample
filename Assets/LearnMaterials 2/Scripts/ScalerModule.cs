using System.Collections;
using UnityEngine;

[HelpURL("https://docs.google.com/document/d/1rdTEVSrCcYOjqTJcFCHj46RvnbdJhmQUb3gHMDhVftI/edit?usp=sharing")]
public class ScalerModule : MonoBehaviour
{
    private Vector3 targetScale = new Vector3(2,2,2);

    private float changeSpeed;

    private Vector3 defaultScale;
    private Transform myTransform;
    private bool toDefault;

    [Header("Module")]
    public bool DebugCheck = false;
    public Vector3 TargetScale = new Vector3(0,0,0);
    [Min(1)]
    [SerializeField]
    public float ChangeSpeed = 1;

    private void Start()
    {
        myTransform = transform;
        defaultScale = myTransform.localScale;
        toDefault = false;
    }

    [ContextMenu("Start increase")]
    public void ActivateModule()
    {
        Vector3 target = toDefault ? defaultScale : targetScale;
        StopAllCoroutines();
        StartCoroutine(ScaleCoroutine(target));
        toDefault = !toDefault;
    }

    public void ReturnToDefaultState()
    {
        toDefault = true;
        ActivateModule();
    }

    private IEnumerator ScaleCoroutine(Vector3 target)
    {
        Vector3 start = myTransform.lossyScale;
        float t = 0;
        while(t < 1)
        {
            t += Time.deltaTime * changeSpeed;
            myTransform.localScale = Vector3.Lerp(start, target, t);
            yield return null;
        }
        myTransform.localScale = target;
    }
}
