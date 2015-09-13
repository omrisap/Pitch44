using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void Start () {

	}

	public void LoadLevel(string name){
		VibrationManager.Vibrate(40);

		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		VibrationManager.Vibrate(40);

		Application.Quit ();
	}
	
	public void LoadNextLevel() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
