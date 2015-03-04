// ***********************************************************
// Written by Heyworks Unity Studio http://unity.heyworks.com/
// ***********************************************************
using UnityEngine;

/// <summary>
/// Gyroscope controller that works with any device orientation.
/// </summary>
public class GyroController : MonoBehaviour 
{


	private bool gyroEnabled = true;
	private const float lowPassFilterFactor = 0.2f;

	private readonly Quaternion baseIdentity =  Quaternion.Euler(90, 0, 0);
	private readonly Quaternion landscapeRight =  Quaternion.Euler(0, 0, 90);
	private readonly Quaternion landscapeLeft =  Quaternion.Euler(0, 0, -90);
	private readonly Quaternion upsideDown =  Quaternion.Euler(0, 0, 180);
	
	private Quaternion cameraBase =  Quaternion.identity;
	private Quaternion calibration =  Quaternion.identity;
	private Quaternion baseOrientation =  Quaternion.Euler(90, 0, 0);
	private Quaternion baseOrientationRotationFix =  Quaternion.identity;

	private Quaternion referanceRotation = Quaternion.identity;
	private bool debug = true;
	Vector3 roll;
	float gravityRoll;
	Quaternion rotationGyro;


	protected void Start () 
	{

		Input.gyro.enabled = true;                // enable the gyroscope
		Input.gyro.updateInterval = 0.0167f;
	}

	protected void Update() 
	{
//		Quaternion referenceRotation = Quaternion.identity;
//		Quaternion deviceRotation = DeviceRotation.Get();
//		Quaternion eliminationOfXY = Quaternion.Inverse(
//			Quaternion.FromToRotation(referenceRotation * Vector3.forward, 
//		                          deviceRotation * Vector3.forward)
//			);
//		Quaternion rotationZ = eliminationOfXY;
//		roll = rotationZ.eulerAngles;
//		gravityRoll = roll.z;
//		if (gravityRoll > 180) {
//			gravityRoll -= 180;
//			gravityRoll *= 0.01f;
//		} else {
//			gravityRoll *= -0.01f;
//		}


	}

	protected void OnGUI()
	{
		if (!debug)
			return;

//		GUILayout.Label("Orientation: " + Screen.orientation);
//		GUILayout.Label("Calibration: " + calibration);
//		GUILayout.Label("Camera base: " + cameraBase);
//		GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude);
		GUILayout.Label("transform.rotation: " + Physics2D.gravity.x);
		Physics2D.gravity = new Vector2 (Input.acceleration.x*6,Physics2D.gravity.y);

	}


}
