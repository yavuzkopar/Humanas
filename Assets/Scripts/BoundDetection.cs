using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundDetection : MonoBehaviour
{
    
    void Update()
    {
        if(IsOutOfRange(transform.position))
        {
            //GameOver
        }
    }
    bool IsOutOfRange(Vector3 position)
    {
        return position.x >= 100 || position.x <= 0 || position.x < 0 || position.y < 0;
    }
}
