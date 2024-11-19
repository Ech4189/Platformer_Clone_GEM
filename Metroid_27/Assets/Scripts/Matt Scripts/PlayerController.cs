using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Name: Matthew Borrelli
/// Date(Last Edited): 11/18/24
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
    public float deathY = -10.5f; //Prevents player from falling through the floor
    public GameObject bullet;

    [SerializeField]
    public float invincibilityDeltaTime;
    public GameObject respawnPoint;

    //Matthew Private Variables 
    private Rigidbody rb; //Gives player a rigidbody
    private bool facingRight = true; //Checks if player is facing right
    private Vector3 moveDir; //Allows player to move in given directions
    private float raycastDist = 1.2f;

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
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
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
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
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
        if ((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space)) && IsGrounded())
        {
            print("Jumped");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        Debug.DrawRay(transform.position, Vector3.down * raycastDist, Color.red);

        //Check for shooting input
        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.F))
        {
            print("Shot input detected");
            Shoot();
        }

        //Allows player to die
        Respawn();


        //Check if player is below a certain y value in the world
        if (transform.position.y <= deathY)
        {
            playerHealth --;
        }
        //Check for player damage


 
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (isInvincible)
        {
            StartCoroutine(
             InvincibilityFrames()
                );
        }
    }
    bool IsGrounded() //Checks if the player is on the ground so that there is no infinite jump
    {
        float raycastDist = 1.2f;
        
            bool IsGrounded = false;

            //perform a raycast to check if player is on the ground
            if (Physics.Raycast(transform.position, Vector3.down, raycastDist))
            {
                IsGrounded = true;
            }
            return IsGrounded;
    }
    public void Respawn() //(Doesn't actually respawn player it sends them to Game Over Screen)
    {
        if (playerHealth <= 0)
        {
            //Takes Player to Game Over Scene 
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
    public void Shoot()
        //Allows player to shoot in both directions
    {
        if (facingRight)
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 270, 0));
        else
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 90, 0));
    }
}