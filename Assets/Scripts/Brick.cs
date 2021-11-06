using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    public UnityEvent<Brick> brickHit;


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetComponent<Ball>())
        {
            brickHit.Invoke(this);
        }
    }
}
