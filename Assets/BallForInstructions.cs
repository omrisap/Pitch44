using UnityEngine;
using System.Collections;

public class BallForInstructions : MonoBehaviour {

	public float middlePitch;
	private float speed=4;
//	public GameObject MakeAHighVoice;
//	public GameObject MakeALowVoice;
//	public GameObject ThatsNotHighEnough;
//	public GameObject ThatsNotLowEnough;
	public bool teachRight=true;
	private bool firstTimeLow=true;
	private bool firstTimeHigh=true;
	private GameObject SucceessSound;
	private GameObject ClappingSound;
	private GameObject ICantSingSoHighCanvas;
	private GameObject ICantSingSoLowCanvas;


	private GameObject ThatsNotHighEnough;
	private GameObject LeftArrowAnim;
	private GameObject RightArrowAnim;
	private bool countingDownRight=false;
	private bool countingDownLeft=false;
	private bool doneItOnes=false;
	private int manPitch=200;
	private int womanPitch=290;
	private int childPitch=310;

	public float StopWatch=1.5f;



	private bool MadeRightSound=false;
	private bool MadeLeftSound=false;

	private GameObject MakeALowVoice;
	private GameObject ThatsNotLowEnough;
	private GameObject Great;
	private bool flag=true;
	private bool headlineFirstTime=true;
	private bool donewithCurrentPractice=false;

	public float timeBetweenMsg=3;
	private float clock ;

	void Start () {
		if (string.Compare (PlayerPrefsManager.GetGender (), "man") == 0) {
			middlePitch = manPitch;
			print("man");
		} else if (string.Compare (PlayerPrefsManager.GetGender (), "woman") == 0) {
			
			middlePitch = womanPitch;
			print("woman");
			
		} else if (string.Compare (PlayerPrefsManager.GetGender (), "child") == 0) {
			middlePitch = childPitch;
			print("child");
			
		}
		 clock = timeBetweenMsg;
		RightArrowAnim =  (GameObject)Resources.Load("Prefabs/Instructions/RightArrowAnim");
		Instantiate(RightArrowAnim);
		Invoke ("HighCanvas", 2.5f);
	
	}
	
	// Update is called once per frame
	void Update () {
		clock -= Time.deltaTime;
		speed = 4;
		float currentPitch = Controller.x;
//		if (currentPitch == 0) {
//			ThatsNotHighEnough = GameObject.Find ("ThatsNotHighEnough(Clone)");
//			Destroy (ThatsNotHighEnough);
//			Great = GameObject.Find ("Great(Clone)");
//			Destroy (Great);
//			ThatsNotLowEnough = GameObject.Find ("ThatsNotLowEnough(Clone)");
//			Destroy (ThatsNotLowEnough);
//		}
		print (currentPitch);
		if(donewithCurrentPractice==false){
			if (teachRight) {

				if (currentPitch > 0) {
					if ((currentPitch > (1.1 * middlePitch))) {
						transform.position += Vector3.right * speed * Time.deltaTime;
						ThatsNotHighEnough = GameObject.Find ("ThatsNotHighEnough(Clone)");
						Destroy (ThatsNotHighEnough);

						Great = GameObject.Find ("Great(Clone)");
						if (Great == null) {

							Great = (GameObject)Resources.Load ("Prefabs/Instructions/Great");
							Instantiate (Great);
						}
						speed = 4;
					} else {

						if (firstTimeLow) {
							Great = GameObject.Find ("Great(Clone)");
							Destroy (Great);
							ThatsNotLowEnough = GameObject.Find ("ThatsNotLowEnough(Clone)");
							Destroy (ThatsNotLowEnough);

							ThatsNotHighEnough = GameObject.Find ("ThatsNotHighEnough(Clone)");
							if (ThatsNotHighEnough == null) {
								ThatsNotHighEnough = (GameObject)Resources.Load ("Prefabs/Instructions/ThatsNotHighEnough");
								Instantiate (ThatsNotHighEnough);
								firstTimeLow = false;
							}
						} else if (clock <= 0) {
							Great = GameObject.Find ("Great(Clone)");
							Destroy (Great);
							ThatsNotLowEnough = GameObject.Find ("ThatsNotLowEnough(Clone)");
							Destroy (ThatsNotLowEnough);

							ThatsNotHighEnough = GameObject.Find ("ThatsNotHighEnough(Clone)");

							if (ThatsNotHighEnough == null) {
								ThatsNotHighEnough = (GameObject)Resources.Load ("Prefabs/Instructions/ThatsNotHighEnough");
								Instantiate (ThatsNotHighEnough);
								clock = timeBetweenMsg;
							}

						}
					}
				}

			}
			if (teachRight == false) {

				if (currentPitch > 0) {
					RightArrowAnim = GameObject.Find ("RightArrowAnim(Clone)");
					Destroy (RightArrowAnim);
					ThatsNotHighEnough = GameObject.Find ("ThatsNotHighEnough(Clone)");
					Destroy (ThatsNotHighEnough);
					if (flag) {
						Great = GameObject.Find ("Great(Clone)");
						Destroy (Great);
						flag = false;
					}

					LeftArrowAnim = GameObject.Find ("LeftArrowAnim(Clone)");
					if (LeftArrowAnim == null) {
						LeftArrowAnim = (GameObject)Resources.Load ("Prefabs/Instructions/LeftArrowAnim");
						Instantiate (LeftArrowAnim);

					}

				//	if(countingDownRight==false){
					if ((currentPitch < (0.9 * middlePitch))) {
						transform.position += Vector3.left * speed * Time.deltaTime;

						MakeALowVoice = GameObject.Find ("MakeALowVoice(Clone)");
						Destroy (MakeALowVoice);
						ThatsNotHighEnough = GameObject.Find ("ThatsNotHighEnough(Clone)");
						Destroy (ThatsNotHighEnough);
						ThatsNotLowEnough = GameObject.Find ("ThatsNotLowEnough(Clone)");
						Destroy (ThatsNotLowEnough);

						Great = GameObject.Find ("Great(Clone)");

						if (Great == null) {
							Great = (GameObject)Resources.Load ("Prefabs/Instructions/Great");
							Instantiate (Great);
						}
						speed =4;
					} else {
						if (firstTimeHigh) {
							MakeALowVoice = GameObject.Find ("MakeALowVoice(Clone)");
							Destroy (MakeALowVoice);
							ThatsNotHighEnough = GameObject.Find ("ThatsNotHighEnough(Clone)");
							Destroy (ThatsNotHighEnough);
							Great = GameObject.Find ("Great(Clone)");
							Destroy (Great);

							ThatsNotHighEnough = GameObject.Find ("ThatsNotLowEnough(Clone)");
							if (ThatsNotLowEnough == null) {
								ThatsNotLowEnough = (GameObject)Resources.Load ("Prefabs/Instructions/ThatsNotLowEnough");
								Instantiate (ThatsNotLowEnough);
								firstTimeHigh = false;
							}
						} else if (clock <= 0) {
							MakeALowVoice = GameObject.Find ("MakeALowVoice(Clone)");
							Destroy (MakeALowVoice);
							ThatsNotHighEnough = GameObject.Find ("ThatsNotHighEnough(Clone)");
							Destroy (ThatsNotHighEnough);
							Great = GameObject.Find ("Great(Clone)");
							Destroy (Great);


							ThatsNotLowEnough = GameObject.Find ("ThatsNotLowEnough(Clone)");
							if (ThatsNotLowEnough == null) {
								ThatsNotLowEnough = (GameObject)Resources.Load ("Prefabs/Instructions/ThatsNotLowEnough");
								Instantiate (ThatsNotLowEnough);
								clock = timeBetweenMsg;
							}
							
						}
					}
				//}
				}
				
			}
	}
		if (transform.position.x >= 7.96f) {
			if (MadeRightSound==false) {

				SucceessSound = (GameObject)Resources.Load ("Prefabs/SoundPrefabs/SucceessSound");
				Instantiate (SucceessSound);

				MadeRightSound=true;
			}
			teachRight=false;
			Invoke ("LowCanvas", 2.5f);
			Invoke ("DeleteGreat", 1.5f);


			countingDownRight=true;
			CountDownRight();

		}
		if (transform.position.x <= -7.96f) {
			if (MadeLeftSound==false) {
				SucceessSound = (GameObject)Resources.Load ("Prefabs/SoundPrefabs/SucceessSound");
				Instantiate (SucceessSound);

				MadeLeftSound=true;
				GameObject HowToPlayCanvas = (GameObject)Resources.Load ("Prefabs/Instructions/HowToPlayCanvas");
				Instantiate (HowToPlayCanvas);
				donewithCurrentPractice=true;
			}

			//screen with buttons- PRACTICE\ IM READY TO PLAY
			
		}

//		if (currentPitch > 0 && (currentPitch > (1.1 * middlePitch) || currentPitch < (0.9 * middlePitch))) {
//			speed = -1 * speed * Mathf.Sign ((currentPitch - middlePitch));
//			print (speed);
//		} else {
//			speed=0;
//		}
//		transform.position += Vector3.left * speed * Time.deltaTime;
//	


	
				
		

	
}
	void HighCanvas(){

		ICantSingSoHighCanvas = (GameObject)Resources.Load ("Prefabs/Instructions/ICantSingSoHighCanvas");
		Instantiate (ICantSingSoHighCanvas);
	}
	void LowCanvas(){
		ICantSingSoHighCanvas = GameObject.Find ("ICantSingSoHighCanvas(Clone)");
		Destroy (ICantSingSoHighCanvas);
		ICantSingSoLowCanvas = GameObject.Find ("ICantSingSoLowCanvas(Clone)");
		if (ICantSingSoLowCanvas == null) {
			ICantSingSoLowCanvas = (GameObject)Resources.Load ("Prefabs/Instructions/ICantSingSoLowCanvas");
			Instantiate (ICantSingSoLowCanvas);
		}
	}
	void CountDownRight(){
		if (!doneItOnes) {
			StopWatch -= Time.deltaTime;
			if (StopWatch <= 0) {
				countingDownRight = false;
				StopWatch = 3;
			}
			doneItOnes=true;
		}
	}
	void DeleteGreat(){

		Great = GameObject.Find ("Great(Clone)");
		if (Great !=null) {
			Destroy(Great);
		}
		}

}
