using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BrickManager : MonoBehaviour
{
    List<Brick> taggedBricks = new List<Brick>();

    public UnityEvent allBricksCleared;

    public void HitBlock(Brick blockHit)
    {
        taggedBricks.Add(blockHit);

        if (taggedBricks.Count >= 3)
        {
            this.DrainQueue();
        }
    }

    public void DrainQueue()
    {
        foreach (var brick in taggedBricks)
        {
            Destroy(brick.gameObject);
        }
        taggedBricks.Clear();
        if (!this.gameObject.GetComponentInChildren<Brick>())
        {
            allBricksCleared.Invoke();
        }
    }
}
