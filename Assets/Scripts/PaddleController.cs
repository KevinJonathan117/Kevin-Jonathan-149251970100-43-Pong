using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed;
    public KeyCode upKey;
    public KeyCode downKey;
    public GameObject paddle;
    private Rigidbody2D rig;

    private float lengthenPaddleTimer;
    private float highSpeedPaddleTimer;

    private int lengthenPaddlePUCount;
    private int highSpeedPaddlePUCount;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        if (speed.Equals(0))
        {
            speed = 5;
        }
        lengthenPaddlePUCount = 0;
        highSpeedPaddlePUCount = 0;
        Debug.Log("Speed: " + speed);
    }

    // Update is called once per frame
    void Update()
    {
        checkTimer();

        MoveObject(GetInput());
    }

    private void checkTimer()
    {
        if (lengthenPaddlePUCount > 0)
        {
            Debug.Log("LengthenPaddlePUCount: " + lengthenPaddlePUCount);
            Debug.Log("lengthenPaddleTimer: " + lengthenPaddleTimer);
            lengthenPaddleTimer += Time.deltaTime;

            if (lengthenPaddleTimer > 5 * lengthenPaddlePUCount)
            {
                lengthenPaddleTimer -= 5;
                lengthenPaddlePUCount = lengthenPaddlePUCount - 1;
                RemovePULengthenPaddle();
            }
        }

        if (highSpeedPaddlePUCount > 0)
        {
            Debug.Log("highSpeedPaddlePUCount: " + highSpeedPaddlePUCount);
            Debug.Log("highSpeedPaddleTimer: " + highSpeedPaddleTimer);
            highSpeedPaddleTimer += Time.deltaTime;

            if (highSpeedPaddleTimer > 5 * lengthenPaddlePUCount)
            {
                highSpeedPaddleTimer -= 5;
                highSpeedPaddlePUCount = highSpeedPaddlePUCount - 1;
                RemovePUHighSpeedPaddle();
            }
        }
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

    //PULogic
    public void ActivatePULengthenPaddle(float magnitude)
    {
        Vector3 currentScale = paddle.transform.localScale;
        paddle.transform.localScale = new Vector3(currentScale.x, currentScale.y * 2, currentScale.z);
        lengthenPaddlePUCount++;
    }

    public void ActivatePUHighSpeedPaddle(float magnitude)
    {
        speed *= magnitude;
        highSpeedPaddlePUCount++;
    }

    private void RemovePULengthenPaddle()
    {
        Vector3 currentScale = paddle.transform.localScale;
        paddle.transform.localScale = new Vector3(currentScale.x, currentScale.y / 2, currentScale.z);
    }

    private void RemovePUHighSpeedPaddle()
    {
        speed /= 2;
    }
}
