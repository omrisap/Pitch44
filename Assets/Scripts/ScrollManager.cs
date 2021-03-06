﻿using UnityEngine;
using System.Collections;
using System;
public class ScrollManager : MonoBehaviour {
	public Camera camera;
	public GameObject header;
	public GameObject grid;
	public GameObject yourScore;
	public GameObject panel;
	public GameObject newHighScore;



	public GameObject higeScore;




	private Vector2 leftFingerPos;
	private Vector2 leftFingerLastPos;
	private Vector2 leftFingerMovedBy;
	private float numberOfEntries;

	private float slideMagnitudeX;
	private float slideMagnitudeY;
	private float globalSlideMagnitudeY;
	private float globalSlideMagnitudeYTemp;
	private float stopRate=0.02f;
	private float speedPower=0.6f;

	void Start(){
		print ("GameGrid.GetPoints ()  " + GameGrid.GetPoints ());
		print ("PlayerPrefsManager.GetHighestScore ()" +PlayerPrefsManager.GetHighestScore ());
		if (GameGrid.GetPoints () >= PlayerPrefsManager.GetHighestScore ()) {
			print ("ok");
			Instantiate(newHighScore);
		}
	}
	public void moveCamera(int place){
		print ("place  " + place);
		GameObject grid = GameObject.Find ("Grid");
		Transform child= grid.gameObject.transform.GetChild(place-1);

		Vector3 childWorldPos= child.transform.position;
		print (childWorldPos.y);



		Rigidbody2D myCameraRigidbody2D= camera.GetComponent<Rigidbody2D>();
		print (childWorldPos.y);

		myCameraRigidbody2D.transform.position = new Vector3 (0f,childWorldPos.y+0.6495f-0.27778f,0f);


		
	}
	void Update(){

		if (Input.touchCount == 1) {
			Touch touch = Input.GetTouch (0);
		
			if (touch.phase == TouchPhase.Began) {
				leftFingerPos= Vector2.zero;
				leftFingerLastPos = Vector2.zero;
				leftFingerMovedBy = Vector2.zero;
			
				slideMagnitudeX = 0;
				slideMagnitudeY = 0;
			
				// record start position
				leftFingerPos = touch.position;
			
			} else if (touch.phase == TouchPhase.Moved) {
				leftFingerMovedBy = touch.position - leftFingerPos; // or Touch.deltaPosition : Vector2
				// The position delta since last change.
				leftFingerLastPos = leftFingerPos;
				leftFingerPos = touch.position;
			
				// slide horz
				slideMagnitudeX = leftFingerMovedBy.x / Screen.width;
			
				// slide vert
				slideMagnitudeY = leftFingerMovedBy.y /20;

				globalSlideMagnitudeY=slideMagnitudeY*speedPower;
				globalSlideMagnitudeYTemp=slideMagnitudeY*speedPower;
			
			} else if (touch.phase == TouchPhase.Stationary) {
				leftFingerLastPos = leftFingerPos;
				leftFingerPos = touch.position;
			
				slideMagnitudeX = 0.0f;
				slideMagnitudeY = 0.0f;
			} else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) {
				slideMagnitudeX = 0.0f;
				slideMagnitudeY = 0.0f;
			}
		
		

		}
		numberOfEntries = grid.transform.childCount;

		Rigidbody2D myCameraRigidbody2D= camera.GetComponent<Rigidbody2D>();
		camera.transform.position = new Vector3 (camera.transform.position.x, Mathf.Clamp (camera.gameObject.transform.position.y,(numberOfEntries-4.5f)*-0.28f , 0), 0); 

		myCameraRigidbody2D.velocity=new Vector3 (0,- globalSlideMagnitudeY*10, 0);
//		header.transform.position = myCameraRigidbody2D.transform.position + new Vector3 (1.4f, 0.76f,0);

		panel.transform.position = myCameraRigidbody2D.transform.position + new Vector3 (0f,0f,0);

//		yourScore.transform.position = myCameraRigidbody2D.transform.position + new Vector3 (-1f,0.38f,0);
//		higeScore.transform.position = myCameraRigidbody2D.transform.position + new Vector3 (0.8f,0.38f,0);
	
		yourScore.GetComponent<UILabel> ().text = "Your Score " + GameGrid.GetPoints ();
		higeScore.GetComponent<UILabel> ().text = "High Score " + PlayerPrefsManager.GetHighestScore();



		if(globalSlideMagnitudeY>0.0001f || globalSlideMagnitudeY<-0.0001f){
			globalSlideMagnitudeY=globalSlideMagnitudeY-globalSlideMagnitudeYTemp*stopRate;
		}

		grid.transform.position =transform.TransformPoint(new Vector3 (-0.07f,0.1f,0));  //-  panel.transform.position	;



	}
}
