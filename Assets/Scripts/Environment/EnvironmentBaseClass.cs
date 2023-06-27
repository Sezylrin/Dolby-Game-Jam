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
}
