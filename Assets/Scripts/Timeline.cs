using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeline : MonoBehaviour
{
    // Licks stuff
    private List<Lick> queuedLicks = new List<Lick>();
    private int lifetimeBlockHitCount = 0; // just in case we do something special at a certain number of blocks, currently unused
    private int blockHitCount = 0;

    public Lick activeLick;

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
            this.PlayAndDrainQueuedLicks();
        }
    }




    // Custom methods
    private void UpdateBeatCountDisplay(string beatCount)
    {
        this.uiBeatCount.text = beatCount;
    }
    private void UpdateBlockHitCountDisplay()
    {
        this.uiBlockHitCount.text = this.blockHitCount.ToString();
    }


    public void AddBlockHit()
    {
        Debug.Log(string.Format("New block hit, updating to {0}", this.blockHitCount));
        this.lifetimeBlockHitCount += 1;
        this.blockHitCount += 1;

        this.AttemptActiveLick();

        this.UpdateBlockHitCountDisplay();
    }

    // Probably this should be outside of the timeline, but just prototyping now
    private void AttemptActiveLick()
    {
        if (activeLick.sectionCount <= this.blockHitCount)
        {
            this.queuedLicks.Add(this.activeLick); // no mechanism to change the active lick as of yet
            this.blockHitCount = 0;
        }
    }

    private void PlayAndDrainQueuedLicks()
    {
        Debug.Log("Queued licks drained");
        this.queuedLicks.ForEach(lick => AudioSource.PlayClipAtPoint(lick.lickAudio, new Vector3(0,0,0)));

        this.queuedLicks.Clear();
    }
}
