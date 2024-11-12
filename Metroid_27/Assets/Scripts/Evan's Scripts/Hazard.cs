using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Name: Evan Henderson
 * Date: 11/5/2024
 * Function: Handles things colliding with and damaging the player
 */

public class Hazard : MonoBehaviour
{
    public int enemyDamage;
    public int enemyHealth;
  
    public float playerHealth;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            //If hazard collides with player, the player health goes down by the amount the enemy damage is set to
            playerHealth -= enemyDamage;
        }
    }
    
    //Matthew Comment: I made a method with a variable for player invincibility. In here, you may be able to add,
    //an if statement where if the player loses health and is still alive then invincibility activates
    //Code must call the method when you are hit, and whenever you get hit in general check to see if the player
    //is invincible. Refer to the PlayerController Script 



    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            other.gameObject.GetComponent<PlayerController>().Respawn();
        }
    }*/

}
