using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IEatable
{
    bool isEatening;
    Eater eater;
    public static event Action OnEatened;
    public void Eat(Eater eater)
    {
        this.eater = eater;
        isEatening = true;
    }

    // Start is called before the first frame update
    void Awake()
    {
        GridObject gridObject = WorldGrid.Instance.GetGridObject(transform.position);
        gridObject.AddEatable(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEatening)
        {
            float goingSpeed = 5f;
            Vector3 dir = (eater.transform.position - transform.position).normalized;
            transform.position += dir * Time.deltaTime * goingSpeed;
            if(Vector3.Distance(transform.position,eater.transform.position)<0.1f)
            {
                eater.Feed();
                Destroy(gameObject);
                OnEatened?.Invoke();
            }
                
        }
    }
}
