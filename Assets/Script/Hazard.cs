using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Hazard : MonoBehaviour {
	public GameObject respawnPoint;
	public GameController Game;

	public Text hudText;
	
	int death = 0;

	// Use this for initialization
	void Start () {
		hudText = GameObject.Find("DeathText").GetComponent<Text>();

	
	}
	
	// Update is called once per frame
	void Update () {
		string hudInfo = "";

		hudInfo += "Death: " + death + "\n";
		hudText.text = hudInfo;


	}

	void OnTriggerEnter(Collider other) {
		//Game.RespawnPlayer();
		other.gameObject.transform.position = respawnPoint.transform.position;
		death = death + 1;

		print ("You have died " + death + " times");
	
	}



}
