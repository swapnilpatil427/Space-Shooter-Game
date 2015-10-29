using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	private SinglePlayerGameController gamecontroller;

	private SinglePlayerController playercontroller;
	private PlayerController player2controller;
	// Use this for initialization
	void Start()
	{
		GameObject playerControllerObject = GameObject.FindWithTag ("Player");

		if (playerControllerObject != null) {
			playercontroller = playerControllerObject.GetComponent <SinglePlayerController> ();
		}

		if (playercontroller == null) {
			Debug.Log ("Cannot find 'PlayerController' script");
		}

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gamecontroller = gameControllerObject.GetComponent <SinglePlayerGameController> ();
		}
		if (gamecontroller == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {

		if (other.gameObject.tag == "EnemyShot") {
			Debug.Log("Name:  " +other.gameObject.name +other.gameObject.tag );
			Destroy(other.gameObject.gameObject);
		}
	
		if (other.gameObject.tag == "Astroid") {
			Debug.Log ("ShotScriptsEnter");
		Destroy(gameObject);
			gamecontroller.Destroyastroid(other.gameObject);
				gamecontroller.AddScore (1);
			Destroy (other.gameObject);
		}
		else if (other.gameObject.tag == "PowerUp") {
			
		}
		else if (other.gameObject.tag == "RoundshipBullets") {
			Destroy (other.gameObject);
			Destroy(gameObject);
		}
	}
}
