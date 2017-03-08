using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

	public static int galScore; 
	public static int guyScore; 
	public static ScoreManager scoreCard; 
	public KeyCode restart;
	public int pointsToWin; 
	public bool canReset;

	// Use this for initialization
	void Start () {

		if (scoreCard == null){ 
			scoreCard = this;  
			DontDestroyOnLoad (this);
		}
		else
		{
			Destroy (gameObject);
		}
	}
		
	
	// Update is called once per frame
	void Update () {

		if (galScore >= pointsToWin) 
		{
			SceneManager.LoadScene ("Player Gal Wins");
			canReset = true;
			galScore = 0;
			guyScore = 0;
			StageBuilder.timer = 0;
		}

		if (guyScore >= pointsToWin) 
		{
			SceneManager.LoadScene ("Player Guy Wins");
			canReset = true;
			galScore = 0;
			guyScore = 0;
			StageBuilder.timer = 0;
		}

		if (canReset == true) 
		{
			if (Input.GetKeyDown (restart)) 
			{
				Debug.Log ("Hit reset.");
				SceneManager.LoadScene ("Week 5 Game");
			}
		}
	}

	public void scorePoints (int sentValue)
	{
		if (sentValue == 1) 
		{
			galScore++;
		}

		if (sentValue == 2) 
		{
			guyScore++;
		}
	}
}
