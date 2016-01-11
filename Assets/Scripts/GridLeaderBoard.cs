using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GridLeaderBoard : MonoBehaviour {

	public GameObject facebookLeaderBoard;

	void Start () {
		FB.Init (Update);


	}
	
	// Update is called once per frame
	void Update () {
		if (FB.IsLoggedIn) {
			facebookLeaderBoard.SetActive(false);
			GetComponent<UIPanel> ().alpha = 1;
			Leaderboards leaderboard = GameObject.Find ("Leaderboard").GetComponent<Leaderboards> ();
			leaderboard.GetLeaderboard ();
			
		} else  {
			
			GetComponent<UIPanel>().alpha=0f;
		}
	}
	


}
