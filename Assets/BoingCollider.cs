using UnityEngine;
using System.Collections;

public class BoingCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D ball){
		VibrationManager.Vibrate(40);

		GameObject go= GameObject.Find("BoingSound");
		print (go);
		if(transform.position.x>=21.84f && go==null){
			SuctionSoundFX boingSound= Resources.Load<SuctionSoundFX> ("prefabs/SoundPrefabs/BoingSound");
			Instantiate(boingSound);
			ball.gameObject.GetComponent<Rigidbody2D>().velocity=Vector2.left*(5);
		}
	}
	void OnTriggerEnter2D(Collider2D ball){
		ball.gameObject.GetComponent<Rigidbody2D>().velocity=Vector2.zero;

	}


}
