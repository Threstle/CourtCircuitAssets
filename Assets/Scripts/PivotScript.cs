using UnityEngine;
using System.Collections;

public class PivotScript : ObjectScript {

	ButtonOneScript buttonOne;

	public bool isInverted;
	public bool isAuto;
	public bool isInfinite;
	public bool invertWhenTouch;
	public int maxMot = 360;
	public int minMot = -360;
	public float decalage;
	public bool rotIsLeft;
	public float currentRot;
	public float motion;
	public float oldMotionRate;
	public float motionRate = 1;
	public float diff;
	public float oldMotion;
	public string motionMode = "r";
	private bool oldRotIsLeft;

	public Vector3 originPosition;
	// Use this for initialization
	void Start () {
		oldMotionRate = motionRate;
		oldRotIsLeft = rotIsLeft;
		buttonOne = Camera.main.GetComponent<ButtonOneScript>();
		originPosition = transform.position;
		if(isAuto)InvokeRepeating ("activateAuto", 0, 0.01f);
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();

		detectTouch ();


	}

	public void detectTouch(){
		if(invertWhenTouch){
			if (transform.GetComponent<DragAndDropScript> ().touchHasObject) {
				rotIsLeft = !oldRotIsLeft;
				//motionRate = oldMotionRate/4;
			}
			else{
				rotIsLeft = oldRotIsLeft;
				//motionRate = oldMotionRate;
			}
		}

	}

	public void activateAuto(){
		activate();
	}


	public override void activate(){

		if (isInfinite) {
			if(rotIsLeft){
				currentRot++;
			}
			else{
				currentRot--;
			}
		} 
		else {
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

		setPosition ();
	}

	public void setPosition(){


			motion = currentRot * motionRate;
			diff = oldMotion - motion;
			oldMotion = motion;
//
			if (isInverted)
					motion = -motion;
//			if (motion > maxMot)
//					motion = maxMot;
//			if (motion < minMot)
//					motion = minMot;
//			
			switch(motionMode){
			case("r"):transform.rotation = Quaternion.Euler (transform.rotation.x, transform.rotation.y, motion+decalage);break;
			case("x"):transform.position = new Vector3(originPosition.x+motion,transform.position.y,transform.position.z+decalage);break;
			case("y"):transform.position = new Vector3(transform.position.x,originPosition.y+motion,transform.position.z+decalage);break;
			}

						

		


	}
}
