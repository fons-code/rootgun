using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed=5f;
    public Camera cam;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousePos;
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

       mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
    }
}
