using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScore : MonoBehaviour
{
    float timer;
    [SerializeField] Transform startPos, endPos;

    private void OnEnable()
    {
        transform.localPosition = Vector3.zero;
        timer = 0;
        transform.localScale = Vector3.one;
    }

    void Update()
    {
        float speed = 1f;
        timer += Time.deltaTime * speed;
        transform.position += Vector3.up * Time.deltaTime * 200f;
        transform.localScale= Vector3.one * (timer +1);
        if (timer >= 1f)
            gameObject.SetActive(false);
    }
}
