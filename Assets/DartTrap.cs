using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartTrap : MonoBehaviour
{

    public Transform ShootPoint;
    public GameObject dart;
    void Shoot()
    {
        Instantiate(dart, ShootPoint.position, Quaternion.identity);
    }
}
