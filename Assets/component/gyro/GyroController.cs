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

	protected void Start () 
	{
		AttachGyro();
	}

	protected void Update() 
	{
		if (!gyroEnabled)
			return;
		//transform.rotation = Quaternion.Slerp(transform.rotation,
		//	cameraBase * ( ConvertRotation(referanceRotation * Input.gyro.attitude) * GetRotFix()), lowPassFilterFactor);
		UpdateCalibration(true);
	}

	protected void OnGUI()
	{
		if (!debug)
			return;

		GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude);


	}

	private void AttachGyro()
	{
		gyroEnabled = true;
		ResetBaseOrientation();
		UpdateCalibration(true);
		RecalculateReferenceRotation();
	}

	private void DetachGyro()
	{
		gyroEnabled = false;
	}

	private void UpdateCalibration(bool onlyHorizontal)
	{
		if (onlyHorizontal)
		{
			var fw = (Input.gyro.attitude) * (-Vector3.forward);
			fw.z = 0;
			if (fw == Vector3.zero)
			{
				calibration = Quaternion.identity;
			}
			else
			{
				calibration = (Quaternion.FromToRotation(baseOrientationRotationFix * Vector3.up, fw));
			}
		}
		else
		{
			calibration = Input.gyro.attitude;
		}
	}
	private static Quaternion ConvertRotation(Quaternion q)
	{
		return new Quaternion(q.x, q.y, -q.z, -q.w);	
	}

	private Quaternion GetRotFix()
	{
		return Quaternion.identity;
	}

	private void ResetBaseOrientation()
	{
		baseOrientationRotationFix = GetRotFix();
		baseOrientation = baseOrientationRotationFix * baseIdentity;
	}

	private void RecalculateReferenceRotation()
	{
		referanceRotation = Quaternion.Inverse(baseOrientation)*Quaternion.Inverse(calibration);
	}

}
