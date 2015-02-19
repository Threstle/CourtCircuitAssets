using UnityEngine;
using System.Collections;

public class AxeTrapModuleScript : MonoBehaviour {

	public GameObject piston;
	public GameObject axe;
	public GameObject pivot;
	public int numberOfAxe;
	public int axeSpeed;
	public Vector2 scale;
	// Use this for initialization
	void Start () {

		transformInAxeTrap ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void transformInAxeTrap(){

		Vector3 posPiston = new Vector3 (0, 0,-1f);
		GameObject pistonInstance = Instantiate (piston,posPiston,pivot.transform.rotation) as GameObject;
		pistonInstance.transform.parent = transform;
		posPiston = new Vector3 (0-pivot.renderer.bounds.size.x/4,piston.renderer.bounds.size.y/2,-1);
		pistonInstance.transform.localPosition = posPiston;


		float decalageRate = 180;
		float oldI = 0;
		float rate =  360 / numberOfAxe;
		for(int i = 0; i < numberOfAxe;i++){

			Vector3 posAxe = new Vector3 (0, 0,-1f);
			GameObject axeInstance = Instantiate (axe,posAxe,transform.rotation) as GameObject;
			axeInstance.transform.parent = transform;
			posAxe = new Vector3 (0+pivot.renderer.bounds.size.x/2, 0,-1);
			axeInstance.transform.localPosition = posAxe;
			axeInstance.GetComponent<PivotScript>().decalage = rate*i;
		

		}

	}
}
