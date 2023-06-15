using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmCharacter : CharacterManager
{
    public override void TakeDamage()
    {
       // Destroy(gameObject);
        CharacterSpawner.Instance.ReSpawn(this);
    }
    public void SpeedUp()
    {
        GetComponentInChildren<Mover>().SpeedUp();
    }
    
}
