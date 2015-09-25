using UnityEngine;
using System.Collections;

public class selfDestruct : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("destruct", 8);
	
	}
	
	// Update is called once per frame
	void destruct () {
		Destroy (gameObject);
	}
}
