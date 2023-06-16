using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour,IEatable
{
    Vector3 randomRoateDirection;
    public void Eat(Eater eater)
    {
        eater.GetComponentInParent<ArenaCharacter>().TakeBullet();
        GridObject gridObject = WorldGrid.Instance.GetGridObject(transform.position);
        gridObject.RemoveEatable();
        Destroy(gameObject);
    }

    public Vector3 Position()
    {
        return transform.position;
    }
    void Start()
    {
        randomRoateDirection = Random.insideUnitSphere.normalized;
        GridObject gridObject = WorldGrid.Instance.GetGridObject(transform.position);
        gridObject.AddEatable(this);
    }
    void Update()
    {
        transform.Rotate(randomRoateDirection * Time.deltaTime * 45f);
    }
}
