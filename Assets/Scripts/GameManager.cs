using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    static public GameManager Instance;

    public Text timer;
    public Text score;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("More than 1 GameManager in the scene!");
            Destroy(this);
        }
    }

	void Start() {
		
	}
	
	void Update() {
		
	}
}
