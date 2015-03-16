using UnityEngine;
using System.Collections;

public class doorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		//if(collider.gameObject.tag == "Player")Application.LoadLevel("sceneBat");
		GameObject.Find ("SpacebrewObject").GetComponent<SpacebrewEvents> ().releaseBille ();
		Destroy(GameObject.FindGameObjectWithTag("Player"));
	}
}
