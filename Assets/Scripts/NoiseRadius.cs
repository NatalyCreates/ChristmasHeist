using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseRadius : MonoBehaviour
{
    public static NoiseRadius Instance;
    public SphereCollider noiseCollider;

    GameObject treeMesh;

    /*
    public void ShowNoiseRadius()
    {
        // calculate radius and change sprite and collider to fit
        // turn on sprite and collider
        Debug.Log("Radius shown");
        Instance.SetActive(true);
    }

    public void HideNoiseRadius()
    {
        // turn off sprite and collider
        Debug.Log("Radius hidden");
    }
    */

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // check if we collided with a guard
        // GameManager.GameOver() if we did
    }

    void Awake()
    {
        Instance = this;
        noiseCollider = Instance.GetComponent<SphereCollider>();
    }

    void Start()
    {
        //treeMesh = GetComponentInParent<Player>().GetComponentInChildren<Rigidbody>().gameObject;
    }

    void Update()
    {
        //transform.position = new Vector3(treeMesh.transform.position.x, -0.5f, treeMesh.transform.position.z);
    }
}
