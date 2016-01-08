using UnityEngine;
using System.Collections;

public class GiveGravityScale : MonoBehaviour {
	public Rigidbody2D myRigidbody2D;
	void Start () {
		myRigidbody2D.gravityScale = 0;
		Time.timeScale = 2f;

		Invoke ("GravityScale", 4);
		Invoke ("InstanciatePitch4ForAnimationPrefab", 7);
		Invoke ("GenderLoadLevel", 10.5f);
		Invoke ("InstanciateBrokenGlass", 9.2f);

	}
	void GravityScale () {
		myRigidbody2D.gravityScale = 0.6f;

	}
	void InstanciatePitch4ForAnimationPrefab(){
		GameObject go= (GameObject)Resources.Load ("Prefabs/PitchFor4Splash");
		Instantiate (go);
	}
	void InstanciateBrokenGlass(){
		GameObject go = (GameObject)Resources.Load ("prefabs/BrokenGlass");
		Instantiate (go);
	}
	void OnCollisionEnter2D(Collision2D floor){
			GameObject go= (GameObject)Resources.Load ("Prefabs/SoundPrefabs/ClinkSound");

			Instantiate (go);

	}
	void GenderLoadLevel (){
		if (PlayerPrefsManager.GetIsFirstTime () == 0) {

			Application.LoadLevel ("Gender");
		
		}
		else
			Application.LoadLevel("MainMenu");
	}
}
