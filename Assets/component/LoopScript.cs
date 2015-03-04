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
	
	[Header("Margins")]
	public float marginX ;
	public float marginY ;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 position = transform.position ;
		Vector3 size = gameObject.GetComponent<Renderer>().bounds.size;

		if (loopX) {
			if (position.x > right + marginX) position.x = left - size.x - marginX ;
			else if (position.x + size.x < left - marginX) position.x = right + marginX ;
		}

		if (loopY) {
			if (position.y + size.y < bottom - marginY) position.y = top - size.y + marginY ;
			else if (position.y > top + marginY) position.y = bottom - marginY ;
		}

		transform.position = position ;
	}
}
