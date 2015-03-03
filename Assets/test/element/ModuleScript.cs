using UnityEngine;
using System.Collections;

public class ModuleScript : MonoBehaviour {


	
	public bool hasSpawned;
	public bool isEditing;
	public bool isInverted;
	public float initialRot;
	Transform[] allChildren;
	
	// Use this for initialization
	public virtual void Start () {
		initialRot = transform.rotation.z*Mathf.Rad2Deg;
		transformTrap();
		allChildren = GetComponentsInChildren<Transform>();

	}
	
	// Update is called once per frame
	public virtual void Update () {
		if (isInverted){
			transform.localScale = new Vector3 (transform.localScale.x, -1,transform.localScale.z);
			transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,initialRot+180);
		}
		else{
			transform.localScale = new Vector3 (transform.localScale.x, 1,transform.localScale.z);
			transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,initialRot);
		}

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
