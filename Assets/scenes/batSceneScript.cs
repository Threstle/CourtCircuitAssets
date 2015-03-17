using UnityEngine;
using System.Collections;

public class batSceneScript : MonoBehaviour {

	public GameObject bat;
	public int nbBats = 7;
	// Use this for initialization
	void Start () {
		for (int i = 0; i <= nbBats; i++) {
			float sizeX = (((transform.GetComponent<SpriteRenderer>().bounds.size.x)/2)/1);
			float sizeY = (((transform.GetComponent<SpriteRenderer>().bounds.size.y)/2)/1);
			GameObject batInstance = Instantiate(bat,new Vector3(transform.position.x+Random.Range(-sizeX,sizeX),
			                                                     transform.position.y+Random.Range(sizeY/5,sizeY/2),
			                                                     -4),
			                                     				 Quaternion.identity) as GameObject;
			batInstance.transform.parent = transform;
			batInstance.GetComponent<Rigidbody2D>().angularDrag = batInstance.GetComponent<Rigidbody2D>().angularDrag * Random.Range(0.6f,1.4f);
			batInstance.GetComponent<Rigidbody2D>().mass = batInstance.GetComponent<Rigidbody2D>().mass * Random.Range(0.6f,1.4f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
