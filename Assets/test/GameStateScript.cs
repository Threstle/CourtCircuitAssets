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
		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.autorotateToPortrait = false;
		Screen.autorotateToLandscapeRight = false;
		//Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	// Use this for initialization
	void Start () {
		zoomCamera = transform.GetComponent<Camera>().orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		followBille ();


	}	

	void OnGUI() {

	}

	public void followBille(){
		if (!isEditing) {
			GameObject billePlayer = GameObject.FindGameObjectWithTag("Player");
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(billePlayer.transform.position);
			Vector3 delta = billePlayer.transform.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
			float veloc =  (Mathf.Abs(billePlayer.GetComponent<Rigidbody2D>().velocity.x)+Mathf.Abs(billePlayer.GetComponent<Rigidbody2D>().velocity.y))/2;
			veloc /=5;
			if(veloc > 1)veloc = 1;
			if(veloc < 0.4)veloc = 0.4f;
			//transform.GetComponent<Camera>().orthographicSize =  Mathf.SmoothDamp(transform.GetComponent<Camera>().orthographicSize, veloc*zoomCamera, ref velocityZoom, dampTime);
			Debug.Log(veloc);
		}
	}

}
