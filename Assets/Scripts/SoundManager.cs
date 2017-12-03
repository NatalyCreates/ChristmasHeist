using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    static public SoundManager Instance;

    public AudioSource music;
    public AudioSource walkingSfx;

    bool isWalkingSoundPlaying = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("More than 1 SoundManager in the scene!");
            Destroy(this);
        }
    }

    void Start()
    {
        // play music in sequence
    }

    public void OnBusted()
    {

    }

    public void OnWin()
    {

    }

    public void OnTimesUp()
    {

    }

    public void OnPickup()
    {

    }

    public void SetIsWalking(bool isWalking)
    {
        if (isWalking && !isWalkingSoundPlaying)
        {
            Debug.Log("Play WALK SFX");
            isWalkingSoundPlaying = true;
            walkingSfx.Play();
        }
        else if (!isWalking && isWalkingSoundPlaying)
        {
            Debug.Log("Stop WALK SFX");
            isWalkingSoundPlaying = false;
            walkingSfx.Stop();
        }
    }
}
