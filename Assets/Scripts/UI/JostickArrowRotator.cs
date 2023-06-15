using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JostickArrowRotator : MonoBehaviour
{
    DirectionArrow directionArrow;
    void Start()
    {
        directionArrow = FindObjectOfType<DirectionArrow>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = directionArrow.transform.up;
    }
}
