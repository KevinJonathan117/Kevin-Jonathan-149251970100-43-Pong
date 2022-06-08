using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    public KeyCode upKey;
    public KeyCode downKey;
    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        if (speed.Equals(0))
        {
            speed = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject(GetInput());
    }

    // Receive input
    private Vector2 GetInput() 
    {
        Vector2 movement = Vector2.zero;
        if (Input.GetKey(upKey)) 
        {
            movement = Vector2.up * speed;
        }
        if (Input.GetKey(downKey))
        {
            movement = Vector2.down * speed;
        }

        return movement;
    }

    // Move object with input
    private void MoveObject(Vector2 movement) 
    {
        rig.velocity = movement;
    }
}
