using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private FloatingJoystick joystick;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = new Vector2(joystick.Horizontal,joystick.Vertical);
        transform.up = Vector3.Lerp(transform.up, inputVector, Time.deltaTime);
        transform.position += transform.up * Time.deltaTime * 1f;
    }
}
