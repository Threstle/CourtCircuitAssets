using UnityEngine;
using System.Collections;

public class PistonScript : ObjectScript {

	public bool hasBille;
	public float force = 5000;
	GameObject bille;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void activate(){
		StartCoroutine (push ());
	}

	public void OnTriggerEnter2D(Collider2D collider){
		if (collider.transform.tag == "Player") {
						hasBille = true;
						bille = collider.gameObject;
				}
	}

	public void OnTriggerExit2D(Collider2D collider){
		if (collider.transform.tag == "Player") {
						hasBille = false;
						bille = null;
				}
	}

	IEnumerator push(){
		if (hasBille) {
			transform.collider2D.enabled = false;
			bille.rigidbody2D.AddForce (transform.root.transform.right * force);
			yield return new WaitForSeconds(1f);
			hasBille = false;
			bille = null;
			transform.collider2D.enabled = true;
		}
	}
}
