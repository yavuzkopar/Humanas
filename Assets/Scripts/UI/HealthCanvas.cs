using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthCanvas : MonoBehaviour
{
    ArenaCharacter characterManager;
    [SerializeField] Transform head;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] Image healthImage;
    [SerializeField] Transform bulletParent;
    void Start()
    {
        characterManager = GetComponentInParent<ArenaCharacter>();
        characterManager.OnTakeDamage += CharacterManager_OnTakeDamage;
        characterManager.OnShootBullet += CharacterManager_OnShootBullet;
        characterManager.OnTakeBullet += CharacterManager_OnTakeBullet;
        Invoke("AssingHead", 0.1f);
    }

    private void CharacterManager_OnTakeBullet(int i)
    {
        bulletParent.GetChild(i - 1).gameObject.SetActive(true);
    }

    private void CharacterManager_OnShootBullet(int i)
    {
        bulletParent.GetChild(i).gameObject.SetActive(false);
    }

    void AssingHead()
    {
        head = characterManager.transform.GetChild(1);
    }
    private void CharacterManager_OnTakeDamage()
    {
        healthText.text = characterManager.health.ToString();
        healthImage.fillAmount = characterManager.health / 100f;
    }
    private void OnDisable()
    {
        characterManager.OnTakeDamage -= CharacterManager_OnTakeDamage;
        characterManager.OnShootBullet -= CharacterManager_OnShootBullet;
        characterManager.OnTakeBullet -= CharacterManager_OnTakeBullet;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (head == null) return;
        transform.position = head.transform.position - head.up;
    }
}
