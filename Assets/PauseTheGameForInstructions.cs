﻿using UnityEngine;
using System.Collections;

public class PauseTheGameForInstructions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Time.timeScale=0;
	}
	void Awake ()
	{
		Time.timeScale=0;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
