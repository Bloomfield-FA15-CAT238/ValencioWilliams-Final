using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public void StartLevel () 
	{
		Application.LoadLevel (1); 
		GameController gc = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		gc.DeletePlayerValues();
	}

	
}