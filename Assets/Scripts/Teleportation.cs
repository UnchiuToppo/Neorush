﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public GameObject Portal;
    public Transform Player;
    public Transform Camera;
   
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Teleport());
        }
    }
    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.2f);
        Player.transform.position = new Vector2(Portal.transform.position.x, Portal.transform.position.y);
        Camera.transform.position = new Vector3(20, 0, -100);
       
    }
}
