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
    public GameObject destroyedPrefab;
    void Start()
    {
        rend = GetComponent<Renderer>();
        source = GetComponent<AudioSource>();
    }

    public void MarkBrick()
    {
        rend.material.SetColor("_Color", Color.gray);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetComponent<Ball>())
        {
            brickHit.Invoke(this);
            source.Play();
            BrickQueue.onBrickHit?.Invoke(this);
        }
    }

    public void Destruct()
    {
        Instantiate(destroyedPrefab, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
