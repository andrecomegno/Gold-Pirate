using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oceano : MonoBehaviour {
    public static Oceano gm;
    public BuoyancyEffector2D buoyancyEffector2D;

    public bool oceano = false;

    // Use this for initialization
    void Start () {
        gm = this;
        buoyancyEffector2D = GetComponent<BuoyancyEffector2D>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Pirata")
        {
            oceano = true;
            Debug.Log("Morreu");
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.tag == "Pirata")
        {
            oceano = false;
        }
    }
}
