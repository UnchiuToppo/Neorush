using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public float health = 20f;
    public float currentHealth;
    public float dealDamage;
    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Start()
    {
        
        currentHealth = health;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))
            TakeDamage(20);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    
}
