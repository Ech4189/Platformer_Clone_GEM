using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Name: Matthew Borrelli
/// Date(Last Edited): 10/31/24
/// Purpose: For controlling the player movement, shooting, and health
/// </summary>
public class PlayerController : MonoBehaviour
{
    //Matthew Public Variables.
    public float moveSpeed = 10; //Dictates move speed of player
    public float jumpForce = 10;


    //Matthew Private Variables 
    private Vector3 moveDir;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //Matthew, RigidBody Code
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
  
        //Matthew, Code for moving Left and Right
        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDir = Vector3.left;
                rb.MovePosition(transform.position + moveDir * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveDir = Vector3.right;
                rb.MovePosition(transform.position + moveDir * moveSpeed * Time.deltaTime);
            }

        }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            print("Jumped");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    bool IsGrounded()
    {
        float raycastDist = 1.2f;
        {
            bool IsGrounded = false;

            //perform a raycast to check if player is on the ground
            if (Physics.Raycast(transform.position, Vector3.down, raycastDist))
            {
                IsGrounded = true;

                return IsGrounded;
            }
            return IsGrounded;

        }
    }
}
