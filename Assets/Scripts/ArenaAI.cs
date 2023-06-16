using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaAI : MonoBehaviour
{
    float timer;
    ArenaCharacter arenaCharacter;
    float canShootTime = 3;
    void Start()
    {
        arenaCharacter= GetComponent<ArenaCharacter>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < canShootTime) return;
        Vector3 inputVector = transform.GetChild(1).up;
        for (float j = 1; j < 10; j++)
        {
            if (WorldGrid.Instance.GetGridObject(transform.position + inputVector * j) == null)
                continue;
            GridObject gridObject = WorldGrid.Instance.GetGridObject(transform.position + inputVector * j);
            if(gridObject.collideable != null)
            {
                arenaCharacter.Shoot();
                timer= 0;
            }
        }
        
    }
}
