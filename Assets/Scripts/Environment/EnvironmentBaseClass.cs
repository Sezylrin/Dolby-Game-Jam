using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentBaseClass : MonoBehaviour
{
    public AudioClip triggerSound;

    public float detectionRadius = 5.0f;
    public Transform player;

    public bool playerInRange = false;
    public bool soundMuted = false;

    public MoveSub sub;

    public virtual void PlayAudio()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < detectionRadius)
        {
            sub.IsLightOn = true;
            sub.reletivePos = transform.position - player.transform.position;
            AudioSource temp = sub.audioSourceObj.GetComponent<AudioSource>();
            temp.clip = triggerSound;
            temp.loop = true;
            if(!temp.isPlaying)
                temp.Play();
            if (sub.toggleSonar)
            {
                temp.mute = false;
            }
            else
                temp.mute = true;

        }
        else
        {
            sub.IsLightOn = false;
        }
    }

    
}
