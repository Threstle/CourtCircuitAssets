using UnityEngine;
using System.Collections;


[RequireComponent (typeof (Collider2D))]

public class DeathObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnCollisionEnter2D(Collision2D collision){
		if (collision.collider.transform.tag == "Player") {
			collision.collider.transform.GetComponent<BilleScript>().destroy();

		}
	}
}
