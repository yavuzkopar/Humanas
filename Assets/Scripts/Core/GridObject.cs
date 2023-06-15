using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GridObject:IEquatable<GridObject> 
{
    public int x;
    public int y;
    public IEatable eatable;
    public ICollideable collideable;
    bool isCollidable;
    public GridObject(int x, int y,IEatable eatable,ICollideable collideable)
    {
        this.x = x;
        this.y = y;
        this.eatable = eatable;
        this.collideable = collideable;
    }
    public void AddCollidable(ICollideable collideable)
    {
        this.collideable= collideable;
        isCollidable = true;
    }
    public void AddCollidable()
    {
     //   this.collideable = collideable;
        isCollidable = true;
    }
    public void RemoveCollideable()
    {
        isCollidable= false;
        this.collideable = null;
    }
    public bool HasCollideable()
    {
        return isCollidable; 
    }
    public void AddEatable(IEatable eatable)
    {
            this.eatable = eatable;
            WorldGrid.Instance.emptyGrids.Remove(this);
        
    }
    public void RemoveEatable()
    {
        Debug.Log("Removed : ");
            this.eatable = null;
            WorldGrid.Instance.emptyGrids.Add(this);
        
    }
    public bool IsOutOfBound()
    {
        return x<0 || x>100 || y<0 || y>100;
    }
    public bool HasEatable()
    {
        return this.eatable != null;
    }
    public Vector3 GetWorldPosition()
    {
        return new Vector3(x, y, 0);
    }

    public bool Equals(GridObject other)
    {
        return this == other;
    }
    public override bool Equals(object obj)
    {
        return obj is GridObject && Equals((GridObject)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y);
    }

    //public static bool operator !=(GridObject left, GridObject right) { return left.x != right.x || left.y != right.y; }
    //public static bool operator == (GridObject left, GridObject right) { return left.x == right.x && left.y == right.y; }
}
