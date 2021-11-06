using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    AudioSource source;
    Renderer rend;
    public UnityEvent<Brick> brickHit;
    void Start()
    {
        rend = GetComponent<Renderer>();
        source = GetComponent<AudioSource>();
    }

    public void markBrick()
    {
        rend.material.SetColor("_Color", Color.red);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetComponent<Ball>())
        {
            source.Play();
            brickHit.Invoke(this);
            BrickQueue.onBrickHit?.Invoke(this);
        }
    }
}
