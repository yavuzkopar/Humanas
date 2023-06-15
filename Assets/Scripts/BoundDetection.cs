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
            Debug.Log("GameOver");
            CharacterSpawner.Instance.ReSpawn(GetComponentInParent<CharacterManager>());
        }
    }
    bool IsOutOfRange(Vector3 position)
    {
        return position.x >= 99 || position.x <= 1 || position.y >= 99 || position.y < 1;
    }
}
