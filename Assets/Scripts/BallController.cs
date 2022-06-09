using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 resetPosition;

    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        if (speed.Equals(Vector2.zero)) {
            speed = new Vector2(3, 3);
        }
        rig.velocity = speed;
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 1);
    }
}
