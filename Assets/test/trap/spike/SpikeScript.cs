using UnityEngine;
using System.Collections;

public class SpikeScript : DeathObject {

	public float
		x,
		y,
		z,
		width,
		height,
		angle ;

	// Use this for initialization
	void Start ()
	{
		transform.localScale = new Vector3(1, 0, 1) ;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float h = (float) (transform.localScale.y + 0.1);
		if (h > height) h = height ;
		transform.localScale = new Vector3(width, h, 1);
		transform.position = new Vector3(x, y - ((height-h)/4), z);
	}
}
