using UnityEngine;
using System.Collections;
using System.IO;
using SimpleJSON;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {



		var N = JSONNode.Parse("{ key1 : \"value1\", key2 : \"value2\", key3 : [1, 2, 3], key4 : { a : 123 }  }");

		Debug.Log (N["key4"]["a"]) ;


		var I = new JSONClass();
		I["patate"].AsInt = 5;
		I["author"]["name"] = "Bunny83";
		I["author"]["phone"] = "0123456789";
		I["data"][-1] = "First item\twith tab";
		I["data"][-1] = "Second item";
		I["data"][-1]["value"] = "class item";
		I["data"].Add("Forth item");
		I["data"][1] = I["data"][1] + " 'addition to the second item'";
		I.Add("version", "1.0");

		Debug.Log("");
		Debug.Log("Second example:");
		Debug.Log(I.ToString());
		Debug.Log("");
		
		Debug.Log("I[\"data\"][0]            : " + I["data"][0]);
		Debug.Log("I[\"data\"][0].ToString() : " + I["data"][0].ToString());
		Debug.Log("I[\"data\"][0].Value      : " + I["data"][0].Value);
		Debug.Log(I.ToString());
		
		
		
		
		
		return;
		Debug.Log ("Writing file...");
		// Create an instance of StreamWriter to write text to a file.
		// The using statement also closes the StreamWriter.
		using (StreamWriter sw = new StreamWriter("TestFile.txt"))
		{
			// Add some text to the file.
			sw.Write("This is the ");
			sw.WriteLine("header for the file.");
			sw.WriteLine("-------------------");
		}
		Debug.Log ("Writing done.");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
