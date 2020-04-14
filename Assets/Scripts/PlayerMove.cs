using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 8f;
    public KeyCode Up;
    public KeyCode Down;

    void FixedUpdate()
    {
        float inputY = 0;

        if (Input.GetKey(Up))
            inputY = 1;
        else if (Input.GetKey(Down))
            inputY = -1;

        transform.Translate(new Vector2(0, inputY) * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Ball")
        {
            collision.collider.GetComponent<BallController>().RaiseVelocity();
        }
    }

    public void ResetPlayer()
    {
        transform.position = new Vector2(transform.position.x, 0);
    }
}
