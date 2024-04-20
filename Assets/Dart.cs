using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    public float speed;
    public GameObject effect;
    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject, 2.6f);
    }
}
