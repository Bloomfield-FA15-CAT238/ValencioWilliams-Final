using UnityEngine;
using System.Collections;

public class Win2 : MonoBehaviour {
	public GameController gameController;
	public GameObject respawnPoint;

	//GameController gc = GameObject.FindWithTag("GameController").GetComponent<GameController>();

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		//Application.LoadLevel (2);
		GameController gc = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		gc.LevelUp();

		//gameController.Win();

	}
}
