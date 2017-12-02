using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDesign : MonoBehaviour {

    // balance stuff here
    // movement speeds of player and guards
    // timers
    // radius of noise levels as a function of number of collectibles
    // ???

    public static GameDesign Instance;

    public float playerSpeed = 8;
    public float jingToRad;
    public Vector3 startingNoiseSize;

    void Awake()
    {
        Instance = this;

        jingToRad = 0.95f;
        startingNoiseSize = new Vector3(0.5f, 0.2f, 0.2f);
    }

    }
