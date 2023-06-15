using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mover : MonoBehaviour
{
    private FloatingJoystick joystick;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    bool isSpeedUpped;
    float timer;
    DirectionArrow directionArrow;
    void Start()
    {
        joystick = FindObjectOfType<FloatingJoystick>();
        //    FindObjectOfType<Button>().onClick.AddListener(SpeedUp);
        directionArrow = FindObjectOfType<DirectionArrow>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = new Vector2(joystick.Horizontal, joystick.Vertical);
        transform.up = Vector3.Lerp(transform.up, inputVector, Time.deltaTime * rotationSpeed);
        transform.position += transform.up * Time.deltaTime * speed;
        if (isSpeedUpped)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                isSpeedUpped = false;
                timer = 0;
                speed *= 0.5f;
            }
        }

        directionArrow.transform.position = transform.position;
        if (inputVector.magnitude > 0f)
            directionArrow.transform.up = inputVector;
        else
            directionArrow.transform.up = transform.up;
    }
    public void SpeedUp()
    {
        if (isSpeedUpped) return;
        speed *= 2f;
        isSpeedUpped = true;
    }
}
