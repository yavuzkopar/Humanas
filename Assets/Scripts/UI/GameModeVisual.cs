using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeVisual : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInParent<GameModeChanger>().OnGameModeChanged += GameModeVisual_OnGameModeChanged;
    }

    private void GameModeVisual_OnGameModeChanged(GameModeChanger.GameMode obj)
    {
        foreach (Transform item in transform)
        {
            item.gameObject.SetActive(false);
        }
        int siblingIndex = (int)obj;
        transform.GetChild(siblingIndex).gameObject.SetActive(true);
    }

    
}
