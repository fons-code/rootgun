using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvocarTexto : MonoBehaviour
{
    [SerializeField] TMP_Text texto;
    Move mover;
    public float x;
    public float y;
    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Move>();
        x = Random.Range(-1,1);
        y = Random.Range(1,1);
    }

    void Update()
    {
        mover.mover(new Vector3(x,y,0));
    }

    public void invocarTexto(string text)
    {
        texto.text = text;
        Destroy(gameObject,3f);
    }
}
