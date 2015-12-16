using UnityEngine;
using System.Collections;

public class LevelDown : MonoBehaviour {
	public void RestartNewGame() {
		GameController gc = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		gc.LevelDown();
	}
}
