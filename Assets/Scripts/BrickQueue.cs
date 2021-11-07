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

}