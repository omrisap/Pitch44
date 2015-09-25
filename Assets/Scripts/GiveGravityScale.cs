using UnityEngine;
using System.Collections;

public class GiveGravityScale : MonoBehaviour {
	public Rigidbody2D myRigidbody2D;
	void Start () {
		myRigidbody2D.gravityScale = 0;
		Invoke ("GravityScale", 4);
		Invoke ("InstanciatePitch4ForAnimationPrefab", 7);
		Invoke ("SplashLoadLevel", 10);

	}
	void GravityScale () {
		myRigidbody2D.gravityScale = 0.6f;

	}
	void InstanciatePitch4ForAnimationPrefab(){
		GameObject go= (GameObject)Resources.Load ("Prefabs/PitchFor4Splash");
		Instantiate (go);
	}
	void OnCollisionEnter2D(Collision2D floor){
			GameObject go= (GameObject)Resources.Load ("Prefabs/SoundPrefabs/ClinkSound");

			Instantiate (go);

	}
	void SplashLoadLevel (){
		Application.LoadLevel ("MainMenu");
	}
}
