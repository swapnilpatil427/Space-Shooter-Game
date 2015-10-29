using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SinglePlayerGameController : MonoBehaviour {
	public GameObject astroid;
	public float waittime;
	public float wavewaittime;
	public Vector3 spawnposition;
	private int score;
	public Text scoretext;
	public Text gameovertext;
	public Text restartext;
	private bool gameoverflag;
	private bool restartflag;
	
	// Use this for initialization
	void Start () {
		gameoverflag = false;
		restartflag = false;
		StartCoroutine(SpawnWaves ());
		score = 0;
		scoretext.text = "Score : " + score;
		gameovertext.text = "";
		restartext.text = "";
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

			gameovertext.text = "Game Over";

		gameoverflag = true;
		
	}
	
	void UpdateScore ()
	{

			scoretext.text = "Score : " + score;

	}
	
	// Update is called once per frame
	IEnumerator SpawnWaves () {
		while (true) {
			yield return new WaitForSeconds (wavewaittime);
			for (int i=0; i<5; i++) {
				Vector3 spawnvalue = new Vector3 (Random.Range (-spawnposition.x, spawnposition.x), spawnposition.y, spawnposition.z);
				Quaternion q = Quaternion.identity;
				Instantiate (astroid, spawnvalue, q);
				yield return new WaitForSeconds (waittime);
			}
			if(gameoverflag == true)
			{
				restartext.text = "Press R to Restart";
				restartflag = true;
			}
		}
	}
}
