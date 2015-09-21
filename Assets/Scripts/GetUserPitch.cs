using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetUserPitch : MonoBehaviour {

	private  Text HigestPitchText,LowestPitchText;
	private float highestPitch=380,lowestpitch=120;
	private  bool checkHigest = false,checkLowest=false;

	private int count;
	private float sum;



	// Use this for initialization


	
	public void CheckHighestPitch(){
	



	
		checkHigest=true;

	
	}
	public void CheckLowestPitch(){





		checkLowest=true;


	}
	
	public void Stop(){

		PlayerPrefsManager.SetHighestPitch(highestPitch);
		PlayerPrefsManager.SetLowhestPitch(lowestpitch);



		checkHigest=false;
		checkLowest=false;
		count=0;
		sum = 0;
	

				
	}
	
	public void BackToDefauldt(){
		PlayerPrefsManager.SetHighestPitch(380);
		PlayerPrefsManager.SetLowhestPitch(120);

		LowestPitchText.text="Your lowest pitch is: " +(int) PlayerPrefsManager.GetLowhestPitch();
		
		HigestPitchText.text = "Your highest pitch is: " +(int)  PlayerPrefsManager.GetHighestPitch();

	}

	void Start () {
	

		HigestPitchText = (Text) GameObject.Find("HigestPitchText").GetComponent<Text>();
		LowestPitchText = (Text) GameObject.Find("LowestPitchText").GetComponent<Text>();

		LowestPitchText.text="Your lowest pitch is: " +(int) PlayerPrefsManager.GetLowhestPitch();
		
		HigestPitchText.text = "Your highest pitch is: " +(int)  PlayerPrefsManager.GetHighestPitch();

		 count=0;
		 sum = 0;

		
	}

	
	// Update is called once per frame
	void Update () {
	

		if (checkHigest) {
			HigestPitchText.text = "Your highest pitch is: " + ((int)highestPitch).ToString ();
		
			if (Controller.x > 0 && Controller.x > 150) {
				count++;
				sum = sum + Controller.x;
				highestPitch = sum / count;

			}

		}	

		if(checkLowest){
			LowestPitchText.text="Your lowest pitch is: " + ((int) lowestpitch ).ToString();
			if(Controller.x>0 && Controller.x<250){
				count++;
				sum=sum+Controller.x;
				lowestpitch=sum/count;
			}


		}
			
			
			
			



	
	
	}
	

}
