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
    int blocksLeft = 32;

    [SerializeField] List<AudioClip> lick1;
    [SerializeField] List<AudioClip> lick2;
    [SerializeField] List<AudioClip> lick3;
    [SerializeField] List<AudioClip> lick4;
    [SerializeField] List<AudioClip> lick5;
    [SerializeField] List<AudioClip> lick6;

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
        licks.Add(lick3);
        licks.Add(lick4);
        licks.Add(lick5);
        licks.Add(lick6);
        currentLick = lick6;
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
            brick.MarkBrick();
        }
        
        if (queue.Count == currentLick.Count || blocksLeft < currentLick.Count)
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
                b.Destruct();
                source.Play();
                yield return new WaitWhile(() => source.isPlaying);
                index += 1;
                blocksLeft -= 1;
            }
        }

        queue.Clear();
        
        var random = new Random();
        int ind = random.Next(licks.Count);
        currentLick = licks[ind];
        queueLocked = false;
    }
}