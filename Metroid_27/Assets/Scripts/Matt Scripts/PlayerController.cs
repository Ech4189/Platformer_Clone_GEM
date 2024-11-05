using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Name: Matthew Borrelli
/// Date(Last Edited): 11/5/24
/// Purpose: For controlling the player movement, shooting, and health
/// </summary>
public class PlayerController : MonoBehaviour
{
    //Matthew Public Variables.
    public float moveSpeed = 10; //Dictates move speed of player
    public float jumpForce = 10;

    public GameObject respawnPoint;
    
    //Matthew Private Variables 
    private Vector3 moveDir;
    private Rigidbody rb;
    private bool facingRight = true;
    private float playerHealth = 100;


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
        //Check for left input
            if (Input.GetKey(KeyCode.A))
            {
                moveDir = Vector3.left;
                rb.MovePosition(transform.position + moveDir * moveSpeed * Time.deltaTime);
            //rotates character left
            if (facingRight)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                facingRight = false;
            }
        }


            //Check for right input
            if (Input.GetKey(KeyCode.D))
            {
                moveDir = Vector3.right;
                rb.MovePosition(transform.position + moveDir * moveSpeed * Time.deltaTime);
            //rotates character right
            if (!facingRight)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                facingRight = true;
            }
        }


        }
    void Update()
    {
        //Allows the player to jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            print("Jumped");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    bool IsGrounded() //Checks if the player is on the ground so that there is no infinite jump
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
    public void Respawn() //Respawns player
    {
        if(playerHealth <= 0)
        {
            Destroy(gameObject);
            //Teleport player to respawn point 
            transform.position = respawnPoint.transform.position;
        }
    }
}
