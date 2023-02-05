using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public float score = 0;
    public bool terminado = false;
    public int ronda = 0;
    GameObject enemigoInvocado;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject boss;
    [SerializeField] GameObject PadreEnemigos;
    private List<Transform> Enemigos = new List<Transform>();

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
            Vector3 ubicacion = new Vector3 (posicion.x,posicion.y+(i*2),0);
            GameObject enemigoInvocado = Instantiate(enemy,ubicacion, direction);
            enemigoInvocado.GetComponentInChildren<Vida>().vida = cantidad;
            enemigoInvocado.transform.SetParent(PadreEnemigos.transform);
        }
    }

    public void spawnEnemysGame()
    {
        StartCoroutine(cicloEnemigos());
    }

    public void obtenerEnemigos()
    {   Enemigos.Clear();
        foreach(Transform child in PadreEnemigos.transform)
        {   
            Enemigos.Add(child);
        }

        Transform[] lista = Enemigos.ToArray();
        if(lista.Length == 1 && ronda < 4)
        {
            spawnEnemysGame();
        }

    }

    public IEnumerator cicloEnemigos()
    {
        yield return new WaitForSeconds(1f);
        Vector3 ubicacion = new Vector3 (4,-1f,0);
            switch (ronda)
            {
                case 0:
                        
                        enemigoInvocado = Instantiate(enemy,ubicacion, Quaternion.identity);
                        enemigoInvocado.GetComponentInChildren<Vida>().vida = 4;
                        enemigoInvocado.transform.SetParent(PadreEnemigos.transform);
                break;
                case 1:
                        enemigoInvocado = Instantiate(enemy,ubicacion, Quaternion.identity);
                        enemigoInvocado.GetComponentInChildren<Vida>().vida = 4;
                        enemigoInvocado.GetComponentInChildren<Vida>().Acorazado = true;
                        enemigoInvocado.GetComponentInChildren<Vida>().armadura = 2;
                        enemigoInvocado.transform.SetParent(PadreEnemigos.transform);
                break;
                case 2:
                    for(int i=0; i<3; i++)
                    {   if(i != 3)
                        {
                            ubicacion = new Vector3 (4,-1f+(i*2),0);
                            enemigoInvocado = Instantiate(enemy,ubicacion, Quaternion.identity);
                            enemigoInvocado.GetComponentInChildren<Vida>().vida = 4;
                            enemigoInvocado.transform.SetParent(PadreEnemigos.transform);
                        }
                        else
                        {
                            ubicacion = new Vector3 (4,-1f+(i*2),0);
                            enemigoInvocado = Instantiate(enemy,ubicacion, Quaternion.identity);
                            enemigoInvocado.GetComponentInChildren<Vida>().vida = 4;
                            enemigoInvocado.GetComponentInChildren<Vida>().Acorazado = true;
                            enemigoInvocado.GetComponentInChildren<Vida>().armadura = 4;
                            enemigoInvocado.transform.SetParent(PadreEnemigos.transform);                        
                        }
                    }

                break;
                case 3:
                        Debug.Log("oh no");
                        enemigoInvocado = Instantiate(boss,ubicacion, Quaternion.identity);
                break;
            }
            ronda++;
        }


}
