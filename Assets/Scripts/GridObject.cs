using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject 
{
    public int x;
    public int y;
    public IEatable eatable = null;
    public GridObject(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public void AddEatable(IEatable eatable)
    {
        if(!HasEatable())
            this.eatable= eatable;
    }
    public bool HasEatable()
    {
        return this.eatable != null;
    }
}
