﻿using UnityEngine;
using System.Collections;

public class CollisionToDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision2D){

		Destroy (collision2D.gameObject);
	}
}
