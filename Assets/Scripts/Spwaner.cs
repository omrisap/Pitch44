using UnityEngine;
using System.Collections;

public class Spwaner : MonoBehaviour {
	public Ball preFarbBall;
	private Vector4[] colorsArray;
	private static int countCallForSpwan=0;
	public Sprite[] eyes;
	void Start () {

		PlayerPrefsManager.SetIsFirstTime (1);
		 
		colorsArray = new Vector4[5];
		colorsArray [0] = new Vector4 (1, 0.92f, 0.016f, 1);
		colorsArray [1] = new Vector4 (1, 0, 0, 1);
		colorsArray [2] = new Vector4 (0, 0, 1, 1);
		colorsArray [3] = new Vector4 (1, 0, 1, 1);
		colorsArray [4] = new Vector4 (0, 1, 0, 1);
		

		Invoke("Spwan",2);   
		if (PlayerPrefsManager.GetVolumeIsOn () == 0) {
			AudioListener.volume = 1 - AudioListener.volume;
			Invoke ("ReturnSound", 3);
		}
	//	SpwanRandomForStart ();
	}
	private void ReturnSound(){

		AudioListener.volume = 1-AudioListener.volume;

	}

	private void SpwanRandomForStart(){

		foreach (Transform origin in transform) {
			float rand= Random.value;
			if (rand>0.5){

				Ball ball1 = (Ball) Instantiate (preFarbBall);
				
				ball1.GetComponent<SpriteRenderer> ().color = colorsArray[Random.Range(0,3)];
				
				ball1.transform.parent = origin.transform;
				ball1.transform.position=new Vector2(origin.position.x,origin.position.y-17);
				if (rand>0.75){

					Ball ball2 = (Ball) Instantiate (preFarbBall);
					
					ball2.GetComponent<SpriteRenderer> ().color = colorsArray[Random.Range(0,3)];
					
					ball2.transform.parent = origin.transform;
					ball2.transform.position=new Vector2(origin.position.x,origin.position.y-15);
						
					if (rand>0.88){
						Ball ball3 = (Ball) Instantiate (preFarbBall);
						
						ball3.GetComponent<SpriteRenderer> ().color = colorsArray[Random.Range(0,3)];
						
						ball3.transform.parent = origin.transform;

						ball3.transform.position=new Vector2(origin.position.x,origin.position.y-13);
					}


				}
			}

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/*
	public void RandomlySpwanBalls(){
		if(Time.timeSinceLevelLoad>2){
			
		if(GameGrid.GetfoundSequence()){
		
			countCallForSpwan++;
		
			Invoke("Spwan",0.5f);
			
			
			}else{
			
			Spwan();
			}
		}
		

	}*/
	public void Spwan(){
		Invoke("Spwan",4.5f -Time.timeSinceLevelLoad*0.002f);   
		
		
			int rand;
			rand = Random.Range (0, 11);
			
			Transform origin = this.gameObject.transform.GetChild (rand);
			
			Ball ball = (Ball) Instantiate (preFarbBall, origin.position, Quaternion.identity);
			int randColorAndEyes = Random.Range (0, 3);
			ball.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = eyes [randColorAndEyes];

		//For eran
//			if (randColorAndEyes=0)(
//				ball.transform.GetChild (0).transform=
//			)
//			if (randColorAndEyes=1)(
//				ball.transform.GetChild (0).transform=
//				)



			ball.GetComponent<SpriteRenderer> ().color = colorsArray[randColorAndEyes];
		
			ball.transform.parent = origin.transform;
			
			
		
			
	}	

	
}
