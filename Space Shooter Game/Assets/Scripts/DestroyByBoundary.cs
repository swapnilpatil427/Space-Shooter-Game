﻿using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	// Use this for initialization
	void OnTriggerExit (Collider other) {
		Destroy (other.gameObject);
		Debug.Log ("Shot Collected");
	}

}
