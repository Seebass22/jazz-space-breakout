using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BrickManager : MonoBehaviour
{
    List<Brick> taggedBricks = new List<Brick>();

    public UnityEvent allBricksCleared;
    public UnityEvent brickGroupCleared;
    public int bricksRequiredForLick = 4;
    private int totalBrickCount;

    private void Start()
    {
        totalBrickCount = this.gameObject.GetComponentsInChildren<Brick>().Length;
    }

    public void HitBlock(Brick blockHit)
    {
        if (!taggedBricks.Contains(blockHit)) taggedBricks.Add(blockHit);
        

        if (taggedBricks.Count >= bricksRequiredForLick)
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
        brickGroupCleared.Invoke();

        totalBrickCount -= taggedBricks.Count;
        taggedBricks.Clear();
        if (totalBrickCount <= 0)
        {
            allBricksCleared.Invoke();
        }
    }
}
