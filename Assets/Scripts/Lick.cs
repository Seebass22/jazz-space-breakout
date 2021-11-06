using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Lick
{
    public AudioClip lickAudio;
    public int sectionCount; // this number of sections of this clip (i.e. how many blocks need to be hit before this lick is played)
}
