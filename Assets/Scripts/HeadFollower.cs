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
        GetComponent<SpriteRenderer>().sortingOrder = -siblingIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, parentTransform.position) > 0.4f)
            transform.position = Vector3.Lerp(transform.position, parentTransform.position, Time.deltaTime *2);
    }
}
