using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetEater : MonoBehaviour, IEatable
{
    bool countDown;
    Eater eater1= null;
    public bool HasEater => false;
    float timer = 1;
    private void Start()
    {
        GridObject gridObject = WorldGrid.Instance.GetGridObject(transform.position);
        gridObject.AddEatable(this);
    }
    public void Eat(Eater eater)
    {
        if(!eater.GetComponentInParent<CharacterManager>().isAi)
        {
            eater1 = eater;
            eater1.eatingRange = 4;
           // Destroy(gameObject);
            WorldGrid.Instance.GetGridObject(transform.position).RemoveEatable();
            Vector3 nextPos = WorldGrid.Instance.emptyGrids[Random.Range(0, WorldGrid.Instance.emptyGrids.Count)].GetWorldPosition();
            WorldGrid.Instance.GetGridObject(nextPos).AddEatable(this);
            transform.position = nextPos;
            countDown = true;
            timer = 1;
        }
    }
    private void Update()
    {
        if(countDown)
        {
            timer -= Time.deltaTime;
            if(timer< 0)
            {
                eater1.eatingRange = 2;
                countDown = false;
                timer = 1;
            }
        }
    }

    public Vector3 Position()
    {
        return transform.position;
    }
}
