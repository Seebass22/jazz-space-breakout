using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    void Update()
    {
        if (Time.timeScale == 0)
            return;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        transform.position = new Vector3(mousePosition.x, transform.position.y, 0f);
    }
}
