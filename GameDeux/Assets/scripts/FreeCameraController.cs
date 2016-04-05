using UnityEngine;
using System.Collections;

public class FreeCameraController : MonoBehaviour
{
	
	/*
	EXTENDED FLYCAM
		Desi Quintans (CowfaceGames.com), 17 August 2012.
		Based on FlyThrough.js by Slin (http://wiki.unity3d.com/index.php/FlyThrough), 17 May 2011.
 
	LICENSE
		Free as in speech, and free as in beer.
 
	FEATURES
		WASD/Arrows:    Movement
		          Q:    Rotate counterclockwise
		          E:    Rotate clockwise
				  R:	Climb
				  F:	Drop
                      Shift:    Move faster
                    Control:    Move slower
                        End:    Toggle cursor locking to screen (you can also press Ctrl+P to toggle play mode on and off).
	*/
	
	public float cameraSensitivity = 90;
	public float maxClimbSpeed = 4;
	public float maxMoveSpeed = 10;
	/* public float slowMoveFactor = 0.25f;
	public float fastMoveFactor = 3; */
	public float currentVelocityOrthogonal = 0;
	public float currentVelocityVertical = 0;
	
	private float rotationX = 0.0f;
	private float rotationY = 0.0f;
	
	void Start ()
	{
		Screen.lockCursor = true;
	}
	
	void Update ()
	{
		// Rotation
		/* rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
		rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
		rotationY = Mathf.Clamp (rotationY, -90, 90); */
		if(Input.GetKey(KeyCode.Q))
			rotationX += 0.12f * cameraSensitivity * Time.deltaTime;
		else if(Input.GetKey(KeyCode.E))
			rotationX -= 0.12f * cameraSensitivity * Time.deltaTime;
		
		transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
		// transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);
		
		// Acceleration
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift))
		{
			/* transform.position += transform.forward * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
			transform.position += transform.right * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime; */
			
			if(currentVelocityOrthogonal < maxMoveSpeed)
			{
				currentVelocityOrthogonal += transform.forward * 0.12f * Input.GetAxis("Vertical");
				currentVelocityOrthogonal += transform.right * 0.08f * Input.GetAxis("Horizontal");
			}
		}
		// Deceleration
		else if (Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.RightControl))
		{
			/* transform.position += transform.forward * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
			transform.position += transform.right * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime; */
			
			if(currentVelocityOrthogonal > -maxMoveSpeed)
			{
				currentVelocityOrthogonal -= transform.forward * 0.12f * Input.GetAxis("Vertical");
				currentVelocityOrthogonal -= transform.right * 0.08f * Input.GetAxis("Horizontal");
			}
		}
			
		transform.position += currentVelocityOrthogonal * Time.deltaTime;
		
		// Rising
		if (Input.GetKey (KeyCode.R) && currentVelocityVertical < maxClimbSpeed) 
		{
			currentVelocityVertical += transform.up * 0.2f;
		}
		// Descending
		else if (Input.GetKey (KeyCode.F) && currentVelocityVertical > -maxClimbSpeed) 
		{
			currentVelocityVertical -= transform.up * 0.2f;
		}
		// Neither rising nor descending -- slowly decelerate vertical movement
		else
		{
			if(currentVelocityVertical > 0)
				currentVelocityVertical -= transform.up * 0.05f;
			else if(currentVelocityVertical < 0)
				currentVelocityVertical += transform.up * 0.05f;
		}
		
		transform.position += currentVelocityVertical * Time.deltaTime;
		
		if (Input.GetKeyDown (KeyCode.End))
		{
			Screen.lockCursor = (Screen.lockCursor == false) ? true : false;
		}
	}
}