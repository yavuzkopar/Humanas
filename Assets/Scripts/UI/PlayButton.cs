using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void StartGame()
    {
       GameModeChanger modeChanger = FindObjectOfType<GameModeChanger>();
        LoadScene(modeChanger.mode);
    }
    public void LoadScene(GameModeChanger.GameMode gameMode)
    {
        int sceneIndex = (int)gameMode;
        SceneManager.LoadScene(sceneIndex + 1);
    }
}
