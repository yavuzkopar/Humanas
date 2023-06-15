using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuWormMovement : MonoBehaviour
{
    [SerializeField] float pres;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float y = Mathf.Sin(Time.time + Mathf.PI * pres) * 0.5f;
        transform.position = new Vector3(transform.position.x,y,transform.position.z);
    }
}
