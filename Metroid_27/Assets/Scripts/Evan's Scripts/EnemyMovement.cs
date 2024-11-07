using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Name: Evan Henderson
 * Date: 11/7/2024
 * Function: Handles the movement of enemies
 */

public class EnemyMovement : MonoBehaviour
{
    public GameObject leftPoint;
    public GameObject rightPoint;
    private Vector3 leftPos;
    private Vector3 rightPos;
    public float speed;
    public bool movingRight;

    // Start is called before the first frame update
    void Start()
    {
        leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }


    /// <summary>
    /// moves the enemy
    /// </summary>
    private void EnemyMove()
    {
        if (movingRight)
        {
            if (transform.position.x >= rightPos.x)
            {
                movingRight = false;
            }
            else
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        else
        {
            if (transform.position.x <= leftPos.x)
            {
                movingRight = true;
            }
            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
    }
}
