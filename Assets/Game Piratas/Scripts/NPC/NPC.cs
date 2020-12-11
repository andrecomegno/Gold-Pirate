using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Animator anima;
    private Rigidbody2D rigi2d;

    private float speed = 15f;
    public float jump = 500f;

    // variavel voar/canhao
    public float voando = 50f;
    public Waypoints wpoints;
    public int waypointIndex;
    public bool voar;

    // variavel armas
    public bool padrao = true;
    public bool espada = false;

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        rigi2d = GetComponent<Rigidbody2D>();

        wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }

    // Update is called once per frame
    void Update()
    {
        Correr();
    }

    void Correr()
    {
        rigi2d.velocity = new Vector2(speed, rigi2d.velocity.y);
        anima.SetBool("Correr", true);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
