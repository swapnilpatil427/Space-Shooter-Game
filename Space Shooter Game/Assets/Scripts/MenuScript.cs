using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
	
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

	public void doubleplayeraction()
	{
		Application.LoadLevel (2);
	}
}
