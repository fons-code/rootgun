using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public float cadencia = 1f;
    public bool puedeDisparar = true;
    // Update is called once per frame
    
    public void Shot()
    {
        if(puedeDisparar)
        {
            Instanciate(bullet,transform.position,Quaternion.identity);
            vuelveDisparar();
        }
    }
    
    IEnumerator vuelveDisparar()
    {
        yield return new WaitForSeconds(cadencia);
        puedeDisparar = true;
    }
}
