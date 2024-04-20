using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
public class PlayerMovementTopDown : MonoBehaviour
{
    private bool facingUp = true;
    private bool facingRight = true;
    public float speed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    void Update()
    {
        movement.x = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        movement.y = CrossPlatformInputManager.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        if (facingRight == false && movement.x > 0)
        {
            Flipx();
        }
        if (facingRight == true && movement.x < 0)
        {
            Flipx();
        }
        if (facingUp == false && movement.y > 0)
        {
            Flipy();
        }
        if (facingUp == true && movement.y < 0)
        {
            Flipy();
        }

    }
    void Flipx()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    void Flipy()
    {
        facingUp = !facingUp;
        Vector3 Scaler = transform.localScale;
        Scaler.y *= -1;
        transform.localScale = Scaler;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            Debug.Log("Dead");

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (other.CompareTag("Finish"))
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
