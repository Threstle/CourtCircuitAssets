using UnityEngine;
using System.Collections;

public class RotarySpringScript : ElementScript, InteractiveScript {

	public float power = 1;
	public float maxAngle = 45;
	public bool isLeft;

	private float initialAngle;
	private float contraction;
	// Use this for initialization
	void Start () {
		initialAngle = transform.localEulerAngles.z;
		contraction = initialAngle;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0,contraction),20f*Time.deltaTime);
	}

	public void onMouseDown(){
		contract();
	}
	public void onMouseMove(){

	}
	public void onMouseUp(){
		release ();
	}

	private void contract(){

		if(Mathf.Abs(contraction) < Mathf.Abs(maxAngle))contraction+= power;
	//	transform.rotation = Quaternion.Euler (transform.rotation.x, transform.rotation.y, contraction);
	}

	private void release(){
	//	Quaternion target = Quaternion.Euler(0,0,initialAngle);

//		transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z*Time.deltaTime*1000);

		contraction = initialAngle;
	}
}
