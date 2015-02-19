using UnityEngine;
using System.Collections;

public class GameStateScript : MonoBehaviour {

	public bool isEditing;

	void Awake(){
		Application.targetFrameRate = 60;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (GUI.Button (new Rect (10, 10, 300, 300),(1.0f / Time.deltaTime).ToString() ))
						isEditing = !isEditing;
		

	}

}
