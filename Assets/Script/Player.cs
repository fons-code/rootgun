using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed=5f;
    public Rigidbody2D rb;
    Vector2 movement;
    Move mover;
    Gun gun;
    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Move>();
        gun = GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
