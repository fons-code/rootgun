using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Move mover;
    Gun gun;
    Vida vida;
    public float x;
    public float y;
    public bool cambiarDireccion;
    public GameObject jugador;
    public Quaternion rot;
    public Vector2 distancia;
    [SerializeField] ParticleSystem  particulas;
    [SerializeField] SpriteRenderer  sprite;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-1,1);
        y = Random.Range(1,1);
        mover = GetComponent<Move>();
        gun = GetComponent<Gun>();
        vida = GetComponent<Vida>();
        jugador = GameObject.Find("body");
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento
        rotateToPlayer();
        distancia = transform.position - jugador.transform.position;    
        if(cambiarDireccion)
        { 
            StartCoroutine(volverAMover());
            cambiarDireccion = false;
        }
        mover.mover(new Vector3(x,y,0));
         //Disparo
        if(!vida.destruir)
        {
            gun.Shot(transform.rotation);
        }
        
    }

    public IEnumerator volverAMover()
    {
        yield return new WaitForSeconds(1f);
        setValoresAXY(distancia);
        cambiarDireccion = true;
    }

    public void rotateToPlayer()
    {
        Vector3 dir = jugador.transform.position - transform.position;
        rot = Quaternion.LookRotation(Vector3.forward, dir);
        transform.rotation =  Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * 2f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {   
            vida.reducirVida();
        }
    }

    public void setValoresAXY(Vector2 dis)
    {

        if(dis.x<7)
        {
            x = Random.Range(1,1);
        } 
        else
        {
            x = Random.Range(-1,1);
        }
             

        if(dis.y>3)
        {
            y = Random.Range(-1,-1);
        }else if(dis.y<-3)
        {
            y = Random.Range(1,1);
        }
        else
        {
            y = Random.Range(-1,1);
        }
        
    }
}
