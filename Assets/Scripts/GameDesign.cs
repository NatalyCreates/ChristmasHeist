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

    internal float playerSpeed = 12;
    internal float guardSpeed = 12;
    internal float jingToRad = 0.4f;
    internal float initialTreeSize = 0.55f;
    internal Vector3 startingNoiseSize;
    internal float totalTime = 90f;

    void Awake()
    {
        Instance = this;
        startingNoiseSize = new Vector3(0.5f, initialTreeSize, initialTreeSize);
    }

}
