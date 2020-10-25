/*
 * EnemyController.cs
 * Matthew Pereira
 * 101193046
 * 10/24/2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Variables for our Enemy to control speed, and location and direction
    public float verticalSpeed;
    public float verticalBoundary;
    public float direction;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    // Move the enemy by our vertical speed and our direction
    private void _Move()
    {
        transform.position += new Vector3(0.0f, verticalSpeed * direction * Time.deltaTime, 0.0f);
    }

    // Checks to see if we hit a boundry, and which side to figure the direction
    private void _CheckBounds()
    {
        // check Top boundary
        if (transform.position.y >= verticalBoundary)
        {
            direction = -1.0f;
        }

        // check bottom boundary
        if (transform.position.y <= -verticalBoundary)
        {
            direction = 1.0f;
        }
    }
}
