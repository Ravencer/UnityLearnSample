using System.Collections;
using UnityEngine;

[HelpURL("https://docs.google.com/document/d/1RMamVxE-yUpSfsPD_dEa4-Ak1qu6NTo83qY1O4XLxUY/edit?usp=sharing")]
public class DestroyModule : MonoBehaviour
{
    private float destroyDelay;
    private int minimalDestroyingObjectsCount;

    [Header("Модуль")]
    [Tooltip("Debug")]
    public bool DebugCheck;
    [Min(1)]
    public int MinimalDestroying;
    [Min(1)]
    public float DestroyDelay;


    private Transform myTransform;

    private void Awake()
    {
        myTransform = transform;
        destroyDelay = DestroyDelay;
        minimalDestroyingObjectsCount = MinimalDestroying;
        if (DebugCheck){
            Debug.Log("I am alive!");
        }
        
    }

    [ContextMenu("Начать разрушение")]
    public void ActivateModule()
    {
        StartCoroutine(DestroyRandomChildObjectCoroutine());
    }

    private IEnumerator DestroyRandomChildObjectCoroutine()
    {
        while (myTransform.childCount > minimalDestroyingObjectsCount)
        {
            int index = Random.Range(0, myTransform.childCount - 1);
            Destroy(myTransform.GetChild(index).gameObject);
            yield return new WaitForSeconds(destroyDelay);
        }
        Destroy(gameObject, Time.deltaTime);
    }
}
