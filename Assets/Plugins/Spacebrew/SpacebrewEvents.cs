using UnityEngine;
using System.Collections;

public class SpacebrewEvents : MonoBehaviour {

	SpacebrewClient sbClient;
	public bool ledArduino;
	public bool ballArduino;
	// Use this for initialization
	void Start () {
		ledArduino = false;
		GameObject go = GameObject.Find ("SpacebrewObject"); // the name of your client object
		sbClient = go.GetComponent <SpacebrewClient> ();

		// register an event with the client and a callback function here.
		// COMMON GOTCHA: THIS MUST MATCH THE NAME VALUE YOU TYPED IN THE EDITOR!!
		sbClient.addEventListener (this.gameObject, "unityBall");
	}

	// Update is called once per frame
	void Update () {
	

		string ledString = ledArduino.ToString().ToLower();
		print ("Sending Spacebrew Message : " + ledString);
		sbClient.sendMessage("unityLed", "boolean", ledString);
	}

	public void OnSpacebrewEvent(SpacebrewClient.SpacebrewMessage _msg) {
		print ("Received Spacebrew Message");
		print (_msg.value);
		ballArduino = (_msg.value == "true");

	}

	public void releaseBille(){
		Debug.Log("RELEASE");
		ledArduino = true;
	}


}
