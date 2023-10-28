using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed;
    public float sprintMultiplier = 1.4f; // The multiplier for sprint speed (40% faster)
    new public Rigidbody2D rigidbody; // Use the 'new' keyword to hide the inherited member
    private Vector2 moveDirection;

    private Stamina staminaScript; // Reference to the Stamina script
    private bool isSprinting = false; // Keep track of sprinting state

    public ParticleSystem dust;

    // Start is called before the first frame update
    void Start()
    {
        staminaScript = GetComponent<Stamina>(); // Get the Stamina script component
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        // Allow sprinting only if stamina is above a threshold and player holds Shift
        if (staminaScript.stamina > (staminaScript.maxStamina * 0.2f) && (Input.GetKey(KeyCode.LeftShift)))
        {
            isSprinting = true;

            // Call CrateDust() to create dust particles when Shift is pressed
            CrateDust();
        }
        else
        {
            isSprinting = false;
        }
    }

    void Move()
    {
        float currentMoveSpeed = moveSpeed;

        // Apply sprinting multiplier if sprinting is allowed
        if (isSprinting)
        {
            currentMoveSpeed *= sprintMultiplier;
        }

        rigidbody.velocity = moveDirection * currentMoveSpeed;
    }

    void CrateDust()
    {
        dust.Play();
    }
}
