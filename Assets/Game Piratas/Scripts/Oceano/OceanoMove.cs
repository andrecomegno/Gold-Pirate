using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanoMove : MonoBehaviour
{
    public float velo;
    public float finalX;
    public float comecarX;

    void Update()
    {
        Oceano();
    }

    void Oceano()
    {
        // ESSA LINHA QUE FAZ A VELOCIDADE DO OCEANO
        transform.Translate(Vector2.left * velo * Time.deltaTime);

        // ESSA LINHA ANDA EM LOOP 
        if (transform.position.x <= finalX)
        {
            Vector2 pos = new Vector2(comecarX, transform.position.y);
            transform.position = pos;
        }
    }
}
