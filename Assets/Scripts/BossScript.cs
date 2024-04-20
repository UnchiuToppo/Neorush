using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BossScript : MonoBehaviour
{
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    public Transform player;
    
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public int maxHealth = 4;
    public int currentHealth;
     public HealthBar healthBar;
    void Die()
    {
        Destroy(gameObject);
    }
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
            if (other.tag == "BulletBoss")
                TakeDamage(250);
        
    }
        void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    


    }

