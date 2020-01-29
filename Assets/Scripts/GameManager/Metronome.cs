using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    public float timerCounter;
    public float timerTracker;
    public AudioClip playingSong;
    public float songBPM;
    public float beatInterval;
    public int beatsSoFar;

    public bool beat;
    public bool halfBeat;
    public bool doubleBeat;
    private bool skipNext;
    // Start is called before the first frame update
    void Start()
    {
        playingSong = GameObject.Find("AudioProcessor").GetComponent<AudioSource>().clip;
        songBPM = float.Parse(playingSong.name.Substring(0,3).ToString());
        beatInterval = Mathf.Round((50*60)/songBPM);

    }

    void FixedUpdate() {
        timerCounter++;
        timerTracker += Time.deltaTime;
        CheckForBeat();
    }

    void CheckForBeat(){
        if(timerCounter % beatInterval == 0){
            beat = true;
            beatsSoFar++;
            // Debug.Log("Beat");
        }else if(timerCounter % (beatInterval/2) == 0){
            halfBeat = true;
            // Debug.Log("Half Beat");
        }
    }
}
