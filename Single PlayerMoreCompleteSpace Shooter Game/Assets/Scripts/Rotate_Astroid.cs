﻿using UnityEngine;
using System.Collections;

public class Rotate_Astroid : MonoBehaviour {
	public float tumble;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * tumble;
	}
}
