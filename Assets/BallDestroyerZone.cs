using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallDestroyerZone : MonoBehaviour
{
    public UnityEvent collision;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ball")
        {
            Destroy(collider.gameObject);
            collision.Invoke();
        }
    }
}
