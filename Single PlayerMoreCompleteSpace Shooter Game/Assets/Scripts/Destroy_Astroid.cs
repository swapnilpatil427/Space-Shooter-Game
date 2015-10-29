using UnityEngine;
using System.Collections;

public class Destroy_Astroid : MonoBehaviour {


	public int scorevalue;

	void Start()
	{

	}
	// Use this for initialization
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "boundary")
			return;


		else if (other.gameObject.tag == "EnemyShot") {

			}
		else if (other.gameObject.tag == "PowerUp") {
			
		}
	}



}
