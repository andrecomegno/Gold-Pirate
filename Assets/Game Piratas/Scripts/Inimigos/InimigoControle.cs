using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SelectInimigos
{
    Name, Tubarao, Indio, Urubu, Urubu_Fogo, Urubu_Barril, Abelha
}

public enum InimigoCombate
{
    Name, 
    IndioParado, IndioAtacar, IndioMorrer,
    TubaraoAtacar, TubaraoNadar,
    UrubuVoando, UrubuAtacar, UrubuMorrer,
    AbelhaVoando, AbelhaAtacar, AbelhaMorrer
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

    // INIMIGOS
    public float jumpHead = 950f;
    public float distance;
    public bool mover = true;

    // TUBARAO
    private bool shake;
    private float TubaNadar = 8f;
    private float TubaAtacar = 35f;
    private CircleCollider2D circle2D;
    public bool flip = true;

    // INIMIGOS MOEDAS
    public GameObject moedas;    
    public Transform transformeMoedas;
    private GameObject moeClone;

    // INIMIGOS ARMAS
    public GameObject Armas;    
    public Transform transformArmas;
    private GameObject armaClone;
    public GameObject tracos;

    void Awake()
    {
        gm = this;
        rigi2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        anima = GetComponent<Animator>();
        circle2D = GetComponent<CircleCollider2D>();
        pirata = GameObject.FindWithTag("Pirata").transform;          
    }

    void Update()
    {
        CombateInimigos();
        Inimigos();
    }

    void FixedUpdate()
    {
        TubaraoMover();

        UrubuMover();

        AbelhaMover();
    }

    void Inimigos()
    {
        switch (selectInimigos)
        {
            case SelectInimigos.Urubu:
                Urubu();
                break;
            case SelectInimigos.Urubu_Fogo:
                Urubu_Fogo();
                break;
            case SelectInimigos.Urubu_Barril:
                Urubu_Barril();
                break;
            case SelectInimigos.Indio:
                Indio();
                break;
            case SelectInimigos.Tubarao:
                Tubarao();
                break;
            case SelectInimigos.Abelha:
                Abelha();
                break;
        }
    }

    void CombateInimigos()
    {
        switch (InimigoCombate)
        {
            // Urubu
            case InimigoCombate.UrubuVoando:
                UrubuVoando();
                break;
            case InimigoCombate.UrubuAtacar:
                UrubuAtacar();
                break;
            case InimigoCombate.UrubuMorrer:
                UrubuMorrer();
                break;

            // Indio
            case InimigoCombate.IndioParado:
                IndioParado();
                break;
            case InimigoCombate.IndioAtacar:
                IndioAtacar();
                break;
            case InimigoCombate.IndioMorrer:
                IndioMorrer();
                break;

            // Tubarão
            case InimigoCombate.TubaraoNadar:
                TubaraoNadar();
                break;
            case InimigoCombate.TubaraoAtacar:
                TubaraoAtacar();
                break;

            // Abelha
            case InimigoCombate.AbelhaVoando:
                AbelhaVoando();
                break;
            case InimigoCombate.AbelhaAtacar:
                AbelhaAtacar();
                break;
            case InimigoCombate.AbelhaMorrer:
                AbelhaMorrer();
                break;
        }
    }

    #region TUBARAO
    void Tubarao()
    {
        if (Oceano.gm.oceano == true)
        {
            pirata = GameObject.FindWithTag("Pirata").transform;

            // LINHA DE COMANDO QUE VERIFICA O LADO DO PIRATA E DO TUBARAO MUDANDO O TUBARAO DE LADO ESQUERDO PARA DIRETO 
            if (pirata.position.x < transform.position.x)
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

            // LINHA DE COMANDO QUE DESABILITA O BuoyancyEffector2D PARA PODER A ANIMAÇÃO PIRATA FANTASMA TER EFEITO NO EIXO Y 
            Oceano.gm.buoyancyEffector2D.enabled = false;
        }

        Flip();
    }

    void TubaraoNadar()
    {
        anima.SetBool("Atacar", false);
    }

    void TubaraoAtacar()
    {
        anima.SetBool("Atacar", true);
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

    void TubaraoMover()
    {
        // LINHA DE COMANDO QUE VERIFICA SE ESTA SELECIONADO O TUBARAO
        if (selectInimigos == SelectInimigos.Tubarao)
        {
            if (Oceano.gm.oceano == true)
            {
                // LINHA DE COMANDO QUE FAZ O TUBARAO IR NA DIREÇAO DO PIRATA
                transform.position = Vector2.MoveTowards(transform.position, pirata.position, TubaAtacar * Time.deltaTime);
            }

            if (InimigoCombate == InimigoCombate.TubaraoAtacar)
            {
                rigi2d.velocity = new Vector2(0, 0);
            }
            else if (InimigoCombate == InimigoCombate.TubaraoNadar)
            {
                rigi2d.velocity = new Vector2(TubaNadar, 0);
            }
        }
    }
    #endregion

    #region INDIO
    public void IndioBumerangue()
    {
        // LINHA DE COMANDO DO INDIO PARA GERAR O BUMERAMGUE NO EVENTO ANIMATION
        armaClone = Instantiate(Armas, transformArmas.position, transformArmas.rotation) as GameObject;
    }
    
    public void ArmaTracos()
    {
        // EVENTO ANIMATION, ATIVAR E DESATIVAR OS TRAÇOS DO BUMERANGUE
        if (InimigoCombate == InimigoCombate.IndioAtacar)
        {
            tracos.SetActive(true);
        }
        else if (InimigoCombate == InimigoCombate.IndioParado)
        {
            tracos.SetActive(false);
        }
    }

    void IndioParado()
    {
        // ATIVA A ANIMAÇAO PARADO DO INDIO
        anima.SetBool("Atacar", false);
    }

    void IndioAtacar()
    {
        // ATIVA A ANIMAÇAO ATACAR DO INDIO
        anima.SetBool("Atacar", true);
    }

    void IndioMorrer()
    {
        /* ATIVAR ANIMAÇÃO MORRER DO INDIO 
         * NA TRANSAÇAO DA ANIMAÇAO ANIMATOR, DESABILITAR O HAS EXIT TIME PARA TER INICIO IMEDIATO */
        anima.SetBool("Morrer", true);
    }

    void Indio()
    {
        // DISTACIA DO PIRATA PARA O INDIO
        distance = (transform.position.x - pirata.position.x);

        // SE A DISTANCIA FOR MENOR QUE 18 O INDIO ATACA SE FOR MENOR ELE PARA DE ATACAR
        if (distance < 18)
        {
            if (InimigoCombate != InimigoCombate.IndioAtacar)
            {
                InimigoCombate = InimigoCombate.IndioAtacar;
            }
        }
        else if (distance > 18)
        {
            if (InimigoCombate != InimigoCombate.IndioParado)
            {
                InimigoCombate = InimigoCombate.IndioParado;
            }
        }
    }
    #endregion

    #region URUBU
    public void UrubuArmas()
    {
        armaClone = Instantiate(Armas, transformArmas.position, transformArmas.rotation) as GameObject;
    }

    void UrubuVoando()
    {
        anima.SetBool("Atacar", false);
    }

    void UrubuAtacar()
    {
        anima.SetBool("Atacar", true);
    }

    void UrubuMorrer()
    {
        anima.SetBool("Morrer", true);
    }

    void Urubu()
    {
        // Urubu Não Atacar 
    }

    void Urubu_Fogo()
    {
        distance = (transform.position.x - pirata.position.x);

        if (distance < 18)
        {
            if (InimigoCombate != InimigoCombate.UrubuAtacar)
            {
                InimigoCombate = InimigoCombate.UrubuAtacar;                
            }
        }
        else if (distance > 18)
        {
            if (InimigoCombate != InimigoCombate.UrubuVoando)
            {
                InimigoCombate = InimigoCombate.UrubuVoando;
            }            
        }        

        if (distance > 20)
        {
            Destroy(armaClone);
        }
    }

    void Urubu_Barril()
    {
        distance = (transform.position.x - pirata.position.x);

        if (distance < 5)
        {
            if (InimigoCombate != InimigoCombate.UrubuAtacar)
            {
                InimigoCombate = InimigoCombate.UrubuAtacar;
            }
        }
    }

    void UrubuMover()
    {
        if (selectInimigos == SelectInimigos.Urubu_Barril)
        {
            rigi2d.velocity = new Vector2(-8, 0);
        }
    }

    #endregion

    #region Abelha
    void Abelha()
    {
        distance = (transform.position.x - pirata.position.x);

        if (distance < 18)
        {
            if (InimigoCombate != InimigoCombate.AbelhaAtacar)
            {
                InimigoCombate = InimigoCombate.AbelhaAtacar;
            }
        }
        else if (distance > 18)
        {
            if (InimigoCombate != InimigoCombate.AbelhaVoando)
            {
                InimigoCombate = InimigoCombate.AbelhaVoando;
            }
        }
    }

    void AbelhaVoando()
    {
        anima.SetBool("Atacar", false);
    }

    void AbelhaAtacar()
    {
        anima.SetBool("Atacar", true);
    }

    void AbelhaMorrer()
    {
        anima.SetBool("Morrer", true);
    }

    void AbelhaMover()
    {
        if (selectInimigos == SelectInimigos.Abelha)
        {
            if (mover)
            {
                transform.position = Vector2.MoveTowards(transform.position, pirata.position, 12 * Time.deltaTime);
            }
            else
            {
                rigi2d.velocity = new Vector2(0, 0);
            }
            
        }
    }

    #endregion

    void OnTriggerEnter2D(Collider2D coll)
    {
        #region Tubarao
        // LINHA DE COMANDO QUE VERIFICA SE O PIRATA ESTA DENTRO DO COLISOR DO TUBARAO
        if (selectInimigos == SelectInimigos.Tubarao)
        {
            // LAYER PINGPONG DESABILITADA PARA COLISSAO
            if (coll.CompareTag("PingPong"))
            {
                // LINHA QUE ALTERA A VELOCIDADE QUANDO MUDADO DE DIREÇAO COM O FLIP
                TubaNadar = -TubaNadar;
                flip = !flip;
            }

            if (coll.CompareTag("Pirata"))
            {
                // ESSA LINHA QUE ATIVAR A VARIVEL ATACAR 
                if(InimigoCombate != InimigoCombate.TubaraoAtacar)
                {
                    InimigoCombate = InimigoCombate.TubaraoAtacar;

                    // ESSA LINHA ATIVA A ANIMAÇAO DO PIRATA MORRER FANTASMA
                    PirataControle.gm.MorrerFantasma();

                    // LINHA DE COMANDO PARA O TUBARAO PARAR DE ATACAR O PIRATA
                    Oceano.gm.oceano = false;

                    // ESSA LINHA ATIVA TREMER TELA
                    StartCoroutine(Shake());
                }
            }
        }
        #endregion

        #region Indio
        // VERIFICA O INIMIGO SELECIONADO
        if (selectInimigos == SelectInimigos.Indio)
        {            
            // MATAR INDIO COM A ESPADA
            if (coll.CompareTag("PirataArmas"))
            {
                // ATIVA A ANIMAÇÃO MORRER
                if (InimigoCombate != InimigoCombate.IndioMorrer)
                {
                    InimigoCombate = InimigoCombate.IndioMorrer;
                    tracos.SetActive(false);

                    // ESSA LINHA FREZZA TODAS OS EIXOS 
                    rigi2d.constraints = RigidbodyConstraints2D.FreezeAll;
                }
            }
        }
        #endregion

        #region Urubu
        if (selectInimigos == SelectInimigos.Urubu_Fogo || 
            selectInimigos == SelectInimigos.Urubu_Barril ||
            selectInimigos == SelectInimigos.Urubu)
        {    
            if (coll.CompareTag("PirataArmas"))
            {
                if (InimigoCombate != InimigoCombate.UrubuMorrer)
                {
                    InimigoCombate = InimigoCombate.UrubuMorrer;
                }
            }

            if (coll.CompareTag("Pirata"))
            {
                if (InimigoCombate != InimigoCombate.UrubuMorrer)
                {
                    InimigoCombate = InimigoCombate.UrubuMorrer;
                    PirataControle.gm.JumpHead(this.jumpHead);
                }
            }
        }

        #endregion

        #region Abelhas
        if (selectInimigos == SelectInimigos.Abelha)
        {
            if (coll.CompareTag("PirataArmas"))
            {
                if (InimigoCombate != InimigoCombate.AbelhaMorrer)
                {
                    InimigoCombate = InimigoCombate.AbelhaMorrer;
                    mover = false;
                }
            }
        }
        #endregion

    }

    // LINHA DE COMANDO QUE BALANÇA A TELA QUANDO ATIVA O DISPARO DO CANHAO
    public IEnumerator Shake()
    {
        CameraShake.gm.Shake(0.2f, 0.4f);
        yield return new WaitForSeconds(1);
        CameraShake.gm.Shake(0, 0);
    }

    // LINHA DE COMANDO SETADA NO ANIMATION 
    public void OnDestroy()
    {
        // DESTROI O INIMIGO
        Destroy(gameObject);
    }

    // LINHA DE COMANDO SETADA NO ANIMATION 
    public void Moedas()
    {
        if(moedas != null)
        {
            moeClone = Instantiate(moedas, transformeMoedas.position, transformeMoedas.rotation) as GameObject;
        }
    }

}
