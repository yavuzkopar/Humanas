using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isArena;
    [SerializeField] GameObject player;
    [SerializeField] UnityEvent endGameEvent;
    bool isGameOver;
    private void Awake()
    {
        Instance= this;
    }
    void Start()
    {
        isGameOver = false;
    }
    void Update()
    {
        if (isGameOver) return;
        if(player == null)
        {
            isGameOver= true;
            endGameEvent?.Invoke();
        }

    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
