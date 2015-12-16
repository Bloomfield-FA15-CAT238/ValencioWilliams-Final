using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

public class GameController : MonoBehaviour {
	Text hudText;

	public static PlayerPrefs playerData;

	public GameObject player;
	public GameObject respawnPoint;
	
	public int score;
	public int lives;
	public float timeInGame;
	public int currentLevel;

	public ParticleSystem winningParticles;

	public Text hud;
	public Canvas gameOverUI;
	
	private float time = 0;
	public int death = 0;
	
	private bool isRunning = false;
	
	void Awake(){
		if (PlayerPrefs.HasKey ("score")) {
			RestorePlayerValues ();
		} else {
			StartNewGame ();
		}

	}

	void Start () {
		InitGame();
		hudText = GameObject.Find("HUDText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		string hudInfo = "";
		
		timeInGame += Time.deltaTime;

		hudInfo += "Level: " + (currentLevel+1) + "\n";
		hudInfo += "Score: " + score + "\n";
		hudInfo += "Lives: " + lives + "\n";
		hudInfo += "Time: " + timeInGame.ToString ("F2");
		hudText.text = hudInfo;

		/*
		if (isRunning) {
			time += Time.deltaTime;
			hud.text = "Your time is " + (int)time;
		} 
		else
		{
			hud.text = "Your time was " + time; 
		}

		if(Input.GetAxis("Restart")>0) {
			RespawnPlayer();
		}*/
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

	public void FoundCoin(){
		score += 100;
	}

	public void RespawnPlayer() {
		player.gameObject.transform.position = respawnPoint.transform.position;
		while (currentLevel == 1) {
			lives = lives - 1;
		}
	}

	public void LevelUp() {
		currentLevel = Application.loadedLevel + 1;
		StorePlayerValues ();
		Application.LoadLevel (Application.loadedLevel + 1);
	}
	
	public void LevelDown() {
		currentLevel = Application.loadedLevel - 2;
		DeletePlayerValues ();
		Application.LoadLevel (Application.loadedLevel - 2);
	}

	public void InitGame() {
		time = 0;
		isRunning = true;

		gameOverUI.enabled = false;

		winningParticles.Stop();
		winningParticles.Clear();
		RespawnPlayer();
	}

	public void Win() {
			isRunning = false;
			gameOverUI.enabled = true;
			winningParticles.Play ();
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

	public void DeletePlayerValues() {
		PlayerPrefs.DeleteKey ("score");
		PlayerPrefs.DeleteKey ("lives");
		PlayerPrefs.DeleteKey ("timeInGame");
		PlayerPrefs.DeleteKey ("currentLevel");
	}
}
