using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArmasInimigos
{
    name, bumerangue, espada, lanca 
}

public class InimigoArmas : MonoBehaviour
{

    public static InimigoArmas gm;
    public ArmasInimigos armasInimigos;
    public Animator anima;
    public AudioSource audioSource;
    public CircleCollider2D circle2D;

    // VARIAVEIS BUMERANGUE
    public SpriteRenderer SpriteBumerangue;
    public float VeloBume = 13;
    public float RotaBume = 500;
    public Rigidbody2D rigi2d;
    public bool dentro = false;

    void Start()
    {
        gm = this;
        audioSource = GetComponent<AudioSource>();
        anima = GetComponent<Animator>();
        rigi2d = GetComponent<Rigidbody2D>();
        SpriteBumerangue = GetComponent<SpriteRenderer>();
        circle2D = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        LogicBumerangue();
    }

    void LogicBumerangue()
    {
        // LINHA DE COMANDO QUE VERIFICA SE ESTA SELCIONA O BUMERAANGUE
        if (armasInimigos == ArmasInimigos.bumerangue)
        {
            // ESSA LINHA REPRESENTA O ROTACAO DO BUMERANGUE, TBM A VELOCIDADE E O GIRO NO EIXO 
            rigi2d.velocity = new Vector2(-VeloBume, 0);

            //LINHA DE COMANDO QUE VERIFICA SE ESTA DENTRO DO COLISOR PINGPONG
            if (dentro == true)
            {
                StartCoroutine(TimeBumerangue());
            }

            // LINHA DE COMANDO QUE FAZ O BUMERANGUE GIRAR 
            transform.Rotate(Vector3.forward * RotaBume * Time.deltaTime);
        }    
    }

    // ESSA LINHA DESTROI O BUMERANGUE QUANDO O INDIO MORRER
    public void Destruir()
    {   
        // LINHA DE COMANDO QUE VERIFICA SE ESTA SELECIONA O BUMERANGUE
        if (armasInimigos == ArmasInimigos.bumerangue)
        {
            // LINHA DE COMANDO QUE DESTROI O BUMERANGUE
            Destroy(gameObject, 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // LINHA DE COMANDO QUE VERIFICA SE ESTA SELECIONA O BUMERANGUE
        if (armasInimigos == ArmasInimigos.bumerangue)
        {
            // ESSA LINHA DESTROI O BUMERANGUE QUANDO O INDIO MORRER
            if (other.CompareTag("Inimigos"))
            {
                this.SpriteBumerangue.enabled = false;
                Destroy(gameObject, 1f);
            }

            // ESSE LINHA REPRESENTA O BUMERANGUE PINGPONG 
            if (other.CompareTag("PingPong"))
            {
                dentro = true;
            }

            // ESSA LINHA QUE VERICA SE ESTA COLIDINDO COM O PIRATA
            if (other.CompareTag("Pirata"))
            {
                // ESSA LINHA ATIVA A ANIMAÇAO MORRER SEM CABECA
                PirataControle.gm.MorrerSemCabeca();

                // ESSA LINHA ATIVA A ANIMAÇAO MORRER FANTASMA 
                PirataControle.gm.MorrerFantasma();
            }
        }
    }

    // ESSA LINHA REPRESENTA O TIME QUE O BUMERANGUE VAI FICAR PARADO NO AR
    public IEnumerator TimeBumerangue()
    {
        // ESSA LINHA PARA A VELOCIDADE DO BUMERANGUE PARA 0
        rigi2d.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(2);

        // ESSA LINHA VOLTA A VELOCIDADE PARA A MAO DO INDIO
        rigi2d.velocity = new Vector2(VeloBume, 0);
    }
}
