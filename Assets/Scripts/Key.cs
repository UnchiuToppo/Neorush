using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Transform doorClosed, doorOpened;
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PickUp();
        }

    }
    public void PickUp()
    {   
        Destroy(gameObject, 0.01f);
        doorOpened.transform.position = doorClosed.position;
        doorClosed.transform.position = new Vector2(0f, -100f);
       
    }
}
