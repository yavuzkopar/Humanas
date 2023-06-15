using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    int foodCount = 1;
    [SerializeField] Food[] spawn;
    [SerializeField] Transform magnet;
    void Start()
    {
        SpawnFood();
        Invoke("SpawnMagnet", 0.1f);
    }
    void SpawnMagnet()
    {
        for (int i = 0; i < 40; i++)
        {
            Transform m = Instantiate(magnet);
            m.position = WorldGrid.Instance.emptyGrids[Random.Range(0, WorldGrid.Instance.emptyGrids.Count)].GetWorldPosition();
        }
    }

    private void SpawnFood()
    {
        while (foodCount < 1000)
        {
            int raandomX = Random.Range(1, 99);
            int raandomY = Random.Range(1, 99);
            if (!WorldGrid.Instance.GetGridObject(new Vector2(raandomX, raandomY)).HasEatable())
            {
                foodCount++;
                int spawned = Random.Range(0, spawn.Length);

                Food f = Instantiate(spawn[spawned], new Vector3(raandomX, raandomY, 0), Quaternion.identity);
                WorldGrid.Instance.GetGridObject(new Vector2(raandomY, raandomY)).AddEatable(f);
            }
        }
    }
    void Update()
    {

    }
}
