using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickQueue : MonoBehaviour
{
    public static Action<Brick> onBrickHit;
    List<Brick> queue = new List<Brick>();

    void OnEnable()
    {
        onBrickHit += BrickHit;
    }

    void OnDisable()
    {
        onBrickHit -= BrickHit;
    }

    void BrickHit(Brick brick)
    {
        if (queue.Contains(brick))
            return;
        
        queue.Add(brick);
        brick.markBrick();
        if (queue.Count == 3)
        {
            foreach (var b in queue)
            {
                Destroy(b.gameObject);
            }
            queue.Clear();
        }
    }
}
