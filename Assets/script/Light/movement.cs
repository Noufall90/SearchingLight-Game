using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    public float KBForce; 
    public float KBCounter; 
    public float KBTotalTime; 
    public bool KnockFromRight; 

    public ParticleSystem dust;
    public AudioSource audioSource; 
    public AudioClip walkSound;

    public Score scoreScript; // Referensi ke script Score

    void Start()
    {
        staminaScript = GetComponent<Stamina>(); 
        audioSource = GetComponent<AudioSource>(); 
        KBCounter = 0; 
    }

    void Update()
    {
        ProcessInput();
        Animate();
    }

    void FixedUpdate()
    {
        if (KBCounter <= 0)
        {
            Move();
        }
        else
        {
            if (KnockFromRight)
            {
                rigidbody.velocity = new Vector2(-KBForce, KBForce);
            }
            else
            {
                rigidbody.velocity = new Vector2(KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime; 
            if (KBCounter <= 0)
            {
                // Respawn coin yang terakhir diambil dan kurangi skor
                scoreScript.RespawnLastCollectedCoin();
                scoreScript.ScoreNum = Mathf.Max(scoreScript.ScoreNum - 1, 0); // Kurangi skor dan pastikan tidak kurang dari 0
                scoreScript.UpdateScoreText();
            }
        }
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
            if (audioSource.isPlaying) 
            {
                audioSource.Stop();
            }
        }
        else
        {
            rigidbody.velocity = moveDirection * currentMoveSpeed;

            if (!audioSource.isPlaying) 
            {
                audioSource.clip = walkSound;
                audioSource.loop = true;
                audioSource.Play();
            }
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
