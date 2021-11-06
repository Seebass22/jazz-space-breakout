using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallDestroyerZone : MonoBehaviour
{
    private GameObject menu;
    public UnityEvent collision;

    private void Start()
    {
        menu = GameObject.Find("Menu");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ball")
        {
            Destroy(collider.gameObject);
            collision.Invoke();
            menu?.SetActive(true);
            Debug.Log("Destroyed");
        }
    }
}
