using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
        float x;
        float y;
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        mover.mover(new Vector3(x,y,0));
    }
}
