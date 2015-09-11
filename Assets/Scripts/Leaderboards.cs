﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameSparks.Api.Requests;
using Facebook.MiniJSON;
using Facebook;

//the prefab we are going to instantiate 
public class Leaderboards : MonoBehaviour
{
	private bool caledToGetLeaderBoard=false;
	
	public GameObject leaderboardEntryPrefab;
	
	//NGUI grid, this will re-organise the leaderboard whenever 
	//a new entry is added
	public UIGrid leaderboardGrid;
	
	//creates a list of GameObjects. whenever the leaderboard is called it w       //ill clear out the old enteries and pull in the new. This will also keep      //track of the enteries so they can be deleted in the future
	public List<GameObject> entries = new List<GameObject>();
	
	void Start()
	{
		//re-arranges all currently stored game objects that are 
		//children of the leaderboard grid
		leaderboardGrid.Reposition();
	}

	/*
	void OnFriendsDownloaded(FBResult result) {

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
		GameObject.Find("Text4test").GetComponent<Text>().text=numFriends.ToString();
		foreach (object friendDataObject in responseDataObjects) {
			Dictionary<string, object> friendDataObjectDict = friendDataObject as Dictionary<string, object>;
			print ("count " + friendDataObjectDict.Count);
			yield return null;

			}

		}


	public void GetLeaderboardForFriendsOnly(){
		FB.API("/v2.1/me/friends", Facebook.HttpMethod.GET, OnFriendsDownloaded);

		for (int i = 0; i < entries.Count; i++) {
			Destroy (entries [i]);
		}
	//	GameObject.Find ("Grid").GetComponent<GridLeaderBoard> ().RemoveAllEntries ();

		new ListGameFriendsRequest().Send((response1) =>
		  {


			foreach(var friend in response1.Friends){
			print ("  friend.Id  " + friend.Id);
				
				new LeaderboardDataRequest_HighscoreLeaderboard ().SetEntryCount (10).Send ((response) => {
					
					//what we will do with the information given by GameSparks
					
					
					foreach (var entry in response.Data) {
						print ("entry.UserId " + entry.UserId + "  friend.Id  " + friend.Id);
						if (entry.UserId==friend.Id){
							GameObject go = NGUITools.AddChild (leaderboardGrid.gameObject, leaderboardEntryPrefab);
							
							go.GetComponent<LeaderboardEntry> ().rankString = entry.Rank.ToString ();
							go.GetComponent<LeaderboardEntry> ().usernameString = entry.UserName.ToString ();
							go.GetComponent<LeaderboardEntry> ().scoreString = entry.GetNumberValue ("Score").ToString ();
							go.GetComponent<LeaderboardEntry> ().facebookID = entry.ExternalIds.GetString ("FB");
							entries.Add (go);
							

							leaderboardGrid.Reposition ();
						}

					}

				});
			}



		});	



	}

	public void GetAll(){

		caledToGetLeaderBoard = false;
		GetLeaderboard ();

	}
*/
	public void GetLeaderboard()
	{

		if (caledToGetLeaderBoard == false) {
			PostScores ("", PlayerPrefsManager.GetHighestScore ());
			//the leaderboard entries could contain old data. 
			//First destroy all existing Leaderboard objects
			for (int i = 0; i < entries.Count; i++) {
				Destroy (entries [i]);
			}
		
			//because we deleted the objects contained on the list, the list                //now contains nul references and has to be cleared so the new 
			//high score objects can be added
			entries.Clear ();
		
			//pulls in the Leaderboard information from Gamesparks, 
			//identified by the short code added when setting up the 
			//Leaderboard in the Gamesparks portal
			//SetEntryCount() will define how many entries you want to pull in one go
			new LeaderboardDataRequest_HighscoreLeaderboard ().SetEntryCount (10).Send ((response) => {

				//what we will do with the information given by GameSparks
		

					foreach (var entry in response.Data) {
					//only children of the NGUI grid will be added 
					//to the grid. We make new objects with our
					//LeaderboardEntry script and add them as 
					//children to the NGUI Leaderboard Grid
						
							GameObject go = NGUITools.AddChild (leaderboardGrid.gameObject, leaderboardEntryPrefab);
				
							go.GetComponent<LeaderboardEntry> ().rankString = entry.Rank.ToString ();
							go.GetComponent<LeaderboardEntry> ().usernameString = entry.UserName.ToString ();
					//the score string has to be added as a number value 
					//based on the short code used for the attributed 
					//to the leaderboard we are pulling from
							go.GetComponent<LeaderboardEntry> ().scoreString = entry.GetNumberValue ("Score").ToString ();
							go.GetComponent<LeaderboardEntry> ().facebookID = entry.ExternalIds.GetString ("FB");
				
					//adds the gameobject to the list of entries
							entries.Add (go);
				
					//repositions the new object so it isn't stacked                                //over existing objects
					//created by the loop
							leaderboardGrid.Reposition ();

						
				}
					
			});
			caledToGetLeaderBoard = true;

			StartCoroutine(	getFBPicture(FB.UserId));
		}
	}



	public IEnumerator getFBPicture(string facebookID)
	{
		LeaderboardEntry leaderboardEntry=GameObject.Find("LeaderboardEntry").GetComponent<LeaderboardEntry>();
		leaderboardEntry.getFBPicture();
		var www = new WWW("http://graph.facebook.com/" + facebookID + "/picture?type=square");
		
		yield return www;
		
		//make sure the dimensions of the new texture match what we set                 //up in the Leaderboard Entry prefab
		Texture2D tempPic = new Texture2D(25, 25);
		
		www.LoadImageIntoTexture(tempPic);
		leaderboardEntry.profilePic.mainTexture = tempPic;
		
	}


	public void PostScores(string levelName, int scoreToBePassed)
	{
		//The LogEventRequest_postScore() has been created by the custom SDK based on 
		//the events you made on the Gamesparks Portal. 
		//Likewise the Set_score(scoreToBePassed) Attribute has been generated by 
		//the attributes set in the GameSparks portal
		new GameSparks.Api.Requests.LogEventRequest_PostScore().Set_Score(scoreToBePassed).Send((response) =>
		                                                                                        {
			if (response.HasErrors)
			{
				Debug.Log("Failed");
			}
			else
			{
				Debug.Log("Successful");
			}
		});
	}

	}

	



