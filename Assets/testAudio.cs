using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAudio : MonoBehaviour
{
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Submarine")
        {
            //source.mute == true;
        }
    }
}
