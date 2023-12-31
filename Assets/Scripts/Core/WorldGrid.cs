using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGrid : MonoBehaviour
{
    GridObject[,] grid = new GridObject[100,100];
    public List<GridObject> emptyGrids = new List<GridObject>();
    public static WorldGrid Instance{get; private set;}
    private void Awake()
    {
        Instance= this;
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                grid[i, j] = new GridObject(i, j,null,null);
                if (i <= 1 || i > 99 || j <= 1 || j > 99)
                    continue;
                emptyGrids.Add(grid[i, j]);
            }
        }
    }
    public GridObject GetGridObject(Vector2 position)
    {
        int x = Mathf.RoundToInt(position.x);
        int y = Mathf.RoundToInt(position.y);
        if (x <= 0 || y <= 0 || x >= 100 || y >= 100)
            return null;
        return grid[x,y];
    }
    public Vector2 GetGridPosition(GridObject gridObject)
    {
        return new Vector2(gridObject.x, gridObject.y);
    }
}
