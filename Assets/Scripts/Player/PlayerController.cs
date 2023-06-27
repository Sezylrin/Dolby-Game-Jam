using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public float maxSpeed;
    private float currentMaxSpeed;
    public float acceleration;
    public Vector3 direction;

    private Jam playerInput;
    private void Awake()
    {
        playerInput = new Jam();
    }
    private void OnEnable()
    {
        playerInput.Enable();

        playerInput.Player.Move.performed += SetDirection;
        playerInput.Player.Move.canceled += SetDirection;
    }

    private void OnDisable()
    {

        playerInput.Player.Move.performed -= SetDirection;
        playerInput.Player.Move.canceled -= SetDirection;
        playerInput.Disable();

    }

    private void SetDirection(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>().normalized;
        direction = new Vector3(input.x,0,input.y);
    }
    void Start()
    {
        currentMaxSpeed = maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {
        if (!IsOwner)
            return;
        if (rb.velocity.magnitude <= maxSpeed && !direction.Equals(Vector3.zero))
        {
            if ((rb.velocity + direction * acceleration * rb.mass).magnitude > currentMaxSpeed)
            {
                rb.velocity += direction * acceleration * rb.mass;
                rb.velocity = rb.velocity.normalized * currentMaxSpeed;
            }
            else
                rb.AddForce(direction * acceleration * rb.mass, ForceMode.Impulse);
        }
    }

}

