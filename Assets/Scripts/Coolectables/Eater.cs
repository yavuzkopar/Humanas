using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eater : MonoBehaviour
{
    public float eatingRange = 2f;
    public event Action OnFeeded;
    List<IEatable> eatableList = new List<IEatable>();
    public int currentlyEatingCount()
    {
        return eatableList.Count;
    }
  
    void Update()
    {
        for (float i = -eatingRange; i <= eatingRange; i++)
        {
            for (float j = -eatingRange; j <= eatingRange; j++)
            {
                if (WorldGrid.Instance.GetGridObject(transform.position + new Vector3(i, j, 0)) == null)
                    continue;
                GridObject gridObject = WorldGrid.Instance.GetGridObject(transform.position + new Vector3(i,j,0));
                if (gridObject.HasEatable())
                {
                    
                    if (!eatableList.Contains(gridObject.eatable))
                    {
                        if (Vector3.Distance(gridObject.eatable.Position(), transform.position) < eatingRange)
                        {
                            eatableList.Add(gridObject.eatable);
                            gridObject.eatable.Eat(this);
                        }
                    }
                }
                    
            }
        }
    }
    
    public void Feed(IEatable eatable)
    {
        OnFeeded?.Invoke();
        eatableList.Clear();
        
    }
   
}
