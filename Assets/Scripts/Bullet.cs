using UnityEngine;

public class Bullet : MonoBehaviour { 

    [SerializeField] int damage = 10;
    GridObject currentGrid;


    float timer;
    private void Start()
    {
       currentGrid = WorldGrid.Instance.GetGridObject(transform.position);
    }
    private void Update()
    {
        DestroyWithTime();
        transform.position += transform.up * Time.deltaTime * 15f;
        HitCheck();
    }

    private void DestroyWithTime()
    {
        timer += Time.deltaTime;
        if (timer >= 10)
            Destroy(gameObject);
    }

    private void HitCheck()
    {
        currentGrid = WorldGrid.Instance.GetGridObject(transform.position);
        if (currentGrid == null) return;
        if (currentGrid.collideable != null)
        {
            currentGrid.collideable.TakeDamage();
            Destroy(gameObject);
        }
    }
}
