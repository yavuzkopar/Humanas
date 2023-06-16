using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IEatable
{
    bool isEatening;
    Eater eater;
    GridObject oldPos;
    Vector3 nextPos;
    public void Eat(Eater eater)
    {
        isEatening= true;
        this.eater = eater;
        
    }
    void Start()
    {
        GridObject gridObject = WorldGrid.Instance.GetGridObject(transform.position);
        gridObject.AddEatable(this);
        oldPos = gridObject;
        isEatening= false;
    }
    void Update()
    {
        if(isEatening && eater != null)
        {
            GoToEater();
            if (Vector3.Distance(transform.position, eater.transform.position) < 0.2f)
            {
                ResetPosition();
                ClearEater();
            }
        }

    }

    private void GoToEater()
    {
        float goingSpeed = 10f;
        Vector3 direction = (eater.transform.position - transform.position).normalized;
        transform.position += direction * Time.deltaTime * goingSpeed;
    }

    private void ClearEater()
    {
        eater.Feed(this);
        isEatening = false;
        eater = null;
    }

    private void ResetPosition()
    {
        oldPos.RemoveEatable();
        nextPos = WorldGrid.Instance.emptyGrids[UnityEngine.Random.Range(0, WorldGrid.Instance.emptyGrids.Count)].GetWorldPosition();
        transform.position = nextPos;
        WorldGrid.Instance.GetGridObject(transform.position).AddEatable(this);
    }

    public Vector3 Position()
    {
        return transform.position;
    }
}
