using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.Net;
using UnityEngine.UI;
using System;


public class GetSpreadSheetInfo : MonoBehaviour {

	public string city;
	public string state;
	public static bool hasStarted = false;
	WebClient client; 
	GameObject cityText;
	GameObject regionText;
	GameObject windText; 
	GameObject humidText;
	public static string cityName;
	public static string regionName;
	public static string windSpeed;
	public static string humidity;
	public int windNum;
	public int humidNum;
	public Sprite ny;
	public Sprite frisco;
	public Sprite boston;
	Text tCity;
	Text tRegion;
	Text tWind;
	Text tHumidity;
	public static GetSpreadSheetInfo thisInfo; 
	SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		client = new WebClient ();
		cityText = GameObject.Find ("Name");
		regionText = GameObject.Find ("ST");
		windText = GameObject.Find ("Speed");
		humidText = GameObject.Find ("Humid");
		tCity = cityText.GetComponent<Text> ();
		tRegion = regionText.GetComponent<Text> ();
		tWind = windText.GetComponent<Text> ();
		tHumidity = humidText.GetComponent<Text> ();
		sr = GetComponent<SpriteRenderer> ();

		if (thisInfo == null){  
			thisInfo = this;   
			DontDestroyOnLoad (this);
		}
		else
		{
			Destroy (gameObject);
		}

		if (hasStarted == false) 
		{
			string cityInfo = client.DownloadString ("https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22" + city + "%2C%20" + state + "%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");
			JSONNode info = JSON.Parse (cityInfo);


			cityName = info ["query"] ["results"] ["channel"] ["location"] ["city"];
			regionName = info ["query"] ["results"] ["channel"] ["location"] ["region"];
			windSpeed = info ["query"] ["results"] ["channel"] ["wind"] ["speed"];
			humidity = info ["query"] ["results"] ["channel"] ["atmosphere"] ["humidity"];

			hasStarted = true;
		}

	}
	
	// Update is called once per frame
	void Update () {

		tCity.text = cityName;
		tRegion.text = regionName;
		tWind.text = windSpeed;
		tHumidity.text = humidity;

		windNum = Convert.ToInt32 (windSpeed);
		humidNum = Convert.ToInt32 (humidity);
	}


	public void cityShift (string newCity, string newRegion)
	{
		string newCityInfo = client.DownloadString ("https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22" + newCity + "%2C%20" + newRegion + "%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");
		JSONNode newInfo = JSON.Parse (newCityInfo);


		cityName = newInfo["query"]["results"]["channel"]["location"]["city"];
		regionName = newInfo ["query"] ["results"] ["channel"] ["location"] ["region"];
		windSpeed = newInfo ["query"] ["results"] ["channel"] ["wind"] ["speed"];
		humidity = newInfo ["query"] ["results"] ["channel"] ["atmosphere"] ["humidity"];

		if (newCity == "new york") 
		{
			sr.sprite = ny;
		}

		if (newCity == "boston") 
		{
			sr.sprite = boston;
		}

		if (newCity == "san francisco") 
		{
			sr.sprite = frisco;
		}
	}
		

}
