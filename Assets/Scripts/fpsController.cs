using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsController : MonoBehaviour {

    public Camera viewCamera;

    // Floats for mouse and player movement.
    private float mouseX;
    private float mouseY;
    private float movH;
    private float movV;

    public float movementSpeed;
    public float turnSpeed;

    private Rigidbody rb;

	void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        //Getting the axis' movements.
        movH = Input.GetAxis("Horizontal");
        movV = Input.GetAxis("Vertical");

        //Getting the mouse movement.
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        //Moving the player.
        if (movH != 0 | movV != 0)
        {
            rb.velocity = (viewCamera.transform.forward * movV * movementSpeed) + (viewCamera.transform.right * movH * movementSpeed);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

        //Moving the camera.
        viewCamera.transform.localEulerAngles += new Vector3(mouseY * -turnSpeed, mouseX * turnSpeed, 0);
        //viewCamera.transform.rotation = Quaternion(Mathf.Clamp(viewCamera.transform.localEulerAngles.x, -90, 80), viewCamera.transform.localEulerAngles.y, viewCamera.transform.localEulerAngles.z);
    }
}
