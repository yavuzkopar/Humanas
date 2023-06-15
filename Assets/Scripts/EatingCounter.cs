using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingCounter : MonoBehaviour
{
    float timer;
    Eater eater;
    public event Action<int> OnFeeded;
    void Start()
    {
        Invoke("Init", 0.1f);
    }
    void Init()
    {
        eater = GetComponentInChildren<Eater>();
        eater.OnFeeded += EatingCounter_OnFeeded;
    }

    private void EatingCounter_OnFeeded()
    {
        
        if(timer >0.3f)
        {
            OnFeeded?.Invoke(eater.currentlyEatingCount());
            timer = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
}
