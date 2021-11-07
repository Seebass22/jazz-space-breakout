using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Lick
{
    public List<AudioClip> lickAudioParts = new List<AudioClip>();

    // Redundant, we were going to have each section play on hit, then the whole sequence play when it was completed
    // But instead we have just the sections
    // public int sectionCount; // this number of sections of this clip (i.e. how many blocks need to be hit before this lick is played)
}
