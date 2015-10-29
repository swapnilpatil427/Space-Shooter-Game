using UnityEngine;
using System.Collections;

public class EnemySmartRocketMover : MonoBehaviour {

	public float speed;
	public Transform playerPosition;
	SinglePlayerGameController gamecontroller;
	// Use this for initialization
	public void Move () {
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.velocity= transform.forward * speed;
	}
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gamecontroller = gameControllerObject.GetComponent <SinglePlayerGameController> ();
		}
		if (gamecontroller == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	void OnTriggerEnter (Collider other) {
	
		if (other.gameObject.tag == "Player")
			Destroy (other.gameObject);
		
		
		else if (other.gameObject.tag == "Shot")
		{
			gamecontroller.instantiatepowerup(other.gameObject);
			Destroy(gameObject);
			Destroy(other.gameObject);
		}
		else if (other.gameObject.tag == "PowerUp") {
			
		}
		
	}

}
