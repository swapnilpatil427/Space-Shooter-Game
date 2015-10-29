using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;


public class SinglePlayerGameController : MonoBehaviour {
	public GameObject astroid;
	public GameObject astroid1;
	public GameObject astroid2;
	public GameObject astroidexplosion;
	public GameObject playerexplosion;
	public float waittime;
	public GameObject enemyGameobject;
	public float wavewaittime;
	public Vector3 spawnposition;
	private int score;
	public Text scoretext;
	public Text enemytext;
	public Text gameovertext;
	public Text restartext;
	private bool gameoverflag;
	private bool restartflag;
	int wavecountinc=5;
	public Image enemyhealthbar;
	public GameObject enemyship;
	public GameObject powerupobject;
	public GameObject roundship;
	 int wavecounter;

	private SinglePlayerController playercontroller;
	
	// Use this for initialization
	void Start () {
		enemyship = null;
		GameObject playerControllerObject = GameObject.FindWithTag ("Player");
		if (playerControllerObject != null) {
			playercontroller = playerControllerObject.GetComponent <SinglePlayerController> ();
		}
		
		if (playercontroller == null) {
			Debug.Log ("Cannot find 'PlayerController' script");
		}


		gameoverflag = false;
		restartflag = false;
		StartCoroutine(SpawnWaves ());
		score = 0;
		scoretext.text = "Score : " + score;
		gameovertext.text = "";
		restartext.text = "";
		enemytext.text = "";
		wavecounter = 0;
	}

	public void Update()
	{
		if (restartflag == true) {
			if(Input.GetKeyDown(KeyCode.R))
				Application.LoadLevel(Application.loadedLevel);
			
		}
		if (Input.GetKey ("escape"))
			Application.LoadLevel (0);
		
	}
	public void AddScore (int scorevalue)
	{
			score += scorevalue;
			UpdateScore ();	
	}
	
	public void gameover()
	{
		var  fileName = "MyFile.txt";
		if (File.Exists (fileName)) {
		File.WriteAllText (fileName, score.ToString());

		} else {
			var sr = File.CreateText (fileName);
			sr.WriteLine (score);
	
			sr.Close ();
		}
		gameovertext.fontSize = 25;
		gameovertext.text = "Game Over";
		gameoverflag = true;
		wavecountinc = 0;

	}
	
	void UpdateScore ()
	{

			scoretext.text = "Score : " + score;

	}
	public void resetcounters()
	{
		wavecountinc = 0;
		wavecounter = 0;
	}
	// Update is called once per frame
	IEnumerator SpawnWaves () {
		int number;
		while (true) {
			gameovertext.text = "Get Ready For Astroid Waves:";
			gameovertext.fontSize = 12;
			yield return new WaitForSeconds (wavewaittime);
			gameovertext.text = "";

			for (int i=0; i<wavecountinc; i++) {
				number = Random.Range(1,4);
				Vector3 spawnvalue = new Vector3 (Random.Range (-spawnposition.x, spawnposition.x), spawnposition.y, spawnposition.z);
				Quaternion q = Quaternion.identity;
				if(number ==1)
				Instantiate (astroid, spawnvalue, q);
				else if(number == 2)
					Instantiate (astroid1, spawnvalue, q);
				else if(number == 3)
					Instantiate (astroid2, spawnvalue, q);
				yield return new WaitForSeconds (waittime);
			}
			//Instantiate(enemyGameobject);
			if(gameoverflag == true)
			{
				restartext.text = "Press R to Restart";
				restartflag = true;
			}
			wavecountinc += 5;
			wavecounter++;

			if(wavecounter >3 && enemyship == null)
				Instantiate (roundship, new Vector3 (Random.Range (-spawnposition.x, spawnposition.x), spawnposition.y, spawnposition.z), Quaternion.Euler(90,0,0));
			if(enemyship == null && wavecounter == 3)
			{
				gameovertext.text = "Get Ready For The Boss:";

				yield return new WaitForSeconds (2.0f);
				gameovertext.text = "";
				enemyship= Instantiate(enemyGameobject,enemyGameobject.transform.position,enemyGameobject.transform.rotation) as GameObject;
			}
			//yield return new WaitForSeconds (20);
		}
	}
	public void Destroyastroid(GameObject Astroid)
	{
		Instantiate (astroidexplosion, Astroid.transform.position, Astroid.transform.rotation);
		Destroy (Astroid);
	}

	public void instantiatepowerup(GameObject position)
	{
		Instantiate (astroidexplosion, position.transform.position, position.transform.rotation);
		Instantiate (powerupobject,position.transform.position,Quaternion.identity);
	}
	public void DestroyPlayer(GameObject Player)
	{
	
		if (playercontroller.getcurrenthealth() <= 0) {
			gameover ();
			Instantiate (playerexplosion, Player.transform.position, Player.transform.rotation);
			Destroy (Player);
		} 
	}

	public void DestroyEnemy(GameObject Enemy)
	{
		Instantiate (playerexplosion, Enemy.transform.position, Enemy.transform.rotation);
		Destroy (Enemy);

	}
}
