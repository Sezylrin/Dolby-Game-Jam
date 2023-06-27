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
            
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
