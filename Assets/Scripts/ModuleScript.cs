using UnityEngine;
using System.Collections;

public class ModuleScript : MonoBehaviour {


	
	public bool hasSpawned;
	public bool isEditing;
	Transform[] allChildren;
	
	// Use this for initialization
	public virtual void Start () {
		transformTrap();
		allChildren = GetComponentsInChildren<Transform>();
	}
	
	// Update is called once per frame
	public virtual void Update () {
		isEditing = Camera.main.GetComponent<GameStateScript> ().isEditing;
		
		foreach (Transform child in allChildren) {
			if(child.tag != "EditorVisible"){
				child.gameObject.SetActive(!isEditing);
			}
			
		}
	}
	
	public virtual void transformTrap(){
		
	}

}
