using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direccion;
    public float speed;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        Destroy(gameObject, 5);
    }
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
