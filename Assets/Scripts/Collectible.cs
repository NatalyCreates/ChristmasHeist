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
            StopAllCoroutines();
            StartCoroutine(LerpGrowShrinkTree());

            //Transform t = Player.Instance.GetComponentInChildren<MeshRenderer>().gameObject.transform;
            //Vector3 newScale = new Vector3(t.localScale.x + 0.08f, t.localScale.y + 0.08f, t.localScale.z + 0.08f);
            //t.localScale = newScale;

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

    IEnumerator LerpGrowShrinkTree() {
        Transform t = Player.Instance.GetComponentInChildren<MeshRenderer>().gameObject.transform;
        Vector3 newScale = new Vector3(t.localScale.x + 0.08f, t.localScale.y + 0.08f, t.localScale.z);
        Vector3 newScalePlus = new Vector3(t.localScale.x + 1.5f, t.localScale.y + 1.5f, t.localScale.z);
        Vector3 newPos = new Vector3(t.position.x, t.position.y + 0.04f, t.position.z);
        Vector3 newPosPlus = new Vector3(t.position.x, t.position.y + 0.75f, t.position.z);

        float totalTime = 0.25f;
        float elapsedTime = 0f;
        Vector3 initScale = t.localScale;
        //localPosition
        //Vector3 initPos = t.position;

        while (elapsedTime < totalTime) {
            t.localScale = Vector3.Lerp(initScale, newScale, (elapsedTime / totalTime));
            elapsedTime += Time.deltaTime;
            //t.position = Vector3.Lerp(initPos, newPosPlus, elapsedTime / totalTime);
            yield return null;
        }
        if (elapsedTime >= totalTime) {
            //t.localScale = newScalePlus;
            //t.position = newPosPlus;
        }
        //t.localScale = newScale;

        //yield return new WaitForSeconds(3f);

        /*
        elapsedTime = 0f;
        while (elapsedTime < totalTime) {
            elapsedTime += Time.deltaTime;
            t.localScale = Vector3.Lerp(t.localScale, newScale, elapsedTime / totalTime);
            //localPosition
            t.position = Vector3.Lerp(t.position, newPos, elapsedTime / totalTime);
            yield return null;
        }
        t.localScale = newScale;
        t.position = newPos;
        */
    }
}
