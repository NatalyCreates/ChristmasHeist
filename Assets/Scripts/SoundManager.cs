using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    static public SoundManager Instance;

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

    public void OnDeath()
    {

    }

    public void OnWin()
    {

    }

    public void OnPickup()
    {

    }

    public void SetIsWalking(bool state)
    {

    }
}
