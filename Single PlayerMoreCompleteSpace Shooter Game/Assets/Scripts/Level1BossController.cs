using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level1BossController : MonoBehaviour {
	public GameObject Level1bossobject;
//	public GameObject missile1;
	public GameObject shot;
	public float maxhealth;
    public float currenthealth;
	public Transform gun1shotposition;
	public Transform gun2shotposition;
	public Transform gun3shotposition;
	public Transform gun4shotposition;
	public GameObject missile1;
	Rigidbody bossrigidbody;
	public int enemyscore;
	public Text enemytext;
	public Image enemyhealthbar;
	SinglePlayerGameController gamecontroller=null;
	MeshRenderer meshRenderer;
	Boundary1 boundary;
	Vector3 move;
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		currenthealth = maxhealth;
		GameObject enemytextobj = GameObject.Find ("EnemyText");
		enemytext = enemytextobj.GetComponent<Text> ();
		enemytext.text = "Enemy Health:" + currenthealth;
		GameObject enemyhealthbarobj =GameObject.Find ("EnemyHealthbar");
		enemyhealthbar = enemyhealthbarobj.GetComponent<Image> ();
		enemyhealthbar.fillAmount = 0;
	//	enemyhealthbar =(Image) GameObject.Find ("EnemyHealthbar");
		//gun1shotoffset = transform.position - gun1shotposition.position;
		boundary = new Boundary1 ();
		bossrigidbody = gameObject.GetComponent<Rigidbody> ();
		GameObject GameControllerObject = GameObject.FindWithTag ("GameController");
		
		if (GameControllerObject != null) {
			gamecontroller = GameControllerObject.GetComponent <SinglePlayerGameController> ();
		}
		
		if (gamecontroller == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}


		//meshRenderer = gameObject.AddComponent<MeshRenderer>();
		StartCoroutine(SpawnShots ());
		GetComponent<Animation> ().Play ();
		move = new Vector3(0.5f, 0f, 0);
		bossrigidbody.velocity= move * -2.0f;
	}

	void Update()
	{

	//	transform.position.x += 0.1f; 

		if(transform.position.x <= boundary.xMin)
		move = new Vector3(-0.5f, 0f, 0);
		if(transform.position.x >= boundary.xMax)
			move = new Vector3(0.5f, 0f, 0);
		bossrigidbody.velocity= move * -3.0f;
	
	}
	public void setcurrenthealth()
	{
		currenthealth = currenthealth - 2;
		if (currenthealth >= 0) {
			enemytext.text = "Enemy Health:" + currenthealth;
			enemyhealthbar.fillAmount = currenthealth / maxhealth;
		
		} else {
			EnemyDead();
		}
		
	}
	public void EnemyDead()
	{
		gamecontroller.DestroyEnemy (gameObject);
		gamecontroller.enemyship = null;
		gamecontroller.AddScore (enemyscore);
		enemytext.text = "";
		gamecontroller.resetcounters ();
	//	enemytext.text = "You Win";
		//gamecontroller.gameover ();

	}

	IEnumerator SpawnShots ()
	{
		//GameObject shottemp = shot;
		yield return new WaitForSeconds (1);
		//Vector3 spawnvalueoffset = transform.position + gun1shotoffset;
		Quaternion euler = Quaternion.identity;
		Quaternion q = Quaternion.identity;
		StartCoroutine(LaunchMissiles ());
		while (true) {
		
		//	enemytext.text = "Enemy Health" + currenthealth;
			yield return new WaitForSeconds (0.8f);
			Instantiate (shot, gun1shotposition.position, q);

			Instantiate (shot, gun2shotposition.position, q);
			euler.eulerAngles = new Vector3 (0, 28, 0);
			//yield return new WaitForSeconds (1);
			Instantiate (shot, gun3shotposition.position, euler);

			euler.eulerAngles = new Vector3 (0, 332, 0);
			//yield return new WaitForSeconds (1);
			Instantiate (shot, gun4shotposition.position, euler);
		}
	}

	IEnumerator LaunchMissiles ()
	{ 
		for(int i=1;i<=10 ; i++)
		{
			yield return new WaitForSeconds (4.0f);
		
		
			LaunchMissile ("Object0"+(i+10).ToString());
		
	
		}
			
	}


 void LaunchMissile(string ObjectName)
	{

		try{
			if(player != null)
			{
			GameObject rocket = GameObject.Find (ObjectName);
			rocket.GetComponent<Rigidbody> ().isKinematic = false;
			//rocket.transform.position = new Vector3 (rocket.transform.position.x, 0.23f, rocket.transform.position.z);
			rocket.AddComponent <EnemySmartRocketMover>();
			Vector3 targetDir = rocket.transform.position - player.transform.position;
			Vector3 forward = transform.up;
			float angle = Vector3.Angle (targetDir, forward);
			if (rocket.transform.position.x < player.transform.position.x)
				rocket.transform.rotation = Quaternion.AngleAxis (-angle, Vector3.up);
			else
				rocket.transform.rotation = Quaternion.AngleAxis (angle, Vector3.up);
			//rocket.transform.rotation = Quaternion.AngleAxis(30, Vector3.up);
			rocket.GetComponent<CapsuleCollider> ().enabled = true;
			rocket.GetComponent<CapsuleCollider> ().isTrigger = true;
			rocket.GetComponent<EnemySmartRocketMover> ().speed = -4;
			rocket.GetComponent<EnemySmartRocketMover> ().Move ();
			}
		}
		catch(UnityException)
		{
		}

	}


}
