using UnityEngine;
using System.Collections;

public class PowerUpTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider Other) {
		Debug.Log (Other.gameObject);
	}
}
