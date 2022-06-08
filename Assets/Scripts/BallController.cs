using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;

    private Rigidbody2D rig;
    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        if (speed.Equals(Vector2.zero)) {
            speed = new Vector2(3, 3);
        }
        rig.velocity = speed;
    }
}
