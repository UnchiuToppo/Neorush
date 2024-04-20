using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{ 
      void Pickup()
     {
        Destroy(gameObject);
        
     }
    public void OnTriggerEnter2D(Collider2D other)
    { if (other.CompareTag("Player"))
    {
        Pickup();
        
    }
    }

    

}
    
