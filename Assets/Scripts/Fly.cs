using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {

	public GameObject flyingBall;
	void Start () {
		Invoke("catapultBall",5.4f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D ball){
		if (ball.gameObject.tag == "Ball") {
			Rigidbody2D rb=gameObject.GetComponent<Rigidbody2D>();
			rb.velocity=new Vector2(-6.5f,6.5f);
			rb.angularVelocity=2;
		}


	}
	void catapultBall(){
		flyingBall.GetComponent<Rigidbody2D>().velocity=new Vector2(-6.5f,6.5f);
	}
}
