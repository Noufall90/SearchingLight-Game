using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class movement : MonoBehaviour
{
    public float moveSpeed;
    public float sprintMultiplier = 1.4f; 
    public Rigidbody2D rigidbody; 
    private Vector2 moveDirection;
    public Animator anim;
    private Stamina staminaScript; 
    private bool isSprinting = false; 
    private bool moving;

    public ParticleSystem dust;

    void Start()
    {
        staminaScript = GetComponent<Stamina>(); 
    }

    void Update()
    {
        ProcessInput();
        Animate();
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

		if (moveDirection.magnitude < 0.1f)
		{
			moveDirection = Vector2.zero;
		}

		if (moveDirection.magnitude > 0 && staminaScript.stamina > (staminaScript.maxStamina * 0.2f) && Input.GetKey(KeyCode.LeftShift))
		{
			isSprinting = true;
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

		if (isSprinting)
		{
			currentMoveSpeed *= sprintMultiplier;
		}

		if (moveDirection == Vector2.zero)
		{
			rigidbody.velocity = Vector2.zero; 
		}
		else
		{
			rigidbody.velocity = moveDirection * currentMoveSpeed;
		}
	}


    void CrateDust()
    {
        dust.Play();
    }
	private void Animate()
	{
		float x = moveDirection.x;
		float y = moveDirection.y;
		
		moving = moveDirection.magnitude > 0.1f;

		if (moving)
		{
			anim.SetFloat("X", x);
			anim.SetFloat("Y", y);
		}
		anim.SetBool("Moving", moving);
	}
}
