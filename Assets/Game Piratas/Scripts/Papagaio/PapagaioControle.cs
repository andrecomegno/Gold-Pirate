using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapagaioControle : MonoBehaviour
{
    public static PapagaioControle gm;

    private Animator anima;
    private Rigidbody2D rigi2d;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider2D;
    private float speed = 15f;
    public float voar = 500f;

    public bool solo;
    public LayerMask layerMask;
    public Vector2 vetor2 = Vector2.zero;
    public float collisionRadius = 0.53f;
    public Color debugCollision = Color.red;

    // Variaveis do touch screem
    private float direction;
    public bool move;
    private float touchHorizontal;

    // VARIAVEIS DA TRANSFORMAÇOES
    private GameObject PirataClone;
    private GameObject pira;
    private Transform mytransform;

    // Start is called before the first frame update
    void Start()
    {
        rigi2d = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();

        gm = this;
    }

    // LINHA DE COMANDO CENTRAL PARA TODOS OS SCRIPTS 
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (move)
        {
            this.touchHorizontal = Mathf.Lerp(touchHorizontal, direction, Time.deltaTime * 5);
            PapagaioMoviment(touchHorizontal);
            Flip(direction);
            LayersControll();
            ColliderJump();
        }
        else
        {
            PapagaioMoviment(horizontal);
            Flip(horizontal);
            LayersControll();
            OnJump();
            ColliderJump();
        }
    }

    void PapagaioMoviment(float horizonte)
    {
        rigi2d.velocity = new Vector2(horizonte * speed, rigi2d.velocity.y);
        anima.SetFloat("Andar", Mathf.Abs(horizonte));
    }

    // LINHA DE COMANDO QUE FAZ O GIRAR DO PERSONAGEM DA ESQUERDA PARA DIREITA QUANDO PRECINA O BOTAO
    private void Flip(float horizonte)
    {
        if (horizonte > 0)
        {
            spriteRenderer.flipX = false;

            vetor2 = new Vector2(-0.33f, -1.12f);
            circleCollider2D.offset = new Vector2(-0.29f, -0.42f);
        }

        if (horizonte < 0)
        {
            spriteRenderer.flipX = true;

            vetor2 = new Vector2(0.26f, -1.12f);
            circleCollider2D.offset = new Vector2(0.25f, -0.42f);
        }
    }

    public void Voar()
    {
        if (rigi2d.velocity.y <= 0)
        {
            rigi2d.AddForce(new Vector2(0, voar));
            anima.SetTrigger("Voar");
        }
    }

    // LINHA DE COMANDO USADA PARA ATIVAR O PULAR NO PC
    private void OnJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Voar();
        }
    }

    // LINHA DE COMANDO PARA ATIVAR O CAIR DO PERSONAGEM JUNTO COM ANIMAÇAO, E VERIFICA QUANDO EM COSTAR NO CHAO
    public void Caindo()
    {
        if (!solo && rigi2d.velocity.y <= 0)
        {
            anima.ResetTrigger("Voar");
        }
    }

    #region TRANSFORMACOES DOS TOTENS

    // LINHA DE COMANDO QUE ESTA VINCULADA NO SCRIPT TOUCHUI.CS
    public void TransformacaoPirata()
    {
        anima.SetBool("TransformarPirata", true);
    }

    // LINHA DE COMANDO QUE ESTA NO ADD EVENT PARA DAR O RESOUCES DO PAPAGAIO E DELERANDO O PIRATA DO JOGO
    public void ResourcesLoad()
    {
        mytransform = GameObject.Find("respown").transform;
        PirataClone = Instantiate(Resources.Load("Personagens/Piratas/Pirata_Espada", typeof(GameObject))) as GameObject;
        PirataClone.transform.position = mytransform.position;
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
        solo = Physics2D.OverlapCircle(pos, collisionRadius, layerMask);
        Caindo();
    }

    // LINHA DE COMANDO QUE CRIA O COLLIDER INVISIVEL PARA A VERIFICAÇAO DO PULO E O CHAO
    void OnDrawGizmos()
    {
        Gizmos.color = debugCollision;
        var pos = vetor2;
        pos.x += transform.position.x;
        pos.y += transform.position.y;
        Gizmos.DrawWireSphere(pos, collisionRadius);
    }

    // LINHA DE COMANDO PARA ALTERAR AS LAYERS DA ANIMAÇAO. LAYER 1 ANDAR E CORRER LAYER 2 PULAR CAIR E VOAR 
    void LayersControll()
    {
        if (!solo)
        {
            anima.SetLayerWeight(1, 1);
        }
        else
        {
            anima.SetLayerWeight(1, 0);
        }
    }

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
    public void TouchVoar()
    {
        this.Voar();
    }
}
