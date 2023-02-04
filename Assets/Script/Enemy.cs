using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Move mover;
    Gun gun;
    public float x;
    public float y;
    public bool cambiarDireccion;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-1,1);
        y = Random.Range(-1,1);
        mover = GetComponent<Move>();
        gun = GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cambiarDireccion)
        { 
            StartCoroutine(volverAMover());
            cambiarDireccion = false;
        }
        mover.mover(new Vector3(x,y,0));
    }

    public IEnumerator volverAMover()
    {
        yield return new WaitForSeconds(1f);
        x = Random.Range(-1,1);
        y = Random.Range(-1,1);
        cambiarDireccion = true;
    }
}
