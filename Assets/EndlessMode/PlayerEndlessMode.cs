using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerEndlessMode : MonoBehaviour
{
    Vector2 targetPos;
    public float Yincrement;
    public float speed;
    public float maxHeight;
    public float minHeight;
    public int maxHealth = 3;
    public int currentHealth;
    public Text HealthDisplay;
    public float center;
    void Start()
    {
        
        currentHealth = maxHealth;
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            TakeDamage(1);
            Debug.Log("Hit");
            
        }
        if (other.CompareTag("CenterB"))
        {
            targetPos = new Vector2(transform.position.x, 0);
        }
    }

    private void Update()
    {

       
        HealthDisplay.text = currentHealth.ToString();
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (CrossPlatformInputManager.GetButtonUp("UpArrow") && transform.position.y < maxHeight)
        {
           
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
        }
        else 
        if (CrossPlatformInputManager.GetButtonDown("DownArrow") && transform.position.y > minHeight)
        {
            
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
        }
       
        
    }
    
}
