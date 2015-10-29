using UnityEngine;
using System.Collections;

public class Destroy_Astroid : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerexplosion;
	private GameController gamecontroller;
	public int scorevalue;
	private PlayerController playercontroller;
	private PlayerController player2controller;
	void Start()
	{
		GameObject playerControllerObject = GameObject.FindWithTag ("Player");
		GameObject player2ControllerObject = GameObject.FindWithTag ("Player2");
		if (playerControllerObject != null)
		{
			playercontroller = playerControllerObject.GetComponent <PlayerController>();
		}
		if (playerControllerObject != null)
		{
			player2controller = player2ControllerObject.GetComponent <PlayerController>();
		}
		if (playercontroller == null)
		{
			Debug.Log ("Cannot find 'PlayerController' script");
		}
		if (player2controller == null)
		{
			Debug.Log ("Cannot find 'Player2Controller' script");
		}
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gamecontroller = gameControllerObject.GetComponent <GameController>();
		}
		if (gamecontroller == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	// Use this for initialization
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "boundary")
			return;
		else if (other.gameObject.tag == "Player") {

			playercontroller.setcurrenthealth ();
			if (playercontroller.getcurrenthealth() == 0) {
				Instantiate (playerexplosion, transform.position, transform.rotation);
				gamecontroller.gameover (2);
				other.gameObject.SetActive(false);
				//Destroy (other.gameObject);
			} 
			Destroyastroid();
		}
		else if (other.gameObject.tag == "Player2") {
			
			player2controller.setcurrenthealth ();
			if (player2controller.getcurrenthealth() == 0) {
				Instantiate (playerexplosion, transform.position, transform.rotation);
				gamecontroller.gameover (1);
				Destroy (other.gameObject);
			} 
			Destroyastroid();
		}
		else {
			Destroyastroid();
			if(	other.gameObject.tag == "Shot")
			gamecontroller.AddScore (1,scorevalue);
			else
				gamecontroller.AddScore (2,scorevalue);
			Destroy (other.gameObject);
		}
	}

	void Destroyastroid()
	{
		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (gameObject);
	}

}
