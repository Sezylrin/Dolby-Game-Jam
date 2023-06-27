using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVolcano : EnvironmentBaseClass
{
    // Start is called before the first frame update
    void Start()
    {
        playerInRange = false;
        soundMuted = false;
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
                if (!triggerSound.isPlaying)
                {
                    triggerSound.Play();
                }
                // Player entered the detection radius for the first time
                playerInRange = true;
                sub.audioSourceList.Add(triggerSound);
                // Mute the sound
                soundMuted = true;
                /*
                if (triggerSound != null)
                {
                    AudioSource.PlayClipAtPoint(triggerSound, transform.position);
                }*/

                 // Check if the player's "sonarlight_turn_on" variable is true
               /* if (player.GetComponent<PlayerController>().sonarlight_turn_on)
                {
                    // Pass the audio sample to the player for playback
                    player.GetComponent<PlayerController>().PlayOneShot(triggerSound);
                }*/
            }
            else if (distance > detectionRadius && playerInRange)
            {
                // Player moved out of the detection radius
                playerInRange = false;
                soundMuted = false;
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
