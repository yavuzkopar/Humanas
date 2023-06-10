using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eater : MonoBehaviour
{
    [SerializeField] float eatingRange = 2f;
    public event Action OnFeeded;
    bool isEating;
    int currentlyComingFood;
    float timer;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // 2 pi r2
        for (float i = -eatingRange; i < eatingRange; i++)
        {
            for (float j = -eatingRange; j < eatingRange; j++)
            {
                GridObject gridObject = WorldGrid.Instance.GetGridObject(transform.position + new Vector3(i,j));
                if (gridObject.HasEatable())
                {
                    gridObject.eatable.Eat(this);
                    isEating = true;
                    currentlyComingFood++;
                }
                    
            }
        }
        
    }
    public void Feed()
    {
        currentlyComingFood = 0;
        OnFeeded?.Invoke();
    }
   
}
