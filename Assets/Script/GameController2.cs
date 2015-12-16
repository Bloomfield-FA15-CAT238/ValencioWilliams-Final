using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;

public class GameController2 : MonoBehaviour {
	Text hudText;

	public int score;
	public int lives;
	public float timeInGame;
	public int currentLevel;

	void Awake() {
		if (PlayerPrefs.HasKey ("score")) {
			RestorePlayerValues ();
		} else {
			StartNewGame ();
		}
	}

	void Start () {
		// We need to call this in start so that when this is called on other levels
		// we have access to the hudText and not 
		hudText = GameObject.Find("HUDText").GetComponent<Text>();
	}
	
	void Update () {
		string hudInfo = "";

		timeInGame += Time.deltaTime;

		hudInfo += "Level: " + (currentLevel+1) + "\n";
		hudInfo += "Score: " + score + "\n";
		hudInfo += "Lives: " + lives + "\n";
		hudInfo += "Time: " + timeInGame.ToString ("F2");

		hudText.text = hudInfo;
	}

	public void StartNewGame() {
		if (PlayerPrefs.HasKey ("score")) {
			DeletePlayerValues();
		}
		score = 0;
		timeInGame = 0;
		lives = 3;
		currentLevel = 0;
		StorePlayerValues ();
	}
	
	void StorePlayerValues() {
		PlayerPrefs.SetInt ("score", score);
		PlayerPrefs.SetInt ("lives", lives);
		PlayerPrefs.SetFloat ("timeInGame", timeInGame);
		PlayerPrefs.SetInt ("currentLevel", currentLevel);
	}

	void RestorePlayerValues() {
		score = PlayerPrefs.GetInt ("score");
		lives = PlayerPrefs.GetInt ("lives");
		timeInGame = PlayerPrefs.GetFloat ("timeInGame");
		currentLevel = PlayerPrefs.GetInt ("currentLevel");
	}

	void DeletePlayerValues() {
		PlayerPrefs.DeleteKey ("score");
		PlayerPrefs.DeleteKey ("lives");
		PlayerPrefs.DeleteKey ("timeInGame");
		PlayerPrefs.DeleteKey ("currentLevel");
	}
}