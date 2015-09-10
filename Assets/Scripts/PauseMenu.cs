using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	private string level;
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Setlevel(string setLevel){

		level = setLevel;

	}


	public void OkayGotIt(){
		FloorTrigger.isTouchEnabledFirstTime = true;
		Time.timeScale = 1;
		GameObject pauseMenu =GameObject.Find("PauseScreen") ;
		VibrationManager.Vibrate(40);

		pauseMenu.gameObject.SetActive(false);

	}
	public void EnablePressing(){
	
		FloorTrigger.isTouchEnabledFirstTime = true;
		FloorTrigger.isTouchEnabledallways = true;
		Time.timeScale = 1;
		GameObject pauseMenu =GameObject.Find("PauseScreen") ;
		VibrationManager.Vibrate(40);

		pauseMenu.gameObject.SetActive(false);
		print ("level " + level);
		print ("ok");
			Application.LoadLevel(level);
	}
}
