using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	Text t; 
	public int playerNum;

	// Use this for initialization
	void Start () {

		t = GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {
		float timeLeft = StageBuilder.timerLimit - StageBuilder.timer;  

		if (playerNum == 1) 
		{
			t.text = ScoreManager.galScore.ToString();
		}

		if (playerNum == 2) 
		{
			t.text = ScoreManager.guyScore.ToString();
		}

		if (playerNum == 3) 
		{
			t.text = timeLeft.ToString (); 
		}
		
	}
}
