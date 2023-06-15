using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeChanger : MonoBehaviour
{
    public event Action<GameMode> OnGameModeChanged;
    public enum GameMode
    {
        Classic,
        Arena
    }
    
    public GameMode mode;
    int currentModeIndex;
    public void ChangeMode()
    {
        int totalModeCount = Enum.GetNames(typeof(GameMode)).Length;
        currentModeIndex++;
        if(currentModeIndex>= totalModeCount)
            currentModeIndex= 0;
        mode = (GameMode)currentModeIndex;
        OnGameModeChanged?.Invoke(mode);
    }
}
