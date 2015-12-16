using UnityEngine;
using System.Collections;

public class LoadLevelA : MonoBehaviour {
	public string levelName;

	// Use this for initialization
	void LoadLevelNow (string x) 
	{
		Application.LoadLevel (x);
		GameController gca = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		gca.DeletePlayerValues();
	}
	
	// Update is called once per frame

}
