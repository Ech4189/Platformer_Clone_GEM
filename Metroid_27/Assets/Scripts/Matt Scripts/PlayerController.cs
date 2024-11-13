using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Name: Matthew Borrelli
/// Date(Last Edited): 11/12/24
/// Purpose: For controlling the player movement, shooting, and health
/// </summary>
public class PlayerController : MonoBehaviour
{
    //Matthew Public Variables.
    public float moveSpeed = 10; //Dictates move speed of player
    public float jumpForce = 10; //Dictates jumpForce of the player
    public float playerHealth = 99; //Dictates players health
    public bool isInvincible = false; //Checks if player has invincibility
    public float invincibilityTime = 5; //Limits player time for invincibility

    [SerializeField]
    public float invincibilityDeltaTime;

    public GameObject respawnPoint;

    //Matthew Private Variables 
    private Vector3 moveDir; //Allows player to move in given directions
    private Rigidbody rb; //Gives player a rigidbody
    private bool facingRight = true; //Checks if player is facing right

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


        Respawn();
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
        if (playerHealth <= 0)
        {
            print("Game Over");
            Destroy(gameObject);
            SceneManager.LoadScene("Game Over");
        }

    }



    public IEnumerator InvincibilityFrames()
    //puts player into an Invincibility state
    {
        isInvincible = true;
        for (float i = 0; i < invincibilityTime; )
        {

            GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(0.4f);
            i += .4f;
            GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(0.4f);
            i += .4f;
        }
        isInvincible = false;
    }
}
