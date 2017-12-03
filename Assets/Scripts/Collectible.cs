using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

    // maybe not needed since we can just check a tag and then add to the collected count
    // ACTUALLY
    // randomize the texture for different stuff you collect

    Collider noiseCollider;
    NoiseRadius noise;

    internal float noiseRadScale;

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
            //Debug.Log("Trigger Enter Collectible - was Tree");
            Player.Instance.numCollectibles++;
            GameManager.Instance.UpdateScore(Player.Instance.numCollectibles);
            //noiseRadScale = Mathf.Sqrt(Player.Instance.numCollectibles * GameDesign.Instance.jingToRad);
            noiseRadScale = Player.Instance.numCollectibles * GameDesign.Instance.jingToRad + GameDesign.Instance.initialTreeSize;
            //noiseRadScale = Player.Instance.numCollectibles * 0.8f;
            Debug.Log(noiseRadScale.ToString());
            //NoiseRadius.Instance.noiseCollider.radius = ;
            NoiseRadius.Instance.transform.localScale = new Vector3(0.5f, noiseRadScale, noiseRadScale);

            //Player.Instance.GetComponentInChildren<Rigidbody>().gameObject.transform.localScale *= 1.1f;
            Transform t = Player.Instance.GetComponentInChildren<MeshRenderer>().gameObject.transform;
            t.localScale = new Vector3(t.localScale.x + 0.03f, t.localScale.y + 0.03f, t.localScale.z + 0.03f);
            t.position = new Vector3(t.position.x, t.position.y + 0.015f, t.position.z);

            SoundManager.Instance.OnPickup();
            Destroy(gameObject);
        }
        else
        {
            //Debug.Log("Trigger Enter Collectible - wasn't Tree");
            //Collectible dissapears
            //Add 1 to number of coll
        }

    }

}
