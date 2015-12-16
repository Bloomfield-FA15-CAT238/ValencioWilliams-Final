using UnityEngine;
using System.Collections;

 class Pickup : MonoBehaviour {
	public GameController GameController;

	int key = 0;
	// Use this for initialization

	
	// Update is called once per frame
	void OnTriggerEnter () {
		Destroy (this.gameObject);
		key = key + 1;

		if (key == 1) {
			Destroy (GameObject.FindWithTag("Gate"));
			print ("Collected " + key + " key");

		}

	}


}
