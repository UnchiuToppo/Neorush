using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("FallPlatform", 1f);
            Destroy(gameObject, 4f);

        }

    }
    void FallPlatform()
    {
        rb.isKinematic = false;
    }
}
