using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameSparks.Api.Requests;
using Facebook.MiniJSON;
using Facebook;

public class ScriptForTestToDelete : MonoBehaviour {

	// Use this for initialization
	void Start () {

			//If facebook is not Initialized
			
			if (!FB.IsInitialized)
			{
				//Call FB.Init and once that's complete we'll call 
				//Facebook Login
				FB.Init(FacebookLogin);
			}
			//Otherwise if we already initialized call Facebook Login
			else
			{
				FacebookLogin();
			}
		}
		
		
		public void FacebookLogin()
		{
			//If we aren't logged in
			if (!FB.IsLoggedIn ) {
				//Call FB.Login, tell it to call GameSparksLogin
				//when done
				FB.Login ("", GameSparksLogin);
				
			}
			
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		//GameSparksLogin takes FBResult from FB.Login but we don't use it 
		//for anything
		public void GameSparksLogin(FBResult result) 
		{
			//It never hurts to double check it you are logged into Facebook                
			//before trying to log into GameSparks with Facebook
//			if (FB.IsLoggedIn) {

				//This is the standard FacebookConnectRequest. This will                        
				//log into GameSparks with your Facebook Profile.
				
//				new FacebookConnectRequest ().SetAccessToken (FB.AccessToken).Send ((response) =>
//				                                                                    {
//					if (response.HasErrors) {
//						Debug.Log ("Something failed with connecting with Facebook");
//					} else {	
//						
//						//to the user that they are logged in...
//					}
//				});
			empty();

		}

	void FBFriendsCallback(FBResult result){
		print ("result " + result.Text);




		
		if (result.Error != null) {
			Debug.LogError("Error getting FB friends: " + result.Error);
		}
		else {
			
			Dictionary<string, object> responseObject = Facebook.MiniJSON.Json.Deserialize(result.Text) as Dictionary<string, object>;            

			StartCoroutine(GetFriendsFacebookUserInfo(responseObject["data"] as List<object>));
		}
	}
	
	IEnumerator GetFriendsFacebookUserInfo(List<object> responseDataObjects) {
		int numFriends = responseDataObjects.Count;
		print ("numFriends" + numFriends);

		foreach (object friendDataObject in responseDataObjects) {
			Dictionary<string, object> friendDataObjectDict = friendDataObject as Dictionary<string, object>;
			print ("count " + friendDataObjectDict.Count);
			yield return null;
			
		}
		
	}



	void empty(){
		FB.API("/1046177392058988/friends/10206489906059222", Facebook.HttpMethod.GET, FBFriendsCallback);

	}
	void Update () {
	
	}
}
