using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;

    public void mover(Vector3 movimiento)
    {
        transform.position += movimiento * Time.deltaTime * speed;
    }
}
