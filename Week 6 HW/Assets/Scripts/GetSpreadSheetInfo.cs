using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;
using System.Net;
using UnityEngine.UI;


public class GetSpreadSheetInfo : MonoBehaviour {

	public string city;
	public string state;
	WebClient client; 
	public Text cityText;
	public Text regionText;
	public Text windText; 
	Text tCity;
	Text tRegion;
	Text tWind;

	// Use this for initialization
	void Start () {
		client = new WebClient ();
		tCity = cityText.GetComponent<Text> ();
		tRegion = regionText.GetComponent<Text> ();
		tWind = windText.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		string cityInfo = client.DownloadString ("https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22" + city + "%2C%20" + state + "%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");
		JSONNode info = JSON.Parse (cityInfo);


		string cityName = info["query"]["results"]["channel"]["location"]["city"];
		string regionName = info ["query"] ["results"] ["channel"] ["location"] ["region"];
		string windSpeed = info ["query"] ["results"] ["channel"] ["wind"] ["speed"];
		Debug.Log ("Current Wind Speed: " + windSpeed);

		tCity.text = cityName;
		tRegion.text = regionName;
		tWind.text = windSpeed;
	}


}
