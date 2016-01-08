using UnityEngine;
using System.Collections;

public class PauseGameScreen : MonoBehaviour {
	public GameObject pitchRecognitionControllerPreFab;
	// Use this for initialization
	void Start () {
		if (PlayerPrefsManager.GetIsFirstTime () == 1 && this.gameObject.name=="PauseGameScreen (1)")
			this.gameObject.SetActive (false);
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	public void LetMeGoBack(){
		VibrationManager.Vibrate(40);
		Time.timeScale=1;

		Instantiate (pitchRecognitionControllerPreFab);
		this.gameObject.SetActive (false);
		GameGrid grid = FindObjectOfType<GameGrid> ();
		 grid.isStopped = false;
		PlayerPrefsManager.SetIsFirstTime (1);
		Invoke ("disappearArrowes", 10);


	}

	public void disappearArrowes(){
		GameObject.Find ("ArrowsCanvas").SetActive (false);

	}

	public void BackToMenue(){
		VibrationManager.Vibrate(40);
		Time.timeScale=1;
	//	Instantiate (pitchRecognitionControllerPreFab);
	//	this.gameObject.SetActive (false);
		Application.LoadLevel("MainMenu");

		
		
	}

	public void PauseTheGame(){
		VibrationManager.Vibrate(40);

		Time.timeScale=0;

	}

	public void ToMainMenu(){
		VibrationManager.Vibrate(40);

		Time.timeScale=1;
		
	}
}
