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

    public void moveFoward(Vector3 origen,Vector3 objetivo)
    {
        transform.position = Vector2.MoveTowards(origen,objetivo, (speed * Time.deltaTime));
    }
}
