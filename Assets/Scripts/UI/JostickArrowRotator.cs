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
    void Update()
    {
        transform.up = directionArrow.transform.up;
    }
}
