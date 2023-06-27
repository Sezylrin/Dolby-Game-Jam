using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class HostileMonster : MonoBehaviour
{ 
    public GameObject player;

    public float movementSpeed = 3.0f;

    public float playerDetectionDistance = 10.0f;

    public bool isPlayerMoving; 

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        isPlayerMoving = (Mathf.Abs(horizontalInput) > 0 || Mathf.Abs(verticalInput) > 0);

        if (Vector3.Distance(transform.position, player.transform.position) > playerDetectionDistance)
        {
            // Move randomly within the sphere
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere;
            Vector3 newPosition = transform.position + randomDirection * movementSpeed * 50f * Time.deltaTime;
            transform.position = newPosition;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer > playerDetectionDistance)
        {
            // Move randomly within the sphere
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere;
            Vector3 newPosition = transform.position + randomDirection * movementSpeed * Time.deltaTime;
            transform.position = newPosition;
        }
        else if(isPlayerMoving)
        {
            // Follow the player
            transform.LookAt(player.transform);
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
    }

}
