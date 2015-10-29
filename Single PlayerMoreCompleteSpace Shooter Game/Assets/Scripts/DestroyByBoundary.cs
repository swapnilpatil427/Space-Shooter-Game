using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	// Use this for initialization
	void OnTriggerExit (Collider other) {
		if (other.gameObject.name == "Sphere") {
		} else if (other.gameObject.tag == "RoundShip") {
		}
		  else
		Destroy (other.gameObject);
	}


}
