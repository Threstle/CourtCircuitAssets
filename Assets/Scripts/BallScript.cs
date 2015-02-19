using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	Collider2D colliding;
	Rigidbody body;
	float forceMultiplier = 25;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

/*	public void OnCollisionEnter2D (Collision2D collisionInfo) {
		if (collisionInfo.gameObject.name == "Pinball") {

			ContactPoint2D contactNormal = collisionInfo.contacts[0];
			float rot = Quaternion.FromToRotation(Vector3.up, contactNormal.normal);
			float pos = contactNormal.point;
			float rv = collisionInfo.relativeVelocity.magnitude;
			Vector2 direction = body.transform.position - pos;
			Vector2 reflectBallTo = Vector3.Reflect (pos, direction);
			colliding.gameObject.rigidbody.AddForce (reflectBallTo * forceMultiplier);
		}  
	}*/

}
