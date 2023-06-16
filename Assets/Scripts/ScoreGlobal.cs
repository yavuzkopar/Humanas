using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGlobal : MonoBehaviour
{
    public static ScoreGlobal Instance { get; private set; }

    public const string SCORE_KEY = "GlobalScore";
    public int GlobalScore { get => PlayerPrefs.GetInt(SCORE_KEY); set => PlayerPrefs.SetInt(SCORE_KEY, value); }
    private void Awake()
    {
        Instance= this;
    }
    
}
