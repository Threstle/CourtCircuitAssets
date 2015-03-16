using UnityEngine;
using System.Collections;

public class GameStateScript : MonoBehaviour {

	public bool isFollowing;
	public bool isMenu;
	public float dampTime = 0.75f;
	public float dampTimeZoom = 0.75f;
	private Vector3 velocity = Vector3.zero;
	private float velocityZoom = 0.75f;
	public float zoomCamera;
	GameObject door;
	public GameObject ball;

	void Awake(){

		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.autorotateToPortrait = false;
		Screen.autorotateToLandscapeRight = false;
		//Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	// Use this for initialization
	void Start () {
		ball = GameObject.Find("canonBallMain");
		ball.SetActive (false);

		zoomCamera = transform.GetComponent<Camera>().orthographicSize;


		if (!isMenu) {
			GameObject billePlayer = GameObject.FindGameObjectWithTag ("Player");
			billePlayer.GetComponent<LoopScript> ().enabled = true;
			LoopScript script = billePlayer.GetComponent<LoopScript> ();
			script.loopX = true;
			script.loopY = true;
			float height = 2f * Camera.main.orthographicSize;
			float width = height * Camera.main.aspect;
			
			script.top = Camera.main.transform.position.y + height / 2;
			script.bottom = Camera.main.transform.position.y - height / 2;
			script.left = Camera.main.transform.position.x - width / 2;
			script.right = Camera.main.transform.position.x + width / 2;
		} else {
			door = GameObject.FindGameObjectWithTag("Door");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("SpacebrewObject").GetComponent<SpacebrewEvents> ().ballArduino)
			spawnBall ();
		Application.targetFrameRate = 60;
	    if(isMenu)followBille ();
		checkTouch ();
	}	

	public void spawnBall(){
//		GameObject ballInstance = Instantiate (ball, transform.position, transform.rotation) as GameObject;
//		ballInstance.transform.parent = GameObject.Find("Scene");
//		ballInstance.transform.position = new Vector3 (-4.52f, -0.48f, -5f);
		ball.SetActive (true);
	}

	void checkTouch(){
		if (Input.GetMouseButton (0)) {
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			if (hit.collider != null) {
				if(hit.collider.gameObject.GetComponent<ElementScript>() is InteractiveScript){
					hit.collider.gameObject.GetComponent<InteractiveScript>().onMouseDown();

				}
			}
			//		
			//										if (hit.collider.gameObject == gameObject) {
		}
		if (Input.GetMouseButtonUp (0)) {
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			if (hit.collider != null) {
				if(hit.collider.gameObject.GetComponent<ElementScript>() is InteractiveScript){
					hit.collider.gameObject.GetComponent<InteractiveScript>().onMouseUp();
					
				}
			}
			//		
			//										if (hit.collider.gameObject == gameObject) {
		}
	}

	void OnGUI() {
		GUILayout.Label("" + Application.targetFrameRate);
	}

	public void followBille(){
		if (isFollowing) {
			GameObject billePlayer = GameObject.FindGameObjectWithTag ("Player");
			Vector3 point = GetComponent<Camera> ().WorldToViewportPoint (billePlayer.transform.position);
			Vector3 delta = billePlayer.transform.position - GetComponent<Camera> ().ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
			float veloc = (Mathf.Abs (billePlayer.GetComponent<Rigidbody2D> ().velocity.x) + Mathf.Abs (billePlayer.GetComponent<Rigidbody2D> ().velocity.y)) / 2;
			veloc /= 5;
			if (veloc > 1)
				veloc = 1;
			if (veloc < 0.4)
				veloc = 0.4f;
			//transform.GetComponent<Camera>().orthographicSize =  Mathf.SmoothDamp(transform.GetComponent<Camera>().orthographicSize, veloc*zoomCamera, ref velocityZoom, dampTime);
			isFollowing = !door.gameObject.GetComponent<SpriteRenderer>().isVisible;
			

		} else {



			Vector3 point = GetComponent<Camera> ().WorldToViewportPoint (door.transform.position);
			Vector3 delta = door.transform.position - GetComponent<Camera> ().ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime*3);
		}
	}

}
