using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float BallVelocityX = 5f;
    public float BallVelocityY = 3f;
    private float accelerationOnColision = 1.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void RandDirection()
    {
        var rnd = Random.Range(0, 2);

        if (rnd == 0)
        {
            rb.velocity = new Vector2(BallVelocityX, -BallVelocityY);
        }
        else
        {
            rb.velocity = new Vector2(-BallVelocityX, BallVelocityY);
        }
    }

    public void ResetBall()
    {
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
    }

    public void RaiseVelocity()
    {
        var velocity = rb.velocity;
        var newVelocity = new Vector2(velocity.x * accelerationOnColision, velocity.y * accelerationOnColision);
        rb.velocity = newVelocity;
    }
}
