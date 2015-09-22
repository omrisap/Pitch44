using UnityEngine;
using System.Collections;

public class DestoryAll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Time.timeScale = 2f;
		Invoke ("TurnOn", 5);
		Invoke ("Finish", 12);
	}
	
	void TurnOn(){
		foreach (Transform box in transform) {
		
			box.gameObject.SetActive(true);
		}

	}

	void Finish () {
		Time.timeScale = 1;

		Application.LoadLevel ("MainMenu");
	}
}
