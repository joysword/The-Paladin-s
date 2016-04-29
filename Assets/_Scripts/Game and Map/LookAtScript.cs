using UnityEngine;
using System.Collections;

// Very simple smooth mouselook modifier for the MainCamera in Unity
// by Francis R. Griffiths-Keam - www.runningdimensions.com
// minor changes, Maciej Szpakowski

public class LookAtScript : MonoBehaviour {

    Vector2 _mouseAbsolute;
    Vector2 _smoothMouse;

    public Vector2 clampInDegrees = new Vector2(360, 180);
    public bool lockCursor;
    public Vector2 sensitivity = new Vector2(2, 2);
    public Vector2 smoothing = new Vector2(3, 3);
    public Vector2 targetDirection;
    public Vector2 targetCharacterDirection;
    public float moveSpeed;
    // Use this for initialization
    void Start()
    {
        // Set target direction to the camera's initial orientation.
        targetDirection = transform.localRotation.eulerAngles;
            }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, moveSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -moveSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0, Space.Self);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0, Space.Self);
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // Allow the script to clamp based on a desired target value.
        var targetOrientation = Quaternion.Euler(targetDirection);
        var targetCharacterOrientation = Quaternion.Euler(targetCharacterDirection);

        // Get raw mouse input for a cleaner reading on more sensitive mice.
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        // Scale input against the sensitivity setting and multiply that against the smoothing value.
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity.x * smoothing.x, sensitivity.y * smoothing.y));

        // Interpolate mouse movement over time to apply smoothing delta.
        _smoothMouse.x = Mathf.Lerp(_smoothMouse.x, mouseDelta.x, 1f / smoothing.x);
        _smoothMouse.y = Mathf.Lerp(_smoothMouse.y, mouseDelta.y, 1f / smoothing.y);

        // Find the absolute mouse movement value from point zero.
        _mouseAbsolute += _smoothMouse;

        // Clamp and apply the local x value first, so as not to be affected by world transforms.
        if (clampInDegrees.x < 360)
            _mouseAbsolute.x = Mathf.Clamp(_mouseAbsolute.x, -clampInDegrees.x * 0.5f, clampInDegrees.x * 0.5f);

        var xRotation = Quaternion.AngleAxis(-_mouseAbsolute.y, targetOrientation * Vector3.right);
        transform.localRotation = xRotation;

        // Then clamp and apply the global y value.
        if (clampInDegrees.y < 360)
            _mouseAbsolute.y = Mathf.Clamp(_mouseAbsolute.y, -clampInDegrees.y * 0.5f, clampInDegrees.y * 0.5f);

        transform.localRotation *= targetOrientation;

        // If there's a character body that acts as a parent to the camera
        
            var yRotation = Quaternion.AngleAxis(_mouseAbsolute.x, transform.InverseTransformDirection(Vector3.up));
            transform.localRotation *= yRotation;
    }
}
