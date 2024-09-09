using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class movement : MonoBehaviour
{
    public float moveSpeed;
    public float sprintMultiplier = 1.4f; 
    new public Rigidbody2D rigidbody; 
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

    // Update is called once per frame
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

		// Membuat moveDirection dan normalisasi
		moveDirection = new Vector2(moveX, moveY).normalized;

		// Jika tidak ada input (tidak menekan tombol arah), set moveDirection ke (0,0)
		if (moveDirection.magnitude < 0.1f)
		{
			moveDirection = Vector2.zero;
		}

		// Hanya bisa sprint saat bergerak dan stamina mencukupi
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

		// Hentikan pergerakan ketika tidak ada input
		if (moveDirection == Vector2.zero)
		{
			rigidbody.velocity = Vector2.zero; // Set velocity ke nol saat tidak bergerak
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
		
		// Jika moveDirection cukup besar, maka moving = true, jika tidak, moving = false
		moving = moveDirection.magnitude > 0.1f;

		if (moving)
		{
			anim.SetFloat("X", x);
			anim.SetFloat("Y", y);
		}

		// Set animasi berdasarkan pergerakan
		anim.SetBool("Moving", moving);
	}
}
