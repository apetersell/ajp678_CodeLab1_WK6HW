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
	public AudioClip ny;
	public AudioClip frisco;
	public AudioClip boston; 
	AudioSource aud;

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

		aud = GetComponent<AudioSource> ();
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

	public void trackChange (int sentNum)
	{
		if (sentNum == 1) 
		{
			aud.clip = ny;
			aud.Play ();
		}

		if (sentNum == 2) 
		{
			aud.clip = boston;
			aud.Play ();
		}

		if (sentNum == 3) 
		{
			aud.clip = frisco;
			aud.Play ();
		}
	}
}
