using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WormCountText : MonoBehaviour
{
    TextMeshProUGUI text;
    void Start()
    {
        text= GetComponent<TextMeshProUGUI>();
        ArenaManager.Instance.OnAnyWormDied += Instance_OnAnyWormDied;
    }

    private void Instance_OnAnyWormDied()
    {
        text.text = "Kalan Kurt \n" + ArenaManager.Instance.WormCount;
    }
}
