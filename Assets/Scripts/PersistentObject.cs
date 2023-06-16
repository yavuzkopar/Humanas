using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    public CharacterSO selectedCharacter;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Persistent");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    public void SetCharacter(CharacterSO character)
    {
        selectedCharacter = character;
    }
}
