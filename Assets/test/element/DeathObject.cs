using UnityEngine;
using System.Collections;


[RequireComponent (typeof (Collider2D))]

public class DeathObject : MonoBehaviour {

	public bool hasSpawned;
	public bool isEditing;
	Transform[] allChildren;

	// Use this for initialization
	public virtual void Start () {

	}
	
	// Update is called once per frame
	public virtual void Update () {

	}

	public void OnCollisionEnter2D(Collision2D collision){
		if (collision.collider.transform.tag == "Player") {
			collision.collider.transform.GetComponent<BilleScript>().destroy();

		}
	}
}
