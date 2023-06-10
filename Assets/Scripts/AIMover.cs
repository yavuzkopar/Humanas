using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = Random.insideUnitCircle.normalized;
        Vector2 inputVector = v;
        transform.up = Vector3.Lerp(transform.up, inputVector, Time.deltaTime);
        transform.position += transform.up * Time.deltaTime * 1f;
    }
}
