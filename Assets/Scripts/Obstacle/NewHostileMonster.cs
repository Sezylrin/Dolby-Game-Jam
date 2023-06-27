using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHostileMonster : MonoBehaviour
{
    [SerializeField]
    private GameObject submarine;

    public float movementSpeed = 3.0f;

    public float playerDetectionDistance = 2.0f;

    private Vector3 lastPos;//last position of the player



    // Start is called before the first frame update
    void Start()
    {
        // instantiate object
        submarine = GameObject.FindGameObjectWithTag("Submarine"); //assign submarine
    }

    // Update is called once per frame
    void Update()
    {
        //check for distance between player and enemy 
        float distanceToPlayer = Vector3.Distance(transform.position, submarine.transform.position);

        if (submarine.transform.position != lastPos && distanceToPlayer <= playerDetectionDistance) //when player moved 
        {
            // Follow the player
            transform.LookAt(submarine.transform);
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }

        lastPos = submarine.transform.position;
    }
}
