using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class MoveSub : NetworkBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float Velocity;
    public List<AudioSource> audioSourceList=new List<AudioSource>();
    public GameObject audioSourceObj;
    public Vector3 reletivePos;
    public Vector3 initialPos;

    public float speedFactor;
    public float maxVelocity;
    public float currentVelocity = 0;
    public float acceleration;
    public float accelerationChange;

    public float angleChangeSpeed;
    public float angleChangeIncrement;
    public float currentAngle;

    public float currentPressure;

    public float pressureChangeValue;

    public float heightChangeValue;
    public float pressureMin;
    public float pressureMax;

    public bool increasePreasure = false;
    public bool decreasePreasure = false;

    public bool temp = false;

    public bool toggleSonar = false;

    public bool IsLightOn = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Invoke("StartMove", 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsServer) return;
        if (Mathf.Abs(transform.eulerAngles.y - currentAngle) < 1)
        {
            transform.eulerAngles = new Vector3(0, currentAngle, 0);
        }
        else if (transform.eulerAngles.y < currentAngle)
        {
            transform.Rotate(new Vector3(0, angleChangeSpeed * Time.deltaTime));
        }
        else if (transform.eulerAngles.y > currentAngle)
        {
            transform.Rotate(new Vector3(0, angleChangeSpeed * -1 * Time.deltaTime));
        }
        if (increasePreasure)
        {
            currentPressure += pressureChangeValue * Time.deltaTime;
        }
        if (decreasePreasure)
        {
            currentPressure -= pressureChangeValue * Time.deltaTime;
        }

        if (currentPressure < pressureMin)
        {
            transform.position += Vector3.up * heightChangeValue * Time.deltaTime;
        }
        if (currentPressure > pressureMin)
        {
            transform.position -= Vector3.up * heightChangeValue * Time.deltaTime;
        }

        audioSourceObj.transform.position = initialPos + reletivePos;
    }

    public void StartMove()
    {
        temp = true;
    }

    private void FixedUpdate()
    {
        if (temp)
            Move();
    }


    public void Move()
    {
        if (!IsServer) return;

        if (rb.velocity.magnitude < currentVelocity * speedFactor && currentVelocity > 0)
            rb.AddForce(transform.forward * acceleration * speedFactor, ForceMode.Impulse);
        else if (rb.velocity.magnitude < currentVelocity * speedFactor *-1)
            rb.AddForce(transform.forward * acceleration * -1 * speedFactor, ForceMode.Impulse);

        
    }
    [ContextMenu("Accelerate")]

    [ServerRpc(RequireOwnership = false)]
    public void IncreaseAccelerationServerRpc()
    {
        Debug.Log(IsOwner + " " + IsServer + " " + IsClient);
        Debug.Log("triggering acceleration");
        if (currentVelocity < maxVelocity)
        {
            currentVelocity++;
            if (currentVelocity < 1)
                acceleration -= accelerationChange;
            else if (currentVelocity > 0)
                acceleration += accelerationChange;
        }
    }
    [ContextMenu("Deccelerate")]
    [ServerRpc(RequireOwnership = false)]
    public void DecreaseAccelerationServerRpc()
    {
        if (currentVelocity > -maxVelocity)
        {
            currentVelocity--;
            if (currentVelocity > -1)
                acceleration -= accelerationChange;
            else if (currentVelocity < 0)
                acceleration += accelerationChange;
        }
    }

    [ContextMenu("TurnRight")]
    [ServerRpc(RequireOwnership = false)]
    public void TurnRightServerRpc()
    {
        currentAngle += angleChangeIncrement;
    }

    [ContextMenu("TurnLeft")]
    [ServerRpc(RequireOwnership = false)]
    public void TurnLeftServerRpc()
    {
        currentAngle -= angleChangeIncrement;
    }

    [ContextMenu("TogglePressureUp")]
    [ServerRpc(RequireOwnership = false)]
    public void ToggleUpServerRpc()
    {
        increasePreasure = !increasePreasure;
    }

    [ContextMenu("TogglePressureUp")]
    [ServerRpc(RequireOwnership = false)]
    public void ToggleDownServerRpc()
    {
        decreasePreasure = !decreasePreasure;
    }

    [ContextMenu("ToggleSound")]
    [ServerRpc(RequireOwnership = false)]
    public void ToggleSoundServerRpc()
    {
        toggleSonar = !toggleSonar;
    }


    [ContextMenu("ToggleFlashingLight")]
    [ServerRpc(RequireOwnership = false)]
    public void ToggleSoundLightServerRpc()
    {
        IsLightOn = !IsLightOn;
        if (IsLightOn)
        {
            //play flash animation on the light
        }
    }

    
}
