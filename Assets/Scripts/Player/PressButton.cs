using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;

public class PressButton : NetworkBehaviour
{
    // Start is called before the first frame update
    private Camera cam;
    public Transform camPos;
    public LayerMask buttonLayer;
    public float interactDist;
    public Jam playerInput;
    void Start()
    {
        Debug.Log("Start");
        playerInput = new Jam();
    }

    private void Awake()
    {
        
    }
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (IsClient && IsOwner)
        {
            cam = Camera.main;
            Debug.Log("network start");
            if (playerInput == null)
            playerInput = new Jam();
            playerInput.Enable();
            playerInput.Player.Fire.performed += CheckClick;
        }
    }

    public override void OnNetworkDespawn()
    {
        base.OnNetworkDespawn();
        playerInput.Player.Fire.performed -= CheckClick;
        playerInput.Disable();
    }

    public void CheckClick(InputAction.CallbackContext context)
    {
        Debug.Log("pressing");
        RaycastHit hit;
        if (Physics.Raycast(camPos.position, cam.transform.forward, out hit, interactDist, buttonLayer))
        {
            Debug.Log("Triggering Hit");
            hit.collider.GetComponent<BaseButton>().TriggerButton();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
    }
}
