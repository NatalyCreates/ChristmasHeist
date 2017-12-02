using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

    // maybe not needed since we can just check a tag and then add to the collected count
    // ACTUALLY
    // randomize the texture for different stuff you collect

    Collider noiseCollider;
    NoiseRadius noise;

    void Start()
    {
        // position player in entrance
        // init other stuff
        //noise = GetComponentInChildren<NoiseRadius>();
        //noiseCollider = Player.noise.GetComponent<Collider>();
        //noise = gameObject.GetComponent(typeof(NoiseRadius)) as NoiseRadius;

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Tree")
        {
            Debug.Log("Trigger Enter Collectible - was noise");
        }
        else
        {
            Debug.Log("Trigger Enter Collectible");
            //Collectible dissapears
            //Add 1 to number of coll
            Player.Instance.numCollectibles++;
        }

    }

}
