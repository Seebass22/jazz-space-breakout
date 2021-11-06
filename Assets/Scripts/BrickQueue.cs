using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BrickQueue : MonoBehaviour
{
    public static Action<Brick> onBrickHit;
    List<Brick> queue = new List<Brick>();
    bool queueLocked = false;
    AudioSource source;

    [SerializeField] List<AudioClip> lick1;
    [SerializeField] List<AudioClip> lick2;

    int index = 0;

    List<List<AudioClip>> licks;
    List<AudioClip> currentLick;

    void OnEnable()
    {
        source = GetComponent<AudioSource>();
        onBrickHit += BrickHit;
        licks = new List<List<AudioClip>>();
        licks.Add(lick1);
        licks.Add(lick2);
        currentLick = lick1;
    }

    void OnDisable()
    {
        onBrickHit -= BrickHit;
    }

    void BrickHit(Brick brick)
    {
        if (queue.Contains(brick))
            return;

        if (!queueLocked)
        {
            queue.Add(brick);
            brick.markBrick();
        }
        
        if (queue.Count == currentLick.Count)
        {
            if (!queueLocked)
            {
                StartCoroutine(PlayLick());
            }
        }
    }

    IEnumerator PlayLick()
    {
        queueLocked = true;
        index = 0;
        foreach (var b in queue)
        {
            if (b)
            {
                source.clip = currentLick[index];
                b.gameObject.SetActive(false);
                source.Play();
                yield return new WaitWhile(() => source.isPlaying);
                index += 1;
            }
        }
        queue.RemoveRange(0, currentLick.Count);
        currentLick = licks[1];
        queueLocked = false;
    }
}