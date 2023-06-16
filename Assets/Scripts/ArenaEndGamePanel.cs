using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArenaEndGamePanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI orderText;
    private void OnEnable()
    {
        orderText.text = "Sýra   "+ ArenaManager.Instance.WormCount;
    }

}
