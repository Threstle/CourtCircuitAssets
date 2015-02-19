using UnityEngine;
using System.Collections;

public class BilleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void destroy(){
		StartCoroutine (destroyObject ());
	}

	IEnumerator destroyObject(){
		transform.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 1);
		yield return new WaitForSeconds(0.1f);
		Destroy (gameObject);
	}
}
