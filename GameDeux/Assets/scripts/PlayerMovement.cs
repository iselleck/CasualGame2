using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	//object identifiers
	public Rigidbody playerRigid;
	public float cameraSensitivity = 90;

    // Movement constants
	public float hThrust;
	public float vThrust;

    public float fVel = 0;
    public float hVel = 0;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Start()
    {
        Screen.lockCursor = true;
		playerRigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
		//USE THE "L" KEY TO GET OUT OF SCREENLOCK -G
		if (Input.GetKeyDown(KeyCode.L)){
			Screen.lockCursor = false;
		}
	
		// Rotation
		rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
		rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
		//rotationY = Mathf.Clamp (rotationY, -90, 90); EXTRA SPACE

        playerRigid.rotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        playerRigid.rotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

        //FORWARDS
        if (Input.GetKey(KeyCode.W)){
			playerRigid.AddRelativeForce(Vector3.forward * hThrust);
        }

        //BACKWARDS
        if (Input.GetKey(KeyCode.S)){
			playerRigid.AddRelativeForce(Vector3.back * hThrust);
        }
		//STRAFE CONTROLS
		if (Input.GetKey(KeyCode.A)){
			playerRigid.AddRelativeForce(Vector3.left * hThrust);
		}

		if (Input.GetKey(KeyCode.D)){
			playerRigid.AddRelativeForce(Vector3.right * hThrust);
		}

        //VERTICAL CONTROLS
        if (Input.GetKey(KeyCode.R)){
			playerRigid.AddRelativeForce(Vector3.up * vThrust);
        }
		
        if (Input.GetKey(KeyCode.F)){
			playerRigid.AddRelativeForce(Vector3.down * vThrust);
        }

		//ROTATION CONTROLS
	
    }
}