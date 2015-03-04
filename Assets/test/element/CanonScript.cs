using UnityEngine;
using System.Collections;

public class CanonScript : ObjectScript {

	public GameObject bullet;
	public float force;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("shoot", 0.5f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space))
						shoot ();
	}

	public override void activate(){
		shoot ();
	}

	public void shoot(){
		GameObject bulletInstance = Instantiate (bullet, transform.position, transform.rotation) as GameObject;
		bulletInstance.GetComponent<Rigidbody2D>().AddForce (transform.right * force);
	
	}
}
