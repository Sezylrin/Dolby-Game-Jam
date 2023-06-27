using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVolcano : MonoBehaviour
{
    public AudioClip triggerSound;
    public float detectionRadius=5.0f;
    public Transform player;

    private bool playerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        playerInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) // Replace "TriggerZone" with the appropriate tag for the trigger zone
        {
            // Calculate the distance between the player and the volcano
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance <= detectionRadius && !playerInRange)
            {
                // Player entered the detection radius for the first time
                playerInRange = true;
                if (triggerSound != null)
                {
                    AudioSource.PlayClipAtPoint(triggerSound, transform.position);
                }
            }
            else if (distance > detectionRadius && playerInRange)
            {
                // Player moved out of the detection radius
                playerInRange = false;
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
