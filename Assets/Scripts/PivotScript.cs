using UnityEngine;
using System.Collections;

public class PivotScript : ObjectScript {

	ButtonOneScript buttonOne;

	public bool isInverted;
	public int maxMot = 360;
	public int minMot = -360;
	public bool rotIsLeft;
	public float currentRot;
	public float motion;
	public float motionRate = 1;
	public float diff;
	public float oldMotion;
	public string motionMode = "r";

	public Vector3 originPosition;
	// Use this for initialization
	void Start () {
		buttonOne = Camera.main.GetComponent<ButtonOneScript>();
		originPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
		setPosition ();
		if (Input.GetKey (KeyCode.RightArrow))
			activate ();
	}

	public void detectTouch(){

	}

	public override void activate(){
		if (rotIsLeft) {
			if (currentRot < maxMot) {
					currentRot++;
			} else {
					rotIsLeft = false;
			}
		} 
		else {
			if(currentRot > minMot){
				currentRot--;
			}
			else{
				rotIsLeft = true;
			}
		}
	}

	public void setPosition(){


			motion = currentRot * motionRate;
			diff = oldMotion - motion;
			oldMotion = motion;

			if (isInverted)
					motion = -motion;
			if (motion > maxMot)
					motion = maxMot;
			if (motion < minMot)
					motion = minMot;

			switch(motionMode){
			case("r"):transform.rotation = Quaternion.Euler (transform.rotation.x, transform.rotation.y, motion);break;
			case("x"):transform.position = new Vector3(originPosition.x+motion,transform.position.y,transform.position.z);break;
			case("y"):transform.position = new Vector3(transform.position.x,originPosition.y+motion,transform.position.z);break;
			}

						

		


	}
}
