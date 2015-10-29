using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Player2Controller : MonoBehaviour {
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
		Instantiate(Shot, shotspawn.position, shotspawn.rotation);

		
	}
	// Update is called once per frame
	void FixedUpdate () {
		rb = GetComponent<Rigidbody> ();
		
		rb.velocity = new Vector3(Input.GetAxis("Horizontal2"),0 , Input.GetAxis("Vertical2")) * speed;
		Boundary boundary = new Boundary ();
		rb.transform.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
			);
		
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * tilt);
	}
}