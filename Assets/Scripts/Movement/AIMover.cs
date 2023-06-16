using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMover : MonoBehaviour
{
    float timer;
    Vector2 v;
    void Update()
    {
        Vector2 inputVector = v;
        transform.up = Vector3.Lerp(transform.up, inputVector, Time.deltaTime * 2);
        transform.position += transform.up * Time.deltaTime * 5f;
        //for (float j = 1; j < 3; j++)
        //{
        //    if (WorldGrid.Instance.GetGridObject(transform.position + (Vector3)inputVector * j) == null)
        //        continue;
        //    GridObject gridObject = WorldGrid.Instance.GetGridObject(transform.position + (Vector3)inputVector * j);
        //    if (IsHitted(gridObject))
        //    {
        //        v = Random.insideUnitCircle.normalized;
        //        return;
        //    }

        //}
        if (ChangeDirection(inputVector))
            return;




        timer += Time.deltaTime;
        if (timer > 1)
        {
            v = Random.insideUnitCircle.normalized;

            timer = 0;
        }

        
    }
    bool ChangeDirection(Vector3 inputVector)
    {
        for (float j = 1; j < 3; j++)
        {
            if (WorldGrid.Instance.GetGridObject(transform.position + inputVector * j) == null)
            { 
            v = Random.insideUnitCircle.normalized;
            return true;
            }
            GridObject gridObject = WorldGrid.Instance.GetGridObject(transform.position + inputVector * j);
            if (IsHitted(gridObject))
            {
                v = Random.insideUnitCircle.normalized;
                return true;
            }

        }
        return false;
    }
    bool IsHitted(GridObject currentGrid)
    {
        ICollideable[] onGridControllers = transform.root.GetComponentsInChildren<ICollideable>();
        foreach (var item in onGridControllers)
        {
            if (currentGrid.collideable == item)
            {
                return false;
            }
        }
        if (currentGrid.HasCollideable())
            return true;
        else
            return false;
    }
}
