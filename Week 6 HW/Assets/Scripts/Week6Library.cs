using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;

public class Week6Library : MonoBehaviour 
{


	/// <summary>
	/// Write a string to a file
	/// </summary>
	/// <param name="path">Path to file to write</param> 
	/// <param name="fileName">Name of file to write</param>
	/// <param name="content">String to write to the file.</param> 
	public static void WriteStringtoFile (string path, string fileName, string content)  
	{
		StreamWriter sw = new StreamWriter (path + "/" + fileName); 
		sw.Write (content);
		sw.Close ();
	}

	/// <summary>
	/// Read a file to end.
	/// </summary>
	/// <param name="path">Path to file to read</param> 
	/// <param name="fileName">Name of file to write</param>
	public static string ReadStringToEnd (string path, string fileName) 
	{
		StreamReader sr = new StreamReader(path + "/" + fileName);
		string result = sr.ReadToEnd();
		sr.Close();
		return result;
	}

	/// <summary>
	/// Write a JSON to a file.
	/// </summary>
	/// <param name="path">Path to file to write</param> 
	/// <param name="fileName">Name of JSON file to write</param>
	/// <param name="json">JSON to write to file.</param> 
	public static void WriteJSONtoFile (string path, string fileName, JSONClass json)
	{
		WriteStringtoFile (path, fileName, json.ToString ()); 
	}

	/// <summary>
	/// Read a JSON file.
	/// </summary>
	/// <param name="path">Path to file to write</param> 
	/// <param name="fileName">Name of JSON file to read</param>
	public static JSONNode ReadJSONtoFile (string path, string fileName)
	{
		JSONNode result = JSON.Parse(ReadStringToEnd(path, fileName));
		return result;
	}
}
