using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUHighSpeedPaddleController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public GameObject leftPaddle;
    public GameObject rightPaddle;
    public float magnitude;
    public int destroyInterval;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > destroyInterval)
        {
            manager.RemovePowerUp(gameObject);
            timer -= destroyInterval;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            leftPaddle.GetComponent<PaddleController>().ActivatePUHighSpeedPaddle(magnitude);
            rightPaddle.GetComponent<PaddleController>().ActivatePUHighSpeedPaddle(magnitude);
            manager.RemovePowerUp(gameObject);
        }
    }
}
