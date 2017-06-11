using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class fpsController : MonoBehaviour {

    public Camera viewCamera;

    // Floats for mouse and player movement.
    private float mouseX;
    private float mouseY;
    private float movH;
    private float movV;

    public float movementSpeed;
    public float turnSpeed;

    public float gravity;
    public float jumpHeight;

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
            rb.velocity = (rb.transform.forward * movV * movementSpeed) + (rb.transform.right * movH * movementSpeed) + new Vector3(0, rb.velocity.y, 0);
        }
        else
        {
            //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
        }

        //Moving the view.
        viewCamera.transform.localEulerAngles += new Vector3(mouseY * -turnSpeed, 0, 0);
        rb.transform.localEulerAngles += new Vector3(0, mouseX * turnSpeed, 0);

        //Jumping.
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = rb.velocity + (Vector3.up * jumpHeight);
        }
        rb.velocity = rb.velocity + (Vector3.down * gravity);
    }
}
