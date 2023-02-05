using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Vida : MonoBehaviour
{
    public int vida;
    public bool destruir = false;
    public bool Acorazado;
    public int armadura;
    [SerializeField] TMP_Text texto;
    [SerializeField] GameObject textoAaparecer;
    [SerializeField] GameObject AcorazadoGO;
    [SerializeField] TMP_Text textoACO;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.tag != "Player")
        {
            texto.text = vida.ToString();
        }

        AcorazadoGO.SetActive(Acorazado);
        if(Acorazado)
        {
            textoACO.text =  armadura.ToString();
        }
    }

    public void reducirVida()
    {   
        if(Acorazado)
        {
            armadura -= 2;
            if(armadura <= 0)
            {
                Acorazado = false;
                AcorazadoGO.SetActive(Acorazado);
            }
            else
            {
                textoACO.text =  armadura.ToString();
            }
        }
        else
        {        
            if(vida == 1)
            {
                destruir = true;
            }
            if(destruir)
            {
                Destroy(gameObject);
                if(gameObject.tag == "Player")
                {
                    GameManager.Instance.setEstadoDeJuego(true);
                }
                GameManager.Instance.obtenerEnemigos();
            }
            else
            {
                if(gameObject.tag == "Enemy")
                {   float txt = Mathf.Sqrt(Mathf.Abs(vida)) - (int) Mathf.Sqrt(Mathf.Abs(vida));
                    if( txt > 0)
                    {
                        GameObject textoInvo = Instantiate(textoAaparecer, transform.position,  Quaternion.identity);
                        textoInvo.GetComponent<InvocarTexto>().invocarTexto(txt.ToString());
                        GameManager.Instance.subirScore(txt);
                    }

                    vida = (int) Mathf.Sqrt(Mathf.Abs(vida));
                    texto.text = vida.ToString();
                    GameManager.Instance.spawnEnemys(transform.position,vida,transform.rotation);
                    Destroy(gameObject);
                }else
                {
                    vida -= 1;
                    if(gameObject.tag != "Player")
                    {
                        texto.text = vida.ToString();
                    }
                    
                }
            }
        }
    }
}
