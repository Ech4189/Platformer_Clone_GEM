using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Name: Evan Henderson
 * Date: 11/5/2024
 * Function: To handle the player's gun functionality
 */

public class Bullets : MonoBehaviour
{
    public int bulletDamage;
    public GameObject bullet;

    //Make laser and spawner - the laser will be the bullet
    //Spawner will be activated by a key press rather than a timer
    //Spawner will be attached to the player 

    //When bullet hits something it "dies"
    //If it hits specific things, it does something before it "dies"

    //Need to be able to fire left and right, "if goingLeft" won't work here

    [Header("Projectile Variables")]
    public float speed;
    //public bool going left, if it's false go right

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Moves the bullet when fired
    /// </summary>
    private void MoveBullet()
    {
        transform.position += speed * Vector3.left * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("lmao");
        //when the bullet hits an object, destroy(game object)
        if (other.gameObject.tag != "Bullet")
        {
            Destroy(gameObject);
            
        }
    }
}
