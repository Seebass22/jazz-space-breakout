using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float ballSpeed = 3f;
    Transform paddleTransform;
    Rigidbody2D rb;

    void Start()
    {
        paddleTransform = FindObjectOfType<Paddle>().GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-1, -1) * ballSpeed;
    }

    void Update()
    {
        //transform.position += transform.right * Time.deltaTime * ballSpeed;
    }

    float hitFactor()
    {
        float paddleWidth = 10f;
        return (transform.position.x - paddleTransform.position.x) / paddleWidth;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetComponent<Paddle>())
        {
            Debug.Log("paddle");
        }
        Debug.Log("collided");
    }
}
