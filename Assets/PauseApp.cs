		using UnityEngine;
		using System.Collections;
		using UnityEngine.UI;


		public class PauseApp : MonoBehaviour {
			private	GameObject PauseGameScreen;


			public GameObject pitchRecognitionControllerPreFab;
			void Start () {
			if (Application.loadedLevelName == "GAME") {
				PauseGameScreen = GameObject.Find ("PauseGameScreen");
				PauseGameScreen.SetActive (false);
				}
			}

			// Update is called once per frame
			void Update () {

			}
			void ReturnSound(){
				
				AudioListener.volume = 1-AudioListener.volume;
			}

			void OnApplicationPause(bool pauseStatus) {


					if (pauseStatus) {
						if (Application.loadedLevelName == "GAME") {
							if(PlayerPrefsManager.GetVolumeIsOn()==0){
								AudioListener.volume = 1-AudioListener.volume;
								Invoke("ReturnSound",3);
							}
							PauseGameScreen.SetActive (true);
							Destroy (GameObject.Find ("PitchRecognitionController"));
							Time.timeScale=0;

						
					}else {
						Destroy (GameObject.Find ("PitchRecognitionController"));
					}
					} else {
						if (Application.loadedLevelName != "GAME") {
							Instantiate (pitchRecognitionControllerPreFab);
						}
					}
				}

		}
