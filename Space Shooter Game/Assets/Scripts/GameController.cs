using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject astroid;
	public float waittime;
	public float wavewaittime;
	public Vector3 spawnposition;
	private int player1score;
	private int player2score;
	public Text scoretext;
	public Text score2text;
	public Text gameovertext;
	public Text restartext;
	private bool gameoverflag;
	private bool restartflag;

	// Use this for initialization
	void Start () {
		gameoverflag = false;
		restartflag = false;
		StartCoroutine(SpawnWaves ());
		player1score = player2score = 0;
		scoretext.text = "Player 1 Score : " + player1score;
		score2text.text = "Player 2 Score : " + player2score;
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
	
	public void AddScore (int player, int scorevalue)
	{
		if (player == 1) {
			player1score += scorevalue;
			UpdateScore (player);
		}
		else
		{
			player2score += scorevalue;
			UpdateScore (player);
		}
	}

	public void gameover(int player)
	{
		if (player == 1) {
			gameovertext.text = "Player 1 Wins ";
		} else {
			gameovertext.text = "Player 2 Wins";
		}
		gameoverflag = true;

	}
	
	void UpdateScore (int player)
	{
		if (player == 1) {
			scoretext.text = "Player 1 Score : " + player1score;
		}
		else
		{
			score2text.text = "Player 2 Score : " + player2score;
		}

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
