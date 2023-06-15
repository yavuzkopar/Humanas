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
    // Start is called before the first frame update
    void Start()
    {
        GridObject gridObject = WorldGrid.Instance.GetGridObject(transform.position);
        gridObject.AddEatable(this);
        oldPos = gridObject;
        isEatening= false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isEatening && eater != null)
        {
            
            float goingSpeed = 10f;
            Vector3 direction = (eater.transform.position - transform.position).normalized;
            transform.position += direction * Time.deltaTime * goingSpeed;
            if (Vector3.Distance(transform.position, eater.transform.position) < 0.2f)
            {
                oldPos.RemoveEatable();
                nextPos = WorldGrid.Instance.emptyGrids[UnityEngine.Random.Range(0, WorldGrid.Instance.emptyGrids.Count)].GetWorldPosition();
                transform.position = nextPos;
                eater.Feed(this);
                isEatening = false;
                eater = null;
                WorldGrid.Instance.GetGridObject(transform.position).AddEatable(this);
            }
        }

    }
    public Vector3 Position()
    {
        return transform.position;
    }
}
