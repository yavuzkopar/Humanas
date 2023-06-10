using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    int eatenFood = 0;
    Eater eater;
    bool isEating;
    float growRate;
    [SerializeField] Transform tail;
    void Start()
    {
        eater = GetComponentInChildren<Eater>();
        eater.OnFeeded += Eater_OnFeeded;
    }

    private void Eater_OnFeeded()
    {
        isEating= true;
        eatenFood++;
        if(eatenFood%10 == 0)
        {
           Transform tailInstance = Instantiate(tail,transform);
            Transform lastChild = transform.GetChild(transform.childCount - 1);
            tailInstance.position = lastChild.position;
            tailInstance.SetAsLastSibling();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isEating)
        {
            growRate += Time.deltaTime*1.5f;
            foreach (Transform item in transform)
            {
                item.localScale = GrowingBezier(growRate);
            }
        }
        if(growRate>1)
        {
            isEating= false;
            growRate= 0;
        }
    }
    Vector3 GrowingBezier(float t)
    {
        Vector3 first = Vector3.one;
        Vector3 middle = Vector3.one * 1.2f;
        Vector3 a = Vector3.Lerp(first, middle, t);
        Vector3 b = Vector3.Lerp(middle, first, t);
        return Vector3.Lerp(a, b, t);
    }
}
