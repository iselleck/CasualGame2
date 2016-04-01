using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    // Movement constants
    public float cameraSensitivity = 90;
    public float maxClimbSpeed = 4;
    public float maxMoveSpeed = 10;
    /* public float slowMoveFactor = 0.25f;
	public float fastMoveFactor = 3; */

    // We use these to handle momentum + max speed
    public float currentVelocityOrthogonal = 0;
    public float currentVelocityVertical = 0;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Start()
    {
        Screen.lockCursor = true;
    }

    void Update()
    {
		//USE THE "END" KEY TO GET OUT OF SCREENLOCK -G
		if (Input.GetKeyDown(KeyCode.End))
		{
			Screen.lockCursor = (Screen.lockCursor == false) ? true : false;
		}
		// Rotation
		rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
		rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
		//rotationY = Mathf.Clamp (rotationY, -90, 90); EXTRA SPACE

        transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

        // Acceleration - Orthogonal
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.W))
        {
            if (currentVelocityOrthogonal < maxMoveSpeed)
            {
                currentVelocityOrthogonal += 0.06f * Time.deltaTime;
            }
        }
        // Deceleration/Reverse - Orthogonal
        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.S))
        {
            if (currentVelocityOrthogonal > maxMoveSpeed)
            {
                currentVelocityOrthogonal -= 0.06f * Time.deltaTime;
            }
        } // NOTE: Velocity seems to be reset to 0 when we stop accelerating/decelerating. Not very "space-y," but easier to control -- keep, or fix?
		// I'm gonna fix the fuckin' shit out of this. -G

        // Acceleration/Climbing - Vertical
        if (Input.GetKey(KeyCode.R) && currentVelocityVertical < maxClimbSpeed)
        {
            currentVelocityVertical += 0.06f * Time.deltaTime;
        }
        // Deceleration/Descending - Vertical
        else if (Input.GetKey(KeyCode.F) && currentVelocityVertical > -maxClimbSpeed)
        {
            currentVelocityVertical -= 0.06f * Time.deltaTime;
        }

        // Apply velocity to position
        transform.position += transform.forward * Input.GetAxis("Vertical") * currentVelocityOrthogonal;
        transform.position += transform.right * Input.GetAxis("Horizontal") * currentVelocityOrthogonal;
        transform.position += transform.up * currentVelocityVertical;

    }
}