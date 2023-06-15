using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] CharacterManager characterManager;
    [SerializeField] CharacterManager aiCharacter;
    [SerializeField] CharacterSO[] characterSOs;
    public static CharacterSpawner Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        characterManager.gameObject.SetActive(true);

        for (int i = 0; i < 99; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(10, 90), Random.Range(10, 90), 0);
            while (Vector3.Distance(randomPos, Camera.main.transform.position + Vector3.forward * -Camera.main.transform.position.z) < 15f)
            {
                randomPos = new Vector3(Random.Range(10, 90), Random.Range(10, 90), 0);

            }
            CharacterManager character = Instantiate(aiCharacter, randomPos, Quaternion.identity);
            character.characterSO = characterSOs[Random.Range(0, characterSOs.Length)];
            character.isAi = true;
        }
    }

    public void ReSpawn(CharacterManager cm)
    {
        Vector3 randomPos = new Vector3(Random.Range(10, 90), Random.Range(10, 90), 0);
        while (Vector3.Distance(randomPos, Camera.main.transform.position + Vector3.forward * -Camera.main.transform.position.z) < 20f)
        {
            randomPos = new Vector3(Random.Range(10, 90), Random.Range(10, 90), 0);

        }
        foreach (Transform item in cm.transform)
        {
            WorldGrid.Instance.GetGridObject(item.position).RemoveCollideable();
            
        }
        Destroy(cm.gameObject);
        CharacterManager character = Instantiate(aiCharacter, randomPos, Quaternion.identity);
        character.characterSO = characterSOs[Random.Range(0, characterSOs.Length)];
        character.isAi = true;

    }
}
