using UnityEngine;
using System.Collections;

public class NewHighScoreScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("VibarateNewHighScore", 1.4f);
		Invoke ("SelfDestruct", 3.5f);

	}
	void VibarateNewHighScore(){
		VibrationManager.Vibrate(700);
		
	}
	// Update is called once per frame
	void SelfDestruct () {
		Destroy (gameObject);
	}
}
