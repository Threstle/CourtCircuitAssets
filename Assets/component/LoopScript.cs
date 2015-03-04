using UnityEngine;
using System.Collections;

public class LoopScript : MonoBehaviour {

	public bool
		loopX,
		loopY ;

	[Header("Limits")]

	public float top ;
	public float right ;
	public float bottom ;
	public float left ;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 position = transform.position ;

		if (loopX) {
			if (transform.position.x > right) position.x = left - transform.localScale.x ;
			else if (transform.position.x + transform.localScale.x < left) position.x = right ;
		}

		if (loopY) {
			if (transform.position.y + transform.localScale.y < bottom) position.y = top - transform.localScale.y ;
			else if (transform.position.y > top) position.y = bottom ;
		}

		transform.position = position ;
	}
}
