using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class StageBuilder : MonoBehaviour {

	public GameObject guyPrefab; 
	public GameObject galPrefab; 
	public GameObject blockPrefab;
	public GameObject coinPrefab;
	public string [] fileNames;
	public static int stageNum = 0; 
	public float xOffSet;
	public float yOffSet;
	public KeyCode test; 
	public static float timer;
	public static float timerLimit; 
	public float limitSet;


	// Use this for initialization
	void Start () {
		string fileName = fileNames [stageNum];
		string filePath = Application.dataPath + "/Levels/" + fileName; 

		StreamReader sr = new StreamReader (filePath);

		int yPos = 0;

		GameObject stageHolder = new GameObject ("Stage Holder");

		timerLimit = limitSet;


		while(!sr.EndOfStream)
		{
			string line = sr.ReadLine(); 

			for(int xPos = 0; xPos < line.Length; xPos++) 
			{

				if(line[xPos] == 'X')
				{  
					GameObject block = Instantiate (blockPrefab);
					block.transform.parent = stageHolder.transform;

					block.transform.position = new Vector3(
						xPos + xOffSet, 
						yPos + yOffSet);
				}

				if (line [xPos] == 'B') 
				{ 
					GameObject playerGuy = Instantiate (guyPrefab); 
					playerGuy.transform.parent = stageHolder.transform;

					playerGuy.transform.position = new Vector3(
						xPos + xOffSet, 
						yPos + yOffSet);
				}

				if (line [xPos] == 'G') 
				{
					GameObject playerGal = Instantiate (galPrefab); 
					playerGal.transform.parent = stageHolder.transform;

					playerGal.transform.position = new Vector3(
						xPos + xOffSet, 
						yPos + yOffSet);
				
				}

				if (line [xPos] == 'C') 
				{ 
					GameObject coin = Instantiate (coinPrefab); 
					coin.transform.parent = stageHolder.transform;

					coin.transform.position = new Vector3(
						xPos + xOffSet, 
						yPos + yOffSet);

				}
			}
			yPos--; 
		}

		sr.Close();
	}
		
	
	// Update is called once per frame
	void Update () {

		timer++;

		if (timer >= timerLimit) 
		{
			timer = 0;
			stageNum++; 
			SceneManager.LoadScene ("Week 5 Game");
		}

		if (stageNum > 9) 
		{
			stageNum = 0;
		}
	}
}
