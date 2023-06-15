
using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] Transform bullet;
    int bulletCount;
    void Start()
    {
        while (bulletCount < 100)
        {
            int raandomX = Random.Range(1, 99);
            int raandomY = Random.Range(1, 99);
            if (!WorldGrid.Instance.GetGridObject(new Vector2(raandomX, raandomY)).HasEatable())
            {
                bulletCount++;


                Instantiate(bullet, new Vector3(raandomX, raandomY, 0), Quaternion.identity);
            }
        }
        StartCoroutine(SpawnRoutine());
    }
    IEnumerator SpawnRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            int raandomX = Random.Range(1, 99);
            int raandomY = Random.Range(1, 99);
            Instantiate(bullet, WorldGrid.Instance.emptyGrids[Random.Range(0, WorldGrid.Instance.emptyGrids.Count)].GetWorldPosition(), Quaternion.identity);
        }
    }
}
