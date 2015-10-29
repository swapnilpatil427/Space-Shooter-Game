using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
	public float destroytime; 
	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroytime);
	}
	

}
