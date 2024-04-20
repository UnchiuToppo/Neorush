using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    bool Detected = false;
    public float Range;
    public Transform Target;
    Vector3 Direction;
    public GameObject Gun;
    public GameObject Bullet;
    public float FireRate;
    public Transform ShootPoint;
    public float Force;
    float nextTimeToFire = 0;
    void Start()
    {

    }
    void Update()
    {   Vector3 targetPos = Target.position;
        Direction = targetPos - transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position,Direction,Range);
        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                if (Detected == false)
                {
                    Detected = true;
                    
                }
            }
            else
            {
                if (Detected == true)
                {
                    Detected = false;
                }
            }
            if (Detected == true)
            {
                Gun.transform.up = Direction;
                if (Time.time > nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1 / FireRate;
                    Shoot();
                }
            }
        }
            
    }
    void Shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position,Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
            
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,Range);
    }
   




}
