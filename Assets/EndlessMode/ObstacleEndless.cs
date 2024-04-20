using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEndless : MonoBehaviour
{
   
    public float speed;
    public GameObject effect;
    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
