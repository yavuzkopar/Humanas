using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaCharacter : CharacterManager
{
    public int health = 100;
    public event Action OnTakeDamage;
    public event Action<int> OnTakeBullet;
    public event Action<int> OnShootBullet;
    int bulletCount;
    [SerializeField] Transform bullet;
    public override void TakeDamage()
    {
        health -= 10;
        OnTakeDamage?.Invoke();
        if(health<= 0)
        {
            ArenaManager.Instance.WormDie();
            Destroy(gameObject);
        }
            
    }
    public void TakeBullet()
    {
        if (bulletCount < 3)
        {
            bulletCount++;
            OnTakeBullet?.Invoke(bulletCount);
        }
    }
    public void Shoot()
    {
        if(bulletCount > 0)
        {
            bulletCount--;
            Transform bulletInstance = Instantiate(bullet);
            Transform headTransform = transform.GetChild(1);
            bulletInstance.transform.position = headTransform.position + headTransform.up*1.5f;
            bulletInstance.up = headTransform.up;
            OnShootBullet?.Invoke(bulletCount);
        }
    }

      
    
}
