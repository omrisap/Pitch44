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

			void OnApplicationPause(bool pauseStatus) {


					if (pauseStatus) {
						if (Application.loadedLevelName == "GAME") {
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
