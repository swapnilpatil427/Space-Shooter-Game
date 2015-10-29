using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[System.Serializable]
public class Boundary
{
	public float xMin=-5.5f,xMax=4.96f,zMin=-1.0f,zMax=9.0f;
}

public class PlayerController : MonoBehaviour {
	Rigidbody rb;
	public float speed;
	public float tilt;
	public GameObject Shot;
	public Transform shotspawn;
	public float fireRate;
	private float nextFire;
	public Image healthbar;
	private float currenthealth;
	public float getcurrenthealth()
	{
		return currenthealth;
	}
	public void setcurrenthealth()
	{
		currenthealth = currenthealth - 1;
		healthbar.fillAmount = currenthealth / maxhealth;
	}
	public float maxhealth;
	void Start()
	{
		currenthealth = maxhealth;
	}
	void Update()
	{
		if (gameObject.tag == "Player") {
			if (Input.GetButton ("Fire1") && Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				Shot.tag = "Shot";
				Instantiate (Shot, shotspawn.position, shotspawn.rotation);
				GetComponent<AudioSource> ().Play ();
			}
		} else {
			if (Input.GetButton ("Fire2") && Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				Shot.tag = "Shot2";
				Instantiate (Shot, shotspawn.position, shotspawn.rotation);
				GetComponent<AudioSource> ().Play ();
			}
		}

	}
	// Update is called once per frame
	void FixedUpdate () {
		rb = GetComponent<Rigidbody> ();
		if (gameObject.tag == "Player") {
			rb.velocity = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")) * speed;
		}
		else
			rb.velocity = new Vector3 (Input.GetAxis ("Horizontal2"), 0, Input.GetAxis ("Vertical2")) * speed;
		Boundary boundary = new Boundary ();
		rb.transform.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * tilt);
	}
}
