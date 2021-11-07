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
    public int currentBrickHitCount = 0; // NON UNIQUE brick count (the same brick hit multiple times counts toward this)
    private int totalBrickCount;

    private bool requireUniqueBricksToTriggerLick = false; // feature flag. set to true if only unique bricks trigger the lick (can cause issues if a brick is unaccessible)

    private void Start()
    {
        totalBrickCount = this.gameObject.GetComponentsInChildren<Brick>().Length;
    }

    public void HitBlock(Brick blockHit)
    {
        if (!taggedBricks.Contains(blockHit)) taggedBricks.Add(blockHit);

        currentBrickHitCount += 1;
        bool nonUniqueIsSufficient = !requireUniqueBricksToTriggerLick && currentBrickHitCount >= bricksRequiredForLick;
        if (taggedBricks.Count >= bricksRequiredForLick || nonUniqueIsSufficient)
        {
            this.DrainQueue();
        }
    }

    public void DrainQueue()
    {
        foreach (var brick in taggedBricks)
        {
            brick.Destruct();
        }
        brickGroupCleared.Invoke();

        totalBrickCount -= taggedBricks.Count;
        currentBrickHitCount = 0;
        taggedBricks.Clear();
        if (totalBrickCount <= 0)
        {
            allBricksCleared.Invoke();
        }
    }
}
