using UnityEngine;
using System.Collections;

public class SinglePLayerDestroyAstroid : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerexplosion;
	private SinglePlayerGameController gamecontroller;
	public int scorevalue;
	private SinglePlayerController playercontroller;

	void Start()
	{
		GameObject playerControllerObject = GameObject.FindWithTag ("Player");
		if (playerControllerObject != null)
		{
			playercontroller = playerControllerObject.GetComponent <SinglePlayerController>();
		}
		if (playercontroller == null)
		{
			Debug.Log ("Cannot find 'PlayerController' script");
		}
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gamecontroller = gameControllerObject.GetComponent <SinglePlayerGameController>();
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
				gamecontroller.gameover();
				//other.gameObject.SetActive(false);
				Destroy (other.gameObject);
			} 
			Destroyastroid();
		}
		else {
			Destroyastroid();
			gamecontroller.AddScore(scorevalue);
			Destroy (other.gameObject);
		}
	}
	
	void Destroyastroid()
	{
		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (gameObject);
	}
	
}
