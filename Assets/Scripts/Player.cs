﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    NoiseRadius noise;

    internal Vector3 direction = Vector3.zero;
    internal Vector3 direction_normalized;

    internal float movementSpeed;
    int numCollectibles = 0;

	void Start() {
		// position player in entrance
        // init other stuff
	}
	
	void Update() {
        // player input (4 dir movement)

        direction.x = Input.GetAxis("Horizontal");
        direction.y = 0;
        direction.z = Input.GetAxis("Vertical");
        direction_normalized = direction.normalized;
        Debug.Log("IHAMAIMC direction vector " + direction.ToString());

        transform.Translate(direction_normalized.x * GameDesign.Instance.playerSpeed * Time.deltaTime, direction.y, direction_normalized.z * GameDesign.Instance.playerSpeed * Time.deltaTime);

        // animate

        // activate noise radius only when the player is moving
    }
}
