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
            /*
            Transform t = Player.Instance.GetComponentInChildren<MeshRenderer>().transform;
            Vector3 newScale = new Vector3(t.localScale.x + 0.04f, t.localScale.y + 0.04f, t.localScale.z + 0.04f);
            Vector3 newPos = new Vector3(t.localPosition.x, t.localPosition.y + 0.02f, t.localPosition.z);
            t.localScale = newScale;
            t.localPosition = newPos;
            */
            SoundManager.Instance.OnPickup();
            Destroy(gameObject);
        }

    }
}
