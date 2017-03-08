using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISaver : MonoBehaviour {

	public static UISaver gameUI;

	// Use this for initialization
	void Start () {

		if (gameUI == null){
			gameUI = this; 
			DontDestroyOnLoad (this);
		}
		else
		{
			Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {


	}
}

