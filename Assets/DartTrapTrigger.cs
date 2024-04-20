using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartTrapTrigger : MonoBehaviour
{
   
    public GameObject dart;
    public Transform ShootPoint;
    bool isActivated = false;
    [SerializeField]
    GameObject trap;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
                isActivated = true;
                Shoot();    
        }
    }
    void Shoot()
    {
        Instantiate(dart, ShootPoint.position, Quaternion.identity);
    }
}
