using UnityEngine;
using System.Collections;

public class ClinkSound : MonoBehaviour {

	public AudioSource myAudioSource;
	void Awake(){
		DontDestroyOnLoad(this.gameObject) ;

	}
	void Start () {
		myAudioSource.Play ();
		Invoke ("SelfDestruct",1);
	
	}
	
	// Update is called once per frame
	void SelfDestruct () {
		Destroy (gameObject);
	}
}
