using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void markBrick()
    {
        rend.material.SetColor("_Color", Color.red);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetComponent<Ball>())
        {
            brickHit.Invoke(this);
        }
    }
}
