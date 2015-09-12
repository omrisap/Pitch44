using UnityEngine;
using System.Collections;

public class PauseGameScreen : MonoBehaviour {
	public GameObject pitchRecognitionControllerPreFab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LetMeGoBack(){
		VibrationManager.Vibrate(40);
		Time.timeScale=1;

		Instantiate (pitchRecognitionControllerPreFab);
		this.gameObject.SetActive (false);


	}
	public void BackToMenue(){
		VibrationManager.Vibrate(40);
		Time.timeScale=1;
	//	Instantiate (pitchRecognitionControllerPreFab);
	//	this.gameObject.SetActive (false);
		Application.LoadLevel("MainMenu");

		
		
	}
}
