using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour,ICollideable
{
    GridObject currentGrid;
    GridObject previousGrid;
    bool canDo;
    CharacterManager characterManager;
    void OnEnable()
    {
        previousGrid = WorldGrid.Instance.GetGridObject(transform.position);
        previousGrid.AddCollidable(this);

        characterManager = GetComponentInParent<CharacterManager>();
    }
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 1, 99), Mathf.Clamp(transform.position.y, 1, 99), 0);
        currentGrid = WorldGrid.Instance.GetGridObject(transform.position);

        if (IsHitted() && !canDo)
        {
            canDo = true;
            Debug.Log("aaaaa");
            TakeDamage();
           // currentGrid.collideable.TakeDamage();
            //CharacterSpawner.Instance.ReSpawn(GetComponentInParent<CharacterManager>());
            
           // return;
        }

        if (currentGrid != previousGrid)
        {
            previousGrid.RemoveCollideable();
            previousGrid = currentGrid;

            currentGrid.AddCollidable(this);
        }
        

    }

    bool IsHitted()
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

    public void TakeDamage()
    {
        characterManager.TakeDamage();
    }
}
