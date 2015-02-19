using UnityEngine;
using System.Collections;


[RequireComponent (typeof (CircleCollider2D))]

[RequireComponent (typeof (SpriteRenderer))]

public class ObjectScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {

	}

	public virtual void activate(){
		Debug.Log ("FAIL");
	}
}
