using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployShuriken : MonoBehaviour
{
    public GameObject Shuriken;
    public float xPositionLimit;
    public float SpawnRate;
    void Start()
    {
        
        StartSpawn();
    }
    public void ShurikenSpawn()
    {
        float randomXposition = Random.Range(-xPositionLimit, xPositionLimit);
        Vector3 SpawnPosition = new Vector3(xPositionLimit,transform.position.y);
        Instantiate(Shuriken, SpawnPosition, Quaternion.identity);
    }
    public void StartSpawn()
    {
        InvokeRepeating("ShurikenSpawn", 1f, SpawnRate);
    }
}
