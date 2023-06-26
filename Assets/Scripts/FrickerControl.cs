using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrickerControl : MonoBehaviour
{
    public bool isFlickering = false;
    [SerializeField]
    private float timeDelay = 1f;

    //for alarm sound
    AudioSource source;
    //public AudioClip clip;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.Play();
    }

    void Update()
    {
        if(isFlickering == false)
        {
            StartCoroutine(FlickeringLight());
        }
        //player alarm sound 
        
    }

    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
