using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public float cadencia = 1f;
    public bool puedeDisparar;
    // Update is called once per frame
    
    public void Shot(Quaternion direction)
    {
        if(puedeDisparar)
        {   puedeDisparar = false;
            Vector3 balaVector =transform.position;
            GameObject shot = Instantiate(bullet,transform.position + new Vector3(1,1,0), direction);
            StartCoroutine(vuelveDisparar());
        }
    }
    
    IEnumerator vuelveDisparar()
    {
        yield return new WaitForSeconds(cadencia);
        puedeDisparar = true;
    }
}
