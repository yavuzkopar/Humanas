using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadFollower : MonoBehaviour
{
    private Transform parentTransform;
    void Start()
    {
        int siblingIndex = transform.GetSiblingIndex();
        parentTransform = transform.parent.GetChild(siblingIndex - 1);
        GetComponentInChildren<SpriteRenderer>().sortingOrder = -siblingIndex;
    }
    void Update()
    {
        if(parentTransform == null) return;
        transform.up = Vector3.Lerp(transform.up, (parentTransform.position - transform.position).normalized, Time.deltaTime * 3f);
        Vector3 targetPos = parentTransform.position - parentTransform.up;
      
        transform.position = targetPos;
    }
}
