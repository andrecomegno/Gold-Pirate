using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SelectInimigos
{
    Name, Tubarao, Esqueleto, Pirata, Lula, Macaco, Indio, Canhao
}

public enum InimigoCombate
{
    Name, IndioParado, IndioAtacar, IndioMorrer,
    TubaraoAtacar, TubaraoNadar,
    CanhaoParado, CanhaoAtirar
}

public class InimigoControle : MonoBehaviour
{
    public static InimigoControle gm;
    public SelectInimigos selectInimigos;
    public InimigoCombate InimigoCombate;
    private Rigidbody2D rigi2d;
    private Animator anima;
    public Transform pirata;
    private AudioSource audioSource;

    // VARIAVEIS TUBARAO
    private bool shake;
    private float TubaNadar = 8f;
    private float TubaAtacar = 35f;
    private CircleCollider2D circle2D;
    public bool flip = true;

    // VARIAVEIS CRIADA PARA ATIVAR ANIMAÇAO
    public bool indioAtacar = false;  
    public bool indioMorrer = false;
    public bool tubaraoAtacar = false;
    public bool canhaoAtirar = false;

    // VARIAVEIS INDIO MOEDAS
    public GameObject moedas;    
    public Transform TransformMoe;
    public GameObject moe;

    // VARIAVEIS BUMERANGUE
    public GameObject bumerangue;    
    public Transform TransformBume;
    public GameObject bume;
    public GameObject tracos;

    // VARIAVEIS CANHAO
    public GameObject Bala;
    public GameObject Ba;
    public Transform BaTransform;

    // VARIAVEIS AUDIOS
    public AudioClip[] AudiosObjetos;
    public AudioClip Faisca;

    void Awake()
    {
        gm = this;
        rigi2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        anima = GetComponent<Animator>();
        circle2D = GetComponent<CircleCollider2D>();
        pirata = GameObject.FindWithTag("Pirata").transform;

        if (selectInimigos == SelectInimigos.Indio)
        {
            tracos.SetActive(false);
        }            
    }

    void Update()
    {
        SelecionarInimigos();
    }

    void FixedUpdate()
    {
        // LINHA DE COMANDO QUE VERIFICA SE ESTA SELECIONADO O TUBARAO
        if (selectInimigos == SelectInimigos.Tubarao)
        {
            if (Oceano.gm.oceano == true)
            {
                // LINHA DE COMANDO QUE FAZ O TUBARAO IR NA DIREÇAO DO PIRATA
                transform.position = Vector2.MoveTowards(transform.position, pirata.position, TubaAtacar * Time.deltaTime);
            }

            if(tubaraoAtacar == true)
            {
                // ESSA LINHA E PARA PARAR O TUBARAO DEPOIS DE MATAR O PIRATA
                rigi2d.velocity = new Vector2(0, 0);
            }
            else
            {
                // ESSA LINHA FAZ O TUBARAO NADAR NORMALMENTE QUANDO O PIRATA NAO ESTIVER NO OCEANO
                rigi2d.velocity = new Vector2(TubaNadar, 0);
            }
        }
    }

    void SelecionarInimigos()
    {
        switch (InimigoCombate)
        {
            case InimigoCombate.IndioAtacar:
                IndioAtacar();
                break;
            case InimigoCombate.IndioMorrer:
                IndioMorrer();
                break;

            case InimigoCombate.TubaraoNadar:
                TubaraoNadar();
                break;
            case InimigoCombate.TubaraoAtacar:
                TubaraoAtacar();
                break;

            case InimigoCombate.CanhaoParado:
                CanhaoParado();
                break;
            case InimigoCombate.CanhaoAtirar:
                CanhaoAtirar();
                break;
        }

        TubaraoLogic();
        CanhaoLogic();
    }

    // LINHA DE COMANDO DO TUBARAO
    #region TUBARAO
    void TubaraoLogic()
    {
        if (selectInimigos == SelectInimigos.Tubarao)
        {   
            // LINHA DE COMANDO QUE VERIFICA SE O PIRATA ENTROU NO OCEANO, SE FOR VERDADEIRO
            // O TURABARAO VAI NA DIREÇAO DO PIRATA PARA MATAR
            if (Oceano.gm.oceano == true)
            {
                pirata = GameObject.FindWithTag("Pirata").transform;

                // LINHA DE COMANDO QUE VERIFICA O LADO DO PIRATA E DO TIBARAO MUDANDO O TUBARAO DE LADO ESQUERDO PARA DIRETO 
                if ( pirata.position.x < transform.position.x)
                {
                    flip = false;

                    // ESSA LINHA CONSERTA O CircleCollider2D PARA QUNADO O TUBARAO VIRA PARA O PIRATA
                    circle2D.offset = new Vector2(1.03f, -0.57f);
                }

                if (pirata.position.x > transform.position.x)
                {
                    flip = true;
                    circle2D.offset = new Vector2(-1.03f, -0.57f);
                }
            }

            // LINHA DE COMANDO SE A VARIAVEL tubaraoAtacar FOR IGUAL A VERDADEIRO ATIVAR A ANIMAÇAO ATACAR
            if (tubaraoAtacar == true)
            {
                if (InimigoCombate != InimigoCombate.TubaraoAtacar)
                {
                    InimigoCombate = InimigoCombate.TubaraoAtacar;
                }

                // LINHA DE COMANDO QUE DESABILITA O BuoyancyEffector2D PARA PODER A ANIMAÇÃO PIRATA FANTASMA TER EFEITO NO EIXO Y 
                Oceano.gm.buoyancyEffector2D.enabled = false;

                // LINHA DE COMANDO PARA O TUBARAO PARAR DE ATACAR O PIRATA
                Oceano.gm.oceano = false;
            }
            else
            {
                if (InimigoCombate != InimigoCombate.TubaraoNadar)
                {
                    InimigoCombate = InimigoCombate.TubaraoNadar;
                }                
            }
        }

        Flip();
    }

    void TubaraoNadar()
    {
        if (selectInimigos == SelectInimigos.Tubarao)
        {            
            anima.SetBool("TubaraoAtacar", tubaraoAtacar);            
        }        
    }

    void TubaraoAtacar()
    {
        if (selectInimigos == SelectInimigos.Tubarao)
        {
            anima.SetBool("TubaraoAtacar", tubaraoAtacar);
        }
    }

    // LINHA DE COMANDO QUE GIRA O PERSONAGENS
    void Flip()
    {
        if (!flip)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    #endregion

    // LINHA DE COMANDO DO INDIO PARA GERAR O BUMERAMGUE NO EVENTO DA ANIMAÇÂO
    #region INDIO
    public void IndioBumerangue()
    {
        bume = Instantiate(bumerangue, TransformBume.position, TransformBume.rotation) as GameObject;
    }

    public void IndioMoedas()
    {
        moe = Instantiate(moedas, TransformMoe.position, TransformMoe.rotation) as GameObject;
    }

    void IndioAtacar()
    {
        if (selectInimigos == SelectInimigos.Indio)
        {
            anima.SetBool("AtaqueLongo", indioAtacar);
        }
    }

    void IndioMorrer()
    {
        // NA TRANSAÇAO DA ANIMAÇAO ANIMATOR, DESABILITAR O HAS EXIT TIME PARA TER INICIO IMEDIATO
        if (selectInimigos == SelectInimigos.Indio)
        {
            anima.SetBool("Morrer", indioMorrer);
           
        }            
    }
    #endregion

    // LINHA DE COMANDO DO CANHOES
    #region CANHOES
    void CanhaoLogic()
    {
        if (selectInimigos == SelectInimigos.Canhao)
        {
            if (canhaoAtirar == true)
            {
                if (InimigoCombate != InimigoCombate.CanhaoAtirar)
                {
                    InimigoCombate = InimigoCombate.CanhaoAtirar;
                }
            }
            else
            {
                if (InimigoCombate != InimigoCombate.CanhaoParado)
                {
                    InimigoCombate = InimigoCombate.CanhaoParado;
                }
            }
        }
    }

    void CanhaoAtirar()
    {
        if (selectInimigos == SelectInimigos.Canhao)
        {
            anima.SetBool("CanhaoAtirar", canhaoAtirar);
        }
    }

    void CanhaoParado()
    {
        if (selectInimigos == SelectInimigos.Canhao)
        {
            anima.SetBool("CanhaoAtirar", canhaoAtirar);
        }
    }

    // LINHA DE COMANDO PARA GERAR O BOLA DO CANAHAO NO EVENTO DA ANIMAÇÂO
    public void CanhaoAudio()
    {
        Ba = GameObject.Instantiate(Bala, BaTransform.position, BaTransform.rotation) as GameObject;

        audioSource.clip = AudiosObjetos[Random.Range(0, AudiosObjetos.Length)];
        audioSource.Play();

        CameraShake.gm.Shake(0.2f, 0.4f);
    }

    // LINHDE DE COMANDO DO AUDIO DA FAISCA DO CANHAO
    void SomFaisca()
    {
        audioSource.PlayOneShot(Faisca);
    }

    #endregion

    public void OnDestroy()
    {
        Destroy(gameObject);
    }

    //LINHA DE COMANDO QUE VERIFICA A TAG PINGPONG E FAZENDO O TUBARAO IR E VOLTAR SEMPRE NA POSIÇAO.X, 
    // TAMBEM VIRA O TUBARAO PARA QUE SEMPRE FIQUE DE FRENTE PARA O SEU ALVO
    void OnTriggerEnter2D(Collider2D coll)
    {
        // LINHA DE COMANDO QUE VERIFICA SE O PIRATA ESTA DENTRO DO COLISOR DO TUBARAO
        if (selectInimigos == SelectInimigos.Tubarao)
        {
            // LAYER PINGPONG DESABILITADA PARA COLISSAO
            if (coll.CompareTag("PingPong"))
            {
                // LINHA QUE ALTERA A VELOCIDADE QUANDO MUDADO DE DIREÇAO COM O FLIP
                TubaNadar = -TubaNadar;
                flip = !flip;
//                Debug.Log("PingPong");
            }

            if (coll.CompareTag("Pirata"))
            {
                // ESSA LINHA QUE ATIVAR A VARIVEL ATACAR 
                tubaraoAtacar = true;

                // ESSA LINHA ATIVA A ANIMAÇAO DO PIRATA MORRER FANTASMA
                PirataControle.gm.MorrerFantasma();

                // ESSA LINHA ATIVA TREMER TELA
                StartCoroutine(Shake());
            }
        }

        // LINHA DE COMANDO QUE VERIFICA A DISTANCIA DO INIMIGO PARA O PIRATA
        if (selectInimigos == SelectInimigos.Indio)
        {
            // ESSA LINHA QUE VERICA SE ESTA COLIDINDO COM O PIRATA JUNTO COM A VARIAVEL indioAtacar PARA DIFERENCIAR OS INIMIGOS
            if (coll.CompareTag("Pirata") && !indioAtacar)
            {
                // ESSA LINHA VERIFICA A TAH PIRATA
                pirata = GameObject.FindWithTag("Pirata").transform;

                // ESSA LINHA ALTERA PARA INDIO ATACAR BUMERANGUE
                InimigoCombate = InimigoCombate.IndioAtacar;

                tracos.SetActive(true);

                // ESSA LINHA PARA ATIVAR A VARIAVEL PARA ATACAR
                indioAtacar = true;                
            }

            // LINHA DE COMONDO QUE VERIFICA AS ARMAS DO PIRATA JUNTO COM A VARIAVEL indioAtacar PARA DIFERENCIAR OS INIMIGOS
            if (coll.CompareTag("PirataArmas") && !indioMorrer)
            {
                // ESSA LINHA QUE ALTERA PARA MORRER INDIO
                InimigoCombate = InimigoCombate.IndioMorrer;


                tracos.SetActive(false);

                // ESSA LINHA FREZZA TODAS OS EIXOS 
                rigi2d.constraints = RigidbodyConstraints2D.FreezeAll;

                // ESSA LINHA MUDA PARA ALTERAR INDIOATACAR FALSE
                indioAtacar = false;

                // ESSA LINHA MUDA PARA ALTERAR INDIOMORRER TRUE
                indioMorrer = true;
            }
        }

        // LINHA DE COMANDO QUE VERIFICA SE O PIRATA ESTA DENTRO DO COLISOR CANHAO
        if (selectInimigos == SelectInimigos.Canhao)
        {
            if (coll.CompareTag("Pirata"))
            {
                canhaoAtirar = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        // LINHA DE COMANDO QUE VERIFICA SE O PIRATA ESTA FORA DO COLISOR CANHAO
        if (selectInimigos == SelectInimigos.Canhao)
        {
            if (coll.CompareTag("Pirata"))
            {
                canhaoAtirar = false;
            }
        }
    }

    // LINHA DE COMANDO QUE BALANÇA A TELA QUANDO ATIVA O DISPARO DO CANHAO
    public IEnumerator Shake()
    {
        CameraShake.gm.Shake(0.2f, 0.4f);
        yield return new WaitForSeconds(1);
        CameraShake.gm.Shake(0, 0);
    }

}
