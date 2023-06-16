using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WormSelector : MonoBehaviour
{
    [SerializeField] AllWormsSO allWormsSO;
    [SerializeField] Button templateButton;
    // CharacterSO selectedCharacter;
    [SerializeField] Image mainScreenCharIcon;
    private void OnEnable()
    {
        for (int i = 0; i < allWormsSO.worms.Length; i++)
        {
            Button temp = Instantiate(templateButton, transform);
            temp.GetComponent<Image>().sprite = allWormsSO.worms[i].headSprite;
            temp.onClick.AddListener(() => { SelectWorm(temp.transform.GetSiblingIndex()); });
        }
        
    }
    void SelectWorm(int i)
    {
        //  selectedCharacter = allWormsSO.worms[i];
        mainScreenCharIcon.sprite = allWormsSO.worms[i].headSprite;
        FindObjectOfType<PersistentObject>().SetCharacter(allWormsSO.worms[i]);
    }
    private void OnDisable()
    {
        foreach (Transform item in transform)
        {
            Destroy(item.gameObject);
        }
    }
}
