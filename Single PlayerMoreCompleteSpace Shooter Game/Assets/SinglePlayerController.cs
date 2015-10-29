using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Boundary1
{
	public float xMin=-5.5f,xMax=4.96f,zMin=-1.0f,zMax=9.0f;
}
public class SinglePlayerController : MonoBehaviour {
	Rigidbody rb;
	public float speed;
	public float tilt;
	public GameObject Shot;

	public Transform shotspawn;
	private SinglePlayerGameController gamecontroller;
	public float fireRate;
	private float nextFire;
	public Image healthbar;
	private float currenthealth;
	public float getcurrenthealth()
	{
		return currenthealth;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "EnemyShot") {
			setcurrenthealth ();
			Destroy (other.gameObject);
			gamecontroller.DestroyPlayer (gameObject);
		} else if (other.gameObject.tag == "Astroid") {
			setcurrenthealth ();
			gamecontroller.Destroyastroid (other.gameObject);
			gamecontroller.DestroyPlayer (gameObject);
		} else if (other.gameObject.tag == "Missile") {
			currenthealth = 0;
			healthbar.fillAmount = 0;
			gamecontroller.Destroyastroid (other.gameObject);
			gamecontroller.DestroyPlayer (gameObject);
		} else if (other.gameObject.tag == "PowerUp") {
			setcurrenthealthplus();
			Destroy(other.gameObject);
		}
		else if (other.gameObject.tag == "RoundshipBullets") {
			setcurrenthealth ();
			Destroy(other.gameObject);
			gamecontroller.DestroyPlayer (gameObject);
		}
	}

	public void setcurrenthealthplus()
	{
		if (currenthealth < maxhealth) {
			currenthealth = currenthealth + 1;
			healthbar.fillAmount = currenthealth / maxhealth;
		}
	}

	public void setcurrenthealth()
	{
		currenthealth = currenthealth - 1;
		healthbar.fillAmount = currenthealth / maxhealth;
	}
	public float maxhealth;
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gamecontroller = gameControllerObject.GetComponent <SinglePlayerGameController> ();
		}
		if (gamecontroller == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
		currenthealth = maxhealth;
	}
	void Update()
	{
			if (Input.GetButton ("Fire1") && Time.time > nextFire) {
				nextFire = Time.time + fireRate;

				Instantiate (Shot, shotspawn.position, shotspawn.rotation);
				GetComponent<AudioSource> ().Play ();
			}				
	}
	// Update is called once per frame
	void FixedUpdate () {
		rb = GetComponent<Rigidbody> ();

			rb.velocity = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")) * speed;

		Boundary1 boundary = new Boundary1 ();
		rb.transform.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
			);
		
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * tilt);
	}
}

