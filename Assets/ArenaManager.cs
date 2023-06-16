using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    public static ArenaManager Instance { get; private set; }
    public event Action OnAnyWormDied;
    public int WormCount { get; private set; }

    [SerializeField] int targetWormCount;
    [SerializeField] GameObject winScreen, loseScreen;
    private void Awake()
    {
        Instance = this;
        WormCount = 100;
    }
    public void WormDie()
    {
        WormCount--;
        OnAnyWormDied?.Invoke();
    }
    public void SetWinOrLoseScreen()
    {
        if (WormCount <= targetWormCount)
            Win();
        else
            Lose();
    }

    private void Win()
    {
        winScreen.SetActive(true);
    }

    private void Lose()
    {
        loseScreen.SetActive(true);
    }
}
