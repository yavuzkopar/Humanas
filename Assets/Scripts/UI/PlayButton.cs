using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] GameObject loadingScene;
    public void StartGame()
    {
       GameModeChanger modeChanger = FindObjectOfType<GameModeChanger>();
        LoadScene(modeChanger.mode);
    }
    public void LoadScene(GameModeChanger.GameMode gameMode)
    {
        loadingScene.SetActive(true);
        int sceneIndex = (int)gameMode;
        StartCoroutine(LoadAsynchronously(sceneIndex + 1));
    }
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
    }
}
