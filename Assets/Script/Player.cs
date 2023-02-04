using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed=5f;
    float h;
    float v;
    Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Move>();
        gun = GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
       h = Input.GetAxis("Horizontal");
       v = Input.GetAxis("Vertical");

       moveDirection.x = h;
       moveDirection.y = v;

       transform.position += moveDirection * Time.deltaTime * speed; 
    }
}
