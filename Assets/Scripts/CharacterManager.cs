using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterManager : MonoBehaviour
{
    int eatenFood = 0;
    Eater eater;
    bool isEating;
    float growRate;
    [SerializeField] Transform tail;
    public CharacterSO characterSO;
    public Transform head;
    [SerializeField] Transform body;
    public int bodyCount;
    public bool isAi;
    int foodForGrow;
    void Start()
    {

        Transform t = Instantiate(head, transform);
        if (isAi)
        {
            t.GetComponent<Mover>().enabled = false;
            t.GetComponent<AIMover>().enabled = true;
            if (GameManager.Instance.isArena)
            {
                bodyCount = 4;
            }
            else
                bodyCount = Random.Range(2, 5);
        }
        else
        {
            FindObjectOfType<CameraFollower>().followObject = t;
            t.GetComponent<Mover>().enabled = true;
            t.GetComponent<AIMover>().enabled = false;
        }
        t.GetComponentInChildren<SpriteRenderer>().sprite = characterSO.headSprite;
        for (int i = 0; i < bodyCount; i++)
        {
            Transform temp = Instantiate(body, transform);
            temp.GetComponentInChildren<SpriteRenderer>().sprite = characterSO.bodySprite;
            temp.localPosition = Vector3.down * 2f * i;
        }
        eater = GetComponentInChildren<Eater>();
        eater.OnFeeded += Eater_OnFeeded;
        foodForGrow = 10;
    }


    private void Eater_OnFeeded()
    {
        isEating = true;
        eatenFood++;
        if (eatenFood >= foodForGrow)
        {
            Transform tailInstance = Instantiate(body, transform);
            Transform lastChild = transform.GetChild(transform.childCount - 1);
            tailInstance.GetComponentInChildren<SpriteRenderer>().sprite = characterSO.bodySprite;
            tailInstance.position = lastChild.position;
            tailInstance.SetAsLastSibling();
            foodForGrow *= 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isEating)
        {
            growRate += Time.deltaTime * 1.5f;
            foreach (Transform item in transform)
            {
                item.localScale = GrowingBezier(growRate);
            }
        }
        if (growRate > 1)
        {
            isEating = false;
            growRate = 0;
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

    public abstract void TakeDamage();
}
