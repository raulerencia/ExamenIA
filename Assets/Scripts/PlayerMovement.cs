using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed;
    public float turnSmoothTime;
    public float turnSmoothVelocity;
    public Transform cam;
    public float gravity = -9.8f;
    public float jumpForce = 1f;
    float fallVelocity;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        SetGravity();

        if (direction.magnitude >= 0.1f)
        {
            Vector3 moveDir = new Vector3(horizontal, 0f, vertical);
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    void SetGravity(){
    
        fallVelocity = gravity * Time.deltaTime;
        Vector3 gravityVector = new Vector3(0, fallVelocity, 0);
        controller.Move(gravityVector * Time.deltaTime);
        
    }
}
