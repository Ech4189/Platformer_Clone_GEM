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
    
}
