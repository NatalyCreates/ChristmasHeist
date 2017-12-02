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

    void Awake()
    {
        Instance = this;
    }

    }
