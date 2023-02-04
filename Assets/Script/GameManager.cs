using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public float score = 0;
    public bool terminado = false;
    [SerializeField] GameObject enemy;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void subirScore(float valor)
    {
        score += valor * 100;
    }

    public bool getEstadoDeJuego()
    {
        return terminado;
    }

    public void setEstadoDeJuego(bool estado)
    {
        terminado = estado;
    }

    public void spawnEnemys(Vector3 posicion, int cantidad, Quaternion direction)
    {
        for(int i=0; i<cantidad; i++)
        {   
            Debug.Log(i);
            Vector3 ubicacion = new Vector3 (posicion.x+i,posicion.y,0);
            GameObject enemigoInvocado = Instantiate(enemy,ubicacion, direction);
            enemigoInvocado.GetComponentInChildren<Vida>().vida = cantidad;
        }
    }

}
