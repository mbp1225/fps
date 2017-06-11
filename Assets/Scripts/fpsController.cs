using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class fpsController : MonoBehaviour {

    public Camera viewCamera;

    // Variables for mouse and player movement.
    private float mouseX;
    private float mouseY;
    private float movH;
    private float movV;

    private Vector3 moveDirection = Vector3.zero;

    public float movementSpeed;
    public float turnSpeed;

    public float gravity;
    public float jumpHeight;

	void Start ()
    {

    }
	
	void Update ()
    {
        //Getting the controller.
        CharacterController controller = GetComponent<CharacterController>();

        //Setting variables.
        movH = Input.GetAxis("Horizontal");
        movV = Input.GetAxis("Vertical");

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        //Moving.

        if (controller.isGrounded)
        {
            Vector3 speed = (transform.forward * movV) + (transform.right * movH);

            moveDirection = new Vector3(speed.x, 0, speed.z);
            moveDirection *= movementSpeed;

            if (Input.GetButtonDown("Jump"))
                moveDirection.y = jumpHeight;
 
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        //Turning.
        viewCamera.transform.localEulerAngles += new Vector3(mouseY * -turnSpeed, 0, 0);
        controller.transform.localEulerAngles += new Vector3(0, mouseX * turnSpeed, 0);
    }
}
