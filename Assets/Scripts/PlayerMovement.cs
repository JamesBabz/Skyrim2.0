using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 6.0F;
    public float jumpHeight = 8.0F;
    private Vector3 moveDirection = Vector3.zero;
    private bool isGrounded = false;
    private float distToGround;

    void Start()
    {
           distToGround = this.gameObject.GetComponent<BoxCollider>().bounds.extents.y;
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump") && isGrounded)
                moveDirection.y = jumpHeight;
            
        this.transform.position += moveDirection;
    }
}
