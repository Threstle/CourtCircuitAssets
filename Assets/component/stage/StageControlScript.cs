
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageControlScript : MonoBehaviour
{
	public GameObject stageModel ;
	
	public List<GameObject> stages ;

	public List<Sprite> backgrounds ;

	void Start ()
	{
		Create ();
		Create ();
		Create ();
		Create ();
		Create ();
	}

	void Update ()
	{
		
	}

	////////////////////////////////////////////

	void Create()
	{
		GameObject stage = Instantiate(stageModel) as GameObject;
		StageScript stageScript = stage.GetComponent<StageScript>();

		stageScript.id = stages.Count;
		stage.GetComponent<SpriteRenderer> ().sprite = backgrounds[(int) (Random.Range(0, backgrounds.Count)+0.5)];
		stage.transform.position = new Vector3(stageScript.id * 8, 0, 0);

		stages.Add (stage);
		stage.transform.parent = this.transform;
	}
}
