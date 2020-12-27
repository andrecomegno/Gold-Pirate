using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArmasInimigos
{
    name, bumerangue, espada, bolafogo, barril 
}

public enum InimigosAnimacao
{
    name, 
    Barril, Explosao
}

public class InimigoArmas : MonoBehaviour
{

    public static InimigoArmas gm;
    public ArmasInimigos armasInimigos;
    public InimigosAnimacao inimigosAnimacao;
    public Animator anima;
    public AudioSource audioSource;
    public CircleCollider2D circle2D;

    public float yVelo = 13;
    public float xVelo = 13;

    // BUMERANGUE
    public SpriteRenderer SpriteBumerangue;
    public float girar = 500;
    public Rigidbody2D rigi2d;
    public bool dentro = false;

    // VARIAVEIS DO AUDIOS
    public AudioClip[] AudiosObjetos;
    public AudioClip Faisca;

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
        InimigosArmas();
        Inimigos();
    }

    void Inimigos()
    {
        switch (inimigosAnimacao)
        {
            case InimigosAnimacao.Barril:
                Barril();
                break;
            case InimigosAnimacao.Explosao:
                Explosao();
                break;
        }
    }

    void InimigosArmas()
    {
        switch (armasInimigos)
        {
            case ArmasInimigos.bumerangue:
                Bumerangue();
                break;
            case ArmasInimigos.espada:
                break;
            case ArmasInimigos.bolafogo:
                BolaDeFogo();
                break;
            case ArmasInimigos.barril:
                BarrilExplosivo();
                break;
        }
    }

    void Barril()
    {
        anima.SetBool("Explosao", false);
    }

    void Explosao()
    {
        anima.SetBool("Explosao", true);
    }

    void BarrilExplosivo()
    {
        rigi2d.velocity = new Vector2(-xVelo, -yVelo);
    }

    void BolaDeFogo()
    {
        rigi2d.velocity = new Vector2(-xVelo, -yVelo);
    }

    public void BarrilAudio()
    {
        // ESSA LINHA E DA EXPLOSAO DO BARRIL 
        audioSource.clip = AudiosObjetos[Random.Range(0, AudiosObjetos.Length)];
        audioSource.Play();

        // ESSA LINHA QUE TREME A CAMERA
        CameraShake.gm.Shake(0.2f, 0.4f);
    }

    public void SomFaisca()
    {
        audioSource.PlayOneShot(Faisca);
    }

    void Bumerangue()
    {
        // ESSA LINHA REPRESENTA O ROTACAO DO BUMERANGUE, TBM A VELOCIDADE E O GIRO NO EIXO 
        rigi2d.velocity = new Vector2(-xVelo, -yVelo);

        //LINHA DE COMANDO QUE VERIFICA SE ESTA DENTRO DO COLISOR PINGPONG
        if (dentro == true)
        {
            StartCoroutine(TimeBumerangue());
        }

        // LINHA DE COMANDO QUE FAZ O BUMERANGUE GIRAR 
        transform.Rotate(Vector3.forward * girar * Time.deltaTime);  
    }

    // LINHA ESTA NO ANIMATION 
    public void Destruir()
    {   
        // LINHA DE COMANDO QUE VERIFICA SE ESTA SELECIONA O BUMERANGUE
        if (armasInimigos == ArmasInimigos.bumerangue)
        {
            // LINHA DE COMANDO QUE DESTROI O BUMERANGUE
            Destroy(gameObject, 1f);
        }

        if (armasInimigos == ArmasInimigos.barril)
        {
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

        if (armasInimigos == ArmasInimigos.bolafogo)
        {
            // ESSA LINHA QUE VERICA SE ESTA COLIDINDO COM O PIRATA
            if (other.CompareTag("Pirata"))
            {
                // ESSA LINHA ATIVA A ANIMAÇAO MORRER QUEIMADO
                PirataControle.gm.MorrerQueimado();

                PirataControle.gm.MorrerFantasma();

                Destroy(gameObject);
            }

            if (other.CompareTag("PirataArmas"))
            {
                Destroy(gameObject);
            }
        }

        if(armasInimigos == ArmasInimigos.barril)
        {
            if (other.CompareTag("Pirata"))
            {
                if(inimigosAnimacao != InimigosAnimacao.Explosao)
                {
                    inimigosAnimacao = InimigosAnimacao.Explosao;

                    // ESSA LINHA ATIVA A ANIMAÇAO MORRER QUEIMADO
                    PirataControle.gm.MorrerQueimado();

                    PirataControle.gm.MorrerFantasma();
                }
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
        rigi2d.velocity = new Vector2(xVelo, 0);
    }
}
