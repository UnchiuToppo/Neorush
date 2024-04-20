using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireBomb : MonoBehaviour
{
    bool Detected = false;
    public Transform Target;
    Vector2 Direction;
    public float Range;
    public GameObject explosionEffect;
    void Update()
    {
        Vector3 targetPos = Target.position;
        Direction = targetPos - transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);
        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                if (Detected == false)
                {
                    Detected = true;

                }
            
            
            
                if (Detected == true)
                {
                    explode();
                }
            }
            
        }

    }
    void explode()
    {
        GameObject ExplosionEffectIns = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.1f);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
