using UnityEngine;
using System.Collections;

public class RotateEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnWaves ());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate(Vector3.forward, Time.deltaTime * 20, Space.World);

	}

	IEnumerator SpawnWaves()
	{
		for (int i=0; i<12; i++) {
			yield return new WaitForSeconds (3);
			try
			{

			GameObject.Find("Misc"+i).GetComponent<Rigidbody> ().velocity = transform.up * -5;
			}
			catch (System.NullReferenceException) {
				//Do other stuff.
			}
		}
		yield return new WaitForSeconds (2);
		Destroy (gameObject);
	}
}
