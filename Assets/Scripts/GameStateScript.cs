using UnityEngine;
using System.Collections;

public class GameStateScript : MonoBehaviour {

	public bool isEditing;
	public float dampTime = 0.75f;
	public float dampTimeZoom = 0.75f;
	private Vector3 velocity = Vector3.zero;
	private float velocityZoom = 0.75f;
	public float zoomCamera;

	void Awake(){
		Application.targetFrameRate = 60;
	}

	// Use this for initialization
	void Start () {
		zoomCamera = transform.camera.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		followBille ();


	}	

	void OnGUI() {
		if (GUI.Button (new Rect (10, 10, 300, 300),(1.0f / Time.deltaTime).ToString() ))
						isEditing = !isEditing;
		

	}

	public void followBille(){
		if (!isEditing) {
			GameObject billePlayer = GameObject.FindGameObjectWithTag("Player");
			Vector3 point = camera.WorldToViewportPoint(billePlayer.transform.position);
			Vector3 delta = billePlayer.transform.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
			float veloc =  (Mathf.Abs(billePlayer.rigidbody2D.velocity.x)+Mathf.Abs(billePlayer.rigidbody2D.velocity.y))/2;
			veloc /=5;
			if(veloc > 1)veloc = 1;
			if(veloc < 0.4)veloc = 0.4f;
			transform.camera.orthographicSize =  Mathf.SmoothDamp(transform.camera.orthographicSize, veloc*zoomCamera, ref velocityZoom, dampTime);
			Debug.Log(veloc);
		}
	}

}
