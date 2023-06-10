using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    int foodCount = 0;
    [SerializeField] Food[] spawn;
    void Start()
    {
       
            SpawnFood();

    }

    private void SpawnFood()
    {
        while (foodCount < 1000)
        {
            int raandomX = Random.Range(0, 100);
            int raandomY = Random.Range(0, 100);
            for (int i = 0; i < 1000; i++)
            {

                if (!WorldGrid.Instance.GetGridObject(new Vector2(raandomX, raandomY)).HasEatable())
                {
                    foodCount++;
                    Instantiate(spawn[Random.Range(0, spawn.Length)], new Vector3(raandomX, raandomY, 0), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
