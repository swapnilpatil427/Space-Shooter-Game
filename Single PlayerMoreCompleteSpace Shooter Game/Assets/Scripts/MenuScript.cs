using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class MenuScript : MonoBehaviour {
	
	public Canvas HighScorePopup;
	public Text highscoretext;
	public Canvas info;
	// Use this for initialization
	void Start () {
		HighScorePopup.enabled = false;
		info.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("escape"))
			Application.Quit();
	}
	
	public void singleplayeraction()
	{
		Application.LoadLevel (1);
	}

	public void Infoaction()
	{
		info.enabled = true;
	}

	public void HighScoreaction()
	{
		var  fileName = "MyFile.txt";
		HighScorePopup.enabled = true;
		if(File.Exists(fileName)){
			Debug.Log("Existes");
			var sr = File.OpenText(fileName);
			var line = sr.ReadLine();
			Debug.Log(line);
			highscoretext.text ="1st: " + line.ToString();
//			while(line != null){
//			//	Debug.Log(line); // prints each line of the file
//				highscoretext.text ="1st: " + line;
//				sr.ReadLine();
//
//			}  
//			sr.Close();
		} else {
		Debug.Log("Could not Open the file: " + fileName + " for reading.");
		return;
	}
	}
	public void HighScoreBackPressee()
	{
		HighScorePopup.enabled = false;
		info.enabled = false;
	}
}
