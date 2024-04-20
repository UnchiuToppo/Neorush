using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool facingRight = true;
    private Rigidbody2D rb;
    public GameObject JumpingEffect;
    private int extraJumps;
    public int extraJumpsValue;
    private Shake shake;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }
    void FixedUpdate()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }
        if(facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }
    void Update()
    {   
        if (isGrounded == false && extraJumps == 0)
        {
            shake.CamShake();
        }
        if (isGrounded == true)
        {
            extraJumps = 1;
        }
        
       

        if (CrossPlatformInputManager.GetButtonDown("Jump") && extraJumps > 0 )
        {
            
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            Instantiate(JumpingEffect, transform.position, Quaternion.identity);
            
        }
        else if (CrossPlatformInputManager.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
        {
            
            rb.velocity = Vector2.up * jumpForce;
            Instantiate(JumpingEffect,transform.position, Quaternion.identity);
        }
        animator.SetFloat("Speed",Mathf.Abs(moveInput));
       
    }
    
    
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Spike")
        {
            Debug.Log("Dead");

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (other.tag == "Finish")
        {
            Debug.Log("Win");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
    
}
