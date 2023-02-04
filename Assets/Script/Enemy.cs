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
    public GameObject jugador;
    Quaternion rot;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-1,1);
        y = Random.Range(-1,1);
        mover = GetComponent<Move>();
        gun = GetComponent<Gun>();
        jugador = GameObject.Find("Hero");
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento
        if(cambiarDireccion)
        { 
            StartCoroutine(volverAMover());
            cambiarDireccion = false;
        }
        rotateToPlayer();
        mover.mover(new Vector3(x,y,0));

        //Disparo
        // float log = Mathf.Sqrt(2) - (int) Mathf.Sqrt(2);
        // Debug.Log(log);
        gun.Shot(transform.rotation);
    }

    public IEnumerator volverAMover()
    {
        yield return new WaitForSeconds(1f);
        x = Random.Range(-1,1);
        y = Random.Range(-1,1);
        cambiarDireccion = true;
    }

    public void rotateToPlayer()
    {
        Vector3 dir = jugador.transform.position - transform.position;
        rot = Quaternion.LookRotation(Vector3.forward, dir);
        transform.rotation =  Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * 2f);
    }
}
