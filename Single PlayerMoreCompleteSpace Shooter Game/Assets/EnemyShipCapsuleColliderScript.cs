using UnityEngine;
using System.Collections;

public class EnemyShipCapsuleColliderScript : MonoBehaviour {
	Level1BossController	bosscontroller = null;
	GameObject enemyobject;
	MeshRenderer meshRenderer;
	// Use this for initialization
	void Start () {
		enemyobject = GameObject.Find ("Box009");
		if (enemyobject == null) {

			Debug.Log ("Cannot find 'Box 009 Controller' script");
		}
		meshRenderer = enemyobject.GetComponent<MeshRenderer> ();
		bosscontroller = GameObject.Find("Jet").GetComponent<Level1BossController> ();
		if (bosscontroller == null) {
			
			Debug.Log ("Cannot find 'Level1Boss Controller' script");
		}
		//meshRenderer = gameObject.GetComponentInParent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "EnemyShot") {
			
		} else if (other.gameObject.tag == "Astroid") {
			
		}
		else if (other.gameObject.tag == "Missile") {
			
		}
		else if (other.gameObject.tag == "PowerUp") {

		}
		else {
			StartCoroutine (wait (other.gameObject));
			
		}
	}
	
	IEnumerator wait(GameObject other)
	{
	
		meshRenderer.material.color = Color.red;
		Destroy(other);
		bosscontroller.setcurrenthealth();
		yield return new WaitForSeconds (0.1f);
		meshRenderer.material.color = Color.white;
		
	}

}
