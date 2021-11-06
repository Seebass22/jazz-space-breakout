using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float speed = 6f;
    Transform paddleTransform;
    Rigidbody2D rb;
    List<Brick> queue = new List<Brick>();

    void Start()
    {
        paddleTransform = FindObjectOfType<Paddle>().GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-1, -1) * 0.5f * speed;
    }

    float HitFactor(float paddleWidth)
    {
        return (transform.position.x - paddleTransform.position.x) / paddleWidth;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetComponent<Paddle>())
        {
            float paddleWidth = other.collider.bounds.size.x;
            Debug.Log("paddle");
            float x=HitFactor(paddleWidth);
    
            Vector2 dir = new Vector2(x, 1).normalized;
    
            rb.velocity = dir * speed;
        }

        if (other.collider.GetComponent<Brick>())
        {
            queue.Add(other.collider.GetComponent<Brick>());
            if (queue.Count == 3)
            {
                foreach (var brick in queue)
                {
                    Destroy(brick.gameObject);
                }
                queue.Clear();
            }
        }
    }
}
