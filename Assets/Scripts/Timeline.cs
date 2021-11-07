using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeline : MonoBehaviour
{
    // Licks stuff
    private List<Lick> queuedLicks = new List<Lick>();
    [SerializeField]
    private List<Lick> allLicks = new List<Lick>();

    // UI stuff
    private TMPro.TextMeshProUGUI uiBeatCount;
    private TMPro.TextMeshProUGUI uiBlockHitCount;
    private Slider uiSlider;

    // Timer stuff
    public float beatsPerSecond = 1f;
    public int beatDivisions = 4;
    private float nextUpdate = 0f;
    private float nextBar = 0f;


    // Unity methods
    void Start()
    {
        this.uiBeatCount = this.gameObject.transform.Find("BeatTracker/GFX").GetComponent<TMPro.TextMeshProUGUI>();
        this.uiBlockHitCount = this.gameObject.transform.Find("BlockHitCount/GFX").GetComponent<TMPro.TextMeshProUGUI>();
        this.uiSlider = this.gameObject.transform.Find("BeatTracker/Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        var roundedTime = Mathf.Round(Time.time * 100) / 100;
        this.uiSlider.value = Time.time % 1;

        if (roundedTime >= nextUpdate)
        {
            nextUpdate = roundedTime + this.beatsPerSecond;
            this.UpdateBeatCountDisplay(roundedTime.ToString());
        }

        if (Time.time >= nextBar)
        {
            nextBar = roundedTime + (this.beatsPerSecond * this.beatDivisions);
            //this.PlayAndDrainQueuedLicks(); // to play the beats in sync, call this here
            // however, synce beats sounds terrible for some reason, so we just always call it
        }
        this.PlayAndDrainQueuedLicks();
    }

    // Custom methods
    private void UpdateBeatCountDisplay(string beatCount)
    {
        this.uiBeatCount.text = beatCount;
    }

    public void QueueRandomLick()
    {
        int randomLickIndex = Random.Range(0, allLicks.Count);
        this.queuedLicks.Add(allLicks[randomLickIndex]);
    }

    private void PlayAndDrainQueuedLicks()
    {
        this.queuedLicks.ForEach(lick => StartCoroutine(PlayLick(lick.lickAudioParts)));

        this.queuedLicks.Clear();
    }

    IEnumerator PlayLick(List<AudioClip> lickParts)
    {
        foreach (var part in lickParts)
        {
            AudioSource tempAudio = PlayClipAt(part);
            yield return new WaitWhile(() => tempAudio && tempAudio.isPlaying);
        }
    }

    // create the temp object with an audio source that deletes after it's run
    // Unity's inbuild PlayClipAtPoint doesn't return its reference, so we need to hack it :/
    // http://answers.unity.com/answers/533247/view.html
    AudioSource PlayClipAt(AudioClip clip) {
        GameObject tempGO = new GameObject("TempAudio");
        AudioSource audio = tempGO.AddComponent<AudioSource>();
        audio.clip = clip;
        audio.Play();
        Destroy(tempGO, clip.length);
        return audio;
     }
}
