//using UnityEngine;
//using System.Collections;
//
//public class DragAndDropScript : MonoBehaviour {
//	public bool isDragged;
//	public bool canBeDragged;
//	private Vector3 origineTransform;
//	private Vector3 origineSize;
//	private Vector2 origineMousePos;
//
//	public bool touchIsDown;
//	public bool touchHasObject;
//
//	// Use this for initialization
//	void Start () {
//		origineTransform = transform.position;
//		origineSize = transform.localScale;
//	}
//	
//	// Update is called once per frame
//	void Update () {
////		canBeDragged = Camera.main.GetComponent<GameStateScript>().isEditing;
////
////
////						//Clicking left mousebutton
////						if (Input.GetMouseButtonDown (0)) {
////
////								RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
////								if (hit.collider != null) {
////		
////										if (hit.collider.gameObject == gameObject) {
////												//Debug.Log ("Target Position: " + hit.collider.gameObject.transform.position);
////												isDragged = true;
////												origineMousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
////												//transform.localScale = Vector3.MoveTowards (transform.localScale, origineSize*1.2f, 10/100);
////												//transform.localScale = transform.localScale * 1.2f;
////												//Vector3.Slerp(transform.localScale,transform.localScale * 1.2f,50);
////												if(canBeDragged)StartCoroutine (liftObject ());
////
////										} else {
////								
////								
////										}
////								} else {
////										//isDragged = false;
////								}
////						}
////
////
////
////
////		
////
////		if (canBeDragged) {
////						if (Input.GetMouseButton (0) && isDragged) {
////
////								Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
////								float xMouse = mousePos.x - origineMousePos.x;
////								float yMouse = mousePos.y - origineMousePos.y;
////								transform.position = new Vector3 (origineTransform.x + xMouse, origineTransform.y + yMouse, -5);
////			
////
////						}
////
////						if (Input.GetMouseButtonUp (0) && isDragged) {
////								transform.position = new Vector3 (transform.position.x, transform.position.y, origineTransform.z);
////								isDragged = false;
////								//transform.localScale = Vector3.Lerp (transform.localScale, origineSize, 10/100);
////								origineMousePos = transform.position;
////								origineTransform = transform.position;
////								StartCoroutine (dropObject ());
////						}
////
////				} else {
////					transform.GetComponent<ObjectScript>().activate();
////
////				}
//		detectTouch ();
//	}
//
//	public void detectTouch(){
//	
//
//		if (Input.GetMouseButtonDown (0)) {
//			touchIsDown = true;
//			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
//			if (hit.collider != null) {
//				if (hit.collider.gameObject == gameObject) {
//					origineMousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//					touchHasObject = true;
//					
//					
//				}
//			}
//		}
//
//		GameStateScript script = Camera.main.GetComponent<GameStateScript> ();
//		if (!script) return;
//		canBeDragged = script.isEditing;
//
//		if(canBeDragged){
//			if (Input.GetMouseButton (0) && touchHasObject) {
//
//					Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//					float xMouse = mousePos.x - origineMousePos.x;
//					float yMouse = mousePos.y - origineMousePos.y;
//					transform.position = new Vector3 (origineTransform.x + xMouse, origineTransform.y + yMouse, -5);
//
//
//			}
//
//			if (Input.GetMouseButtonUp (0) && touchHasObject) {
//					transform.position = new Vector3 (transform.position.x, transform.position.y, origineTransform.z);
//					isDragged = false;
//					//transform.localScale = Vector3.Lerp (transform.localScale, origineSize, 10/100);
//					origineMousePos = transform.position;
//					origineTransform = transform.position;
//					//StartCoroutine (dropObject ());
//			}
//
//
//		}
//		else{
//			if(touchIsDown &&  touchHasObject && transform.GetComponent<ObjectScript>().isClickable){
//				transform.GetComponent<ObjectScript>().activate();
//			}
//
//
//		}
//
//
//		if (Input.GetMouseButtonUp (0)) {
//			touchIsDown = false;
//			touchHasObject = false;
//		}
//
//
//	}
//
//	IEnumerator liftObject() {
//		GameObject objectToScale = transform.gameObject;
//		for (float i = 0; i <=50; i+=5) {
//			objectToScale.transform.localScale = new Vector2(objectToScale.transform.localScale.x+0.01f,objectToScale.transform.localScale.y+0.01f);
//
//			yield return new WaitForSeconds(0.01f);
//		}
//	}
//
//	IEnumerator dropObject() {
//		GameObject objectToScale = transform.gameObject;
//		for (float i = 0; i <= 50; i+=5) {
//			objectToScale.transform.localScale = new Vector2(objectToScale.transform.localScale.x-0.01f,objectToScale.transform.localScale.y-0.01f);
//			
//			yield return new WaitForSeconds(0.01f);
//		}
//	}
//
//
//}
