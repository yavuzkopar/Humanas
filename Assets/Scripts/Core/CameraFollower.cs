using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform followObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (followObject == null) return;
        transform.position = Vector3.Lerp(transform.position, followObject.transform.position, Time.deltaTime * 5f);
    }
}
