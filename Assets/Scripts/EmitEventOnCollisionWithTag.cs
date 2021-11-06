using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EmitEventOnCollisionWithTag : MonoBehaviour
{
    public UnityEvent collision;
    [SerializeField]
    private string tagForEmit;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == tagForEmit)
        {
            collision.Invoke();
        }
    }
}