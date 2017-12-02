using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {

	void Start() {
		// init pos
	}
	
	void Update() {
		// move along predetermined path
        // randomize time that they wait in one spot at the edge of their path
	}

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Noise")
        {
            //Lose game

            Debug.Log("Noise hit guard");

            //Destroy(gameObject);
        }
        else
        {
            //Debug.Log("Trigger Enter Collectible - wasn't Tree");
            //Collectible dissapears
            //Add 1 to number of coll
        }

    }

}
