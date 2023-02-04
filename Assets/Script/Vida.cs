using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Vida : MonoBehaviour
{
    public int vida;
    public bool destruir = false;
    [SerializeField] TMP_Text texto;
    // Start is called before the first frame update
    void Start()
    {
        texto.text =vida.ToString();
    }

    public void reducirVida()
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
        }
        else
        {
            if(gameObject.tag == "Enemy")
            {
                GameManager.Instance.subirScore( Mathf.Sqrt(Mathf.Abs(vida)) - (int) Mathf.Sqrt(Mathf.Abs(vida)));
                vida =  (int) Mathf.Sqrt(Mathf.Abs(vida));
                texto.text = vida.ToString();
                GameManager.Instance.spawnEnemys(transform.position,vida,transform.rotation);
                Destroy(gameObject);
            }else
            {
                vida =  (int) Mathf.Sqrt(Mathf.Abs(vida));
                texto.text = vida.ToString();
            }
        }
    }

}
