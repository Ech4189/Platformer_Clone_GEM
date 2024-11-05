using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Names: Matthew Borrelli
/// Last Updated: 10/31/24 
/// Purpose: Controlling the player character
/// </summary>


public class PlayerController : MonoBehaviour
{
    //Matthew, Public Variables. Dictates movement speed
    public float moveSpeed = 10;


    //Matthew, Private PlayerController Stuff
    private Vector3 moveDir;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //Matthew, RigidBody code
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Matthew, Code for moving Left and Right
        if (Input.GetKey(KeyCode.A))
        {
            moveDir = Vector3.left;
            rb.MovePosition(transform.position + moveDir * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            print ("Hi");
            moveDir = Vector3.right;
            rb.MovePosition(transform.position + moveDir * moveSpeed * Time.deltaTime);
        }
    }
}
