using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class PirataControle : MonoBehaviour {
    public static PirataControle gm;

    private Animator anima;
    private Rigidbody2D rigi2d;
    private BoxCollider2D boxColider2d;
    private CircleCollider2D circColider2d;
    private float speed = 15f;
    public float jump = 500f;
    private float nadar = 200f;
    public bool facingRight;
    public LayerMask layerMask;
    public Vector2 vetor2 = Vector2.zero;
    public float collisionRadius = 0.53f;
    public bool solo;
    public Color debugCollision = Color.red;

    // VARIAVEIS MORRER
    public bool morreu;

    // variavel voar/canhao
    private float voando = 50f;
    private Waypoints wpoints;
    private int waypointIndex;
    public bool voar;
    public bool flip;

    // variavel armas
    public bool espada = false;

    // Variaveis do touch screem
    private float direction;
    public bool move;
    private float touchHorizontal;

    // // VARIAVEIS DA TRANSFORMAÇOES
    private GameObject PapagaioClone;
    private GameObject papa;
    private Transform mytransform;

    void Awake()
    {
        gm = this;
    }

    void Start()
    {
        rigi2d = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        boxColider2d = GetComponent<BoxCollider2D>();
        circColider2d = GetComponent<CircleCollider2D>();
        rigi2d.gravityScale = 1.3f;

        wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }

    void Update()
    {
        MissoesLogic();
    }

    // LINHA DE COMANDO CENTRAL PARA TODOS OS SCRIPTS 
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (move)
        {
            this.touchHorizontal = Mathf.Lerp(touchHorizontal, direction, Time.deltaTime * 5);
            PirateMoviment(touchHorizontal);
            Flip(direction);
            LayersControll();
            ColliderJump();
        }
        else
        {
            PirateMoviment(horizontal);
            Flip(horizontal);
            LayersControll();
            OnJump();
            ColliderJump();
            Nadar();
            Voar();
        }
    }

    // LINHA DE COMANDO QUE MOVIMENTO O PERSONAGEM E ATIVA A SUA ANIMAÇAO CORRER, TAMBEM VERIFICA SE O PERSOGEM ESTA NO AR "VOARNDO"
    private void PirateMoviment(float horizonte)
    {
        if (espada != false)
        {
            rigi2d.velocity = new Vector2(horizonte * speed, rigi2d.velocity.y);
            anima.SetFloat("Correr_Espada", Mathf.Abs(horizonte));
            anima.SetBool("Espada", true);
        }

    }

    // LINHA DE COMANDO QUE FAZ O GIRAR DO PERSONAGEM DA ESQUERDA PARA DIREITA QUANDO PRECINA O BOTAO
    private void Flip(float horizonte)
    {
        if (!flip)
        {
            if (horizonte > 0 && !facingRight || horizonte < 0 && facingRight)
            {
                facingRight = !facingRight;

                Vector2 thescale = transform.localScale;

                thescale.x *= -1;
                transform.localScale = thescale;
            }
        }
    }

    // LINHA DE COMANDO PARA O PULO E ANIMAÇAO EM SEGUIDA
    private void Jump()
    {
        if (solo && rigi2d.velocity.y <= 0 && espada)
        {
            rigi2d.AddForce(new Vector2(0, jump));
            anima.SetTrigger("Pular_Espada");
        }

        if (rigi2d.velocity.y <= 0 && Oceano.gm.oceano == true)
        {
            rigi2d.AddForce(new Vector2(0, nadar));
        }
    }

    // LINHA DE COMANDO QUE ATIVA MATAR OS INIMIGOS, PULANDO NA CABEÇA
    public void JumpHead(float jumpHead)
    {
        rigi2d.velocity = new Vector2(0, jumpHead * Time.deltaTime);
        //Debug.Log("JumpHead");
    }

    //LINHA DE COMANDO QUE VERIFICA SE O PERSONAGEM ESTA NO CHAO E TBM DENTRO DO OCEANO, ATIVANDO ASSIM A ANIMAÇAO NADAR
    public void Nadar()
    {
        if (rigi2d.velocity.y <= 0 && Oceano.gm.oceano == true)
        {
            anima.SetBool("Nadar", true);
        }

        if (Oceano.gm.oceano == false)
        {
            anima.SetBool("Nadar", false);
        }
    }

    // LINHA DE COMANDO USADA PARA ATIVAR O PULAR NO PC
    private void OnJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    // LINHA DE COMANDO PARA ATIVAR O CAIR DO PERSONAGEM JUNTO COM ANIMAÇAO, E VERIFICA QUANDO EM COSTAR NO CHAO
    public void Fall() {
        if (espada)
        {
            if (!solo && rigi2d.velocity.y <= 0 && voar == false)
            {
                anima.SetBool("Cair_Espada", true);
                anima.ResetTrigger("Pular_Espada");
            }

            if (solo)
            {
                anima.SetBool("Cair_Espada", false);
            }
        }
    }

    // LINHA DE COMANDO QUE ATIVA E VERIFICA A VARIAVEL AVOAR
    void Voar()
    {
        if (solo && voar || solo && voar && Oceano.gm.oceano == true || voar && Oceano.gm.oceano == true)
        {
            anima.SetBool("Voando", false);
            voar = false;
            facingRight = false;
        }

        // A VARIAVEL TEM QUE SER VOAR == TRUE PARA A VERIFICAÇÃO DENTRO DO SCRYPT PIRATACANHAO.CS
        if (voar == true && !solo)
        {
            anima.SetBool("Voando", true);

            voar = true;

            // LINHA DE COMANDO QUE DESABILITA O MENU TOUCH, QUANDO ESTIVER VOANDO 
            // MenuInGame.gm.TouchScreen.SetActive(false); ESSA LINHA ESTA NO SCRIPT PIRATACANHAO.CS

            transform.position = Vector2.MoveTowards(transform.position, wpoints.waypoints[waypointIndex].position, voando * Time.deltaTime);

            if (Vector2.Distance(transform.position, wpoints.waypoints[waypointIndex].position) < 0.1f)
            {
                if (waypointIndex < wpoints.waypoints.Length - 1)
                {
                    waypointIndex++;
					
                }
                else
                {
                    voar = false;

                    // // LINHA DE COMANDO QUE HABILITA O MENU TOUCH, QUANDO ESTIVER VOANDO
                    MenuInGame.gm.TouchScreen.SetActive(true);
                    anima.SetBool("Voando", false);
                    rigi2d.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
            }
        }
    }

    // LINHA DE COMANDO DAS ANIMAÇOES DE MORRER, ESTA SENDO USADA NO SCRIPT ITENSMANAGER
    #region Pirata Morrendo
    public void MorrerFantasma()
    {
        if (!solo)
        {
            // LINHA DE COMANDO QUE RESOLVE UM BUG DO PIRATA FICAR ATACANDO SEM PARA DEPOIS MORRER
            anima.SetBool("EspadaAtacarParado", false);

            // LINHA DE COMANDO QUE VERIFICA SE O PIRATA MORREU PARA HABILITAR O MENU MISSAO FRACASSADA
            morreu = true;

            //RESETA O PULO
            jump = 0;

            // ZERA A GRAVIDADE
            rigi2d.gravityScale = 0;

            // LINHA DE COMANDO QUE FAZ COM QUE O FANTASMA VOE PARA CIMA
            rigi2d.velocity = new Vector2(0, 280 * Time.deltaTime);

            anima.SetBool("MorrerFantasma", true);
            StartCoroutine(DesabilitarMovimentos());
            MenuInGame.gm.FracassouMissao();
        }
    }

    public void MorrerSemCabeca()
    {
        if (solo)
        {
            // LINHA DE COMANDO QUE RESOLVE UM BUG DO PIRATA FICAR ATACANDO SEM PARA DEPOIS MORRER
            anima.SetBool("EspadaAtacarParado", false);

            // LINHA DE COMANDO QUE VERIFICA SE O PIRATA MORREU PARA HABILITAR O MENU MISSAO FRACASSADA
            morreu = true;

            // VARIAVEL NECESSARIA PARA DESABILITAR A MOVIMENTAÇAO DO PIRATA E ASSIM EXCUTAR A ANIMAÇAO 
            move = false;

            anima.SetBool("MorrerSemCabeca", true);
            MenuInGame.gm.FracassouMissao();
        }
    }

    public void MorrerQueimado()
    {
        if (solo)
        {
            // LINHA DE COMANDO QUE RESOLVE UM BUG DO PIRATA FICAR ATACANDO SEM PARA DEPOIS MORRER
            anima.SetBool("EspadaAtacarParado", false);

            // LINHA DE COMANDO QUE VERIFICA SE O PIRATA MORREU PARA HABILITAR O MENU MISSAO FRACASSADA
            morreu = true;

            // VARIAVEL NECESSARIA PARA DESABILITAR A MOVIMENTAÇAO DO PIRATA E ASSIM EXCUTAR A ANIMAÇAO 
            move = false;

            anima.SetBool("MorrerQueimado", true);
            MenuInGame.gm.FracassouMissao();
        }
    }

    public void MorrerEsmagado()
    {
        if (solo)
        {
            // LINHA DE COMANDO QUE RESOLVE UM BUG DO PIRATA FICAR ATACANDO SEM PARA DEPOIS MORRER
            anima.SetBool("EspadaAtacarParado", false);

            // LINHA DE COMANDO QUE VERIFICA SE O PIRATA MORREU PARA HABILITAR O MENU MISSAO FRACASSADA
            morreu = true;

            // VARIAVEL NECESSARIA PARA DESABILITAR A MOVIMENTAÇAO DO PIRATA E ASSIM EXCUTAR A ANIMAÇAO 
            move = false;

            anima.SetBool("MorrerEsmagadoParado", true);

            // LINHA QUE DESABILITA O BOXCOLIDER PARA DEIXAR SOMENTE O CIRCULO COLLIDER
            boxColider2d.enabled = false;
            circColider2d.enabled = true;

            MenuInGame.gm.FracassouMissao();
        }

        if (!solo)
        {
            // LINHA DE COMANDO QUE RESOLVE UM BUG DO PIRATA FICAR ATACANDO SEM PARA DEPOIS MORRER
            anima.SetBool("EspadaAtacarParado", false);

            // LINHA DE COMANDO QUE VERIFICA SE O PIRATA MORREU PARA HABILITAR O MENU MISSAO FRACASSADA
            morreu = true;

            //RESETA O PULO
            jump = 0;

            // ZERA A GRAVIDADE
            rigi2d.gravityScale = 0f;

            // LINHA DE COMANDO QUE FAZ ELE CAIR LENTAMENTE NO SOLO
            rigi2d.velocity = new Vector2(0, -170 * Time.deltaTime);

            move = false; // VARIAVEL NECESSARIA PARA DESABILITAR A MOVIMENTAÇAO DO PIRATA E ASSIM EXCUTAR A ANIMAÇAO 
            anima.SetBool("MorrerEsmagadoPulando", true);

            // LINHA QUE DESABILITA O BOXCOLIDER PARA DEIXAR SOMENTE O CIRCULO COLLIDER
            boxColider2d.enabled = false;
            circColider2d.enabled = true;

            // LINHA QUE DESABILITA O ISTRIGGER PARA NAO DEIXA A ANIMAÇAO FLUIR NATURAR 
            circColider2d.isTrigger = true;

            // LINHA DE COMANDO QUE FREZZA TODOS OS EIXOS 
            StartCoroutine(DesabilitarMovimentos());

            MenuInGame.gm.FracassouMissao();
        }
    }

    #endregion

    #region TOUCH SCREEN CONTROLE GAME TOUCHUI.CS

    // LINHA DE COMANDO TOUCH QUE FAZ A MOVIMENTAÇAO DO PERSONAGEM
    public void TouchMove(float direct)
    {
        this.direction = direct;
        this.move = true;
    }

    // LINHA DE COMANDO TOUCH QUE PARA A MOVIMENTAÇAO DO PERSONAGEM
    public void TouchStopMove()
    {
        this.direction = 0;
        this.touchHorizontal = 0;
        this.move = false;
    }

    // LINHA DE COMANDO TOUCH QUE FAZ O PERSONAGEM PULAR
    public void TouchJump()
    {
        this.Jump();
    }

    // LINHA DE COMANDO PIRATA ATACAR COM ESPADA POINTER DOWN
    public void TouchEspadaAtacar()
    {
        // LINHA DE COMANDO QUE VERIFICA SE A ESPADA ESTA NA MAO DO PIRATA
        if (espada)
        {
            // LINHA DE COMOANDO VERIFICA SE O PIRATA ESTA NO CHAO
            if (solo)
            {
                anima.SetBool("EspadaAtacarParado", true);
            }
        }
    }

    //LINHA DE COMANDO QUE PARA A ANIMACAO ATACAR, CRIADO NO POINTER UP
    public void TouchEspadaStop()
    {
        anima.SetBool("EspadaAtacarParado", false);
    }
    #endregion

    #region TRANSFORMACOES DOS TOTENS
    // LINHA DE COMANDO TRANSFORMACAO DO PAPAGAIO
    public void TransformacaoPapagaio()
    {
        anima.SetBool("TransformarPapagaio", true);
    }

    // LINHA DE COMANDO QUE ESTA NO ADD EVENT PARA DAR O RESOUCES DO PAPAGAIO E DELETANDO O PIRATA DO JOGO
    public void ResourcesLoad()
    {
        mytransform = GameObject.Find("respown").transform;
        PapagaioClone = Instantiate(Resources.Load("Personagens/Papagaios/Papagaio", typeof(GameObject))) as GameObject;
        PapagaioClone.transform.position = mytransform.position;
    }

    // LINHA DE COMANDO QUE ESTA NO ADD EVENT, QUE DESTROI O PIRATA 
    public void OnDestroy()
    {
        Destroy(gameObject);
    }
    #endregion

    // LINHA DE COMANDO QUE VERIFICA O COLIDIR DO PULO 
    private void ColliderJump()
    {
		var pos = vetor2;
		pos.x += transform.position.x;
		pos.y += transform.position.y;
		solo = Physics2D.OverlapCircle (pos, collisionRadius, layerMask);
		Fall ();
	}

    // LINHA DE COMANDO QUE CRIA O COLLIDER INVISIVEL PARA A VERIFICAÇAO DO PULO E O CHAO
	void OnDrawGizmos()
    {
		Gizmos.color = debugCollision;
		var pos = vetor2;
		pos.x += transform.position.x;
		pos.y += transform.position.y;
		Gizmos.DrawWireSphere (pos, collisionRadius);
	}

    // LINHA DE COMANDO PARA ALTERAR AS LAYERS DA ANIMAÇAO. LAYER 1 ANDAR E CORRER LAYER 2 PULAR CAIR E VOAR 
	void LayersControll()
    {
		if (!solo) {
			anima.SetLayerWeight (1, 1);
		} else {
			anima.SetLayerWeight (1, 0);
		}
    }

    // LINHA DE COMANDO ESTA SENDO USADA PARA DESABILITAR OS MOVIMENTOS DO PIRATA
    IEnumerator DesabilitarMovimentos()
    {
        yield return new WaitForSeconds(2);
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // LINHA DE COMANDO DA VERIFICAÇAO DAS MISSOES DO JOGO 
    void MissoesLogic()
    {
        // LINHA DE COMANDO QUE VERIFICA SE FOI COMPLETO A MISSAO DA FASE
        if(MenuInGame.gm.completou == true)
        {
            // LINHA DE COMENDO QUE DESABILITA A ANIMAÇAO, SCRIPT PIRATACONTROLE E O RIGIDBODY2D
            this.GetComponent<Animator>().enabled = false;
            this.GetComponent<PirataControle>().enabled = false;
            this.GetComponent<Rigidbody2D>().simulated = false;
        }

        // LINHA DE COMANDO QUE VERIFICA SE FOI FRACASSADA A MISSAO DA FASE
        if (MenuInGame.gm.fracassou == true)
        {
            // LINHA DE COMANDO QUE RESOLVE UM BUG DO PIRATA FICAR ATACANDO SEM PARA DEPOIS MORRER
            anima.SetBool("EspadaAtacarParado", false);
        }
    }

}
