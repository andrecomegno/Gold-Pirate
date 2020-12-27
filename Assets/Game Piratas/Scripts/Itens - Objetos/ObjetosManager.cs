using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SelecionarObjetos
{
    nome, barril, boladocanhao, barrilExplosivo, bau, totemPapagaio, totemPirata
}

public class ObjetosManager : MonoBehaviour {

    public static ObjetosManager gm;
    public SelecionarObjetos selecionarObjetos;
    private Animator anima;
    public AudioSource audioSource;
    public CircleCollider2D circle2D;
    public Rigidbody2D rigi2d;

    public bool dentro = false;

    // VARIAVEIS DO TOTEM
    public bool totem = false;
    public GameObject TouchPirata;
    public GameObject TouchPapagaio;

    // variavel barril
    public bool explosaoBarril = false;

    // VARIAVEIS DO AUDIOS
    public AudioClip[] AudiosObjetos;
    public AudioClip Faisca;

    void Start()
    {
        gm = this;
        audioSource = GetComponent<AudioSource>();
        anima = GetComponent<Animator>();
        rigi2d = GetComponent<Rigidbody2D>();
        circle2D = GetComponent<CircleCollider2D>();        
    }

    void Update()
    {
    }

    #region ESTA VINCULADA NA ANIMAÇAO DO SCPRIT ADD EVENT
    // LINHA DE COMANDO DO BARRIL
    public void BarrilExplosivoAudio()
    {
        // ESSA LINHA VERIFICA SE O BARRIL E VERDADEIRA PARA EXPLOSAO
        if (explosaoBarril == true)
        {
            // ESSA LINHA ATIVA A ANIMAÇAO DO MORRER FANTASMA
            PirataControle.gm.MorrerFantasma();

            // ESSA LINHA ATIVA A ANIMAÇAO DO MORRER QUEIMADO
            PirataControle.gm.MorrerQueimado();
        }


        // ESSA LINHA E DA EXPLOSAO DO BARRIL 
        audioSource.clip = AudiosObjetos[Random.Range(0, AudiosObjetos.Length)];
        audioSource.Play();

        // ESSA LINHA QUE TREME A CAMERA
        CameraShake.gm.Shake(0.2f, 0.4f);
    }

    // LINHA DE COMANDO DO AUDIO DA FAISCA DO CANHO E BARRILS
    void SomFaisca()
    {
        audioSource.PlayOneShot(Faisca);
    }

    // LINHA DE COMANDO PARA GERAR O BOLA DO CANAHAO NO EVENTO DA ANIMAÇÂO
    public void Destruir()
    {
        if (selecionarObjetos == SelecionarObjetos.barrilExplosivo)
        {
            Destroy(gameObject, 0.2f);
        }

        // ESSA LINHA DESTROI A BOLA DO CANHAO QUANDO TOCADA NO SOLO
        if (selecionarObjetos == SelecionarObjetos.boladocanhao)
        {
            Destroy(gameObject, 0.8f);
        }
    }
    #endregion


    void OnTriggerEnter2D(Collider2D other)
    {

        if (selecionarObjetos == SelecionarObjetos.totemPapagaio)
        {
            if (other.CompareTag("Pirata"))
            {
                CameraSeguir.gm.minhacamera = CameraSeguir.SelecionarCamera.papagaioTransfo;

                totem = true;
                PirataControle.gm.TransformacaoPapagaio();
                PirataControle.gm.TouchStopMove();
                

                TouchPapagaio.SetActive(true);
                TouchPirata.SetActive(false);

                //Debug.Log("Entrou");
            }
        }

        if (selecionarObjetos == SelecionarObjetos.totemPirata)
        {
            if (other.CompareTag("Papagaio"))
            {
                CameraSeguir.gm.minhacamera = CameraSeguir.SelecionarCamera.pirataTransfo;

                totem = false;
                PapagaioControle.gm.TransformacaoPirata();
                PapagaioControle.gm.TouchStopMove();                

                TouchPirata.SetActive(true);
                TouchPapagaio.SetActive(false);

               // Debug.Log("Entrou");
            }
        }


        if (selecionarObjetos == SelecionarObjetos.boladocanhao)
        {
            if (other.CompareTag("Pirata"))
            {
                //InimigoControle.gm.canhaoAtirar = false;

                PirataControle.gm.MorrerEsmagado();
            }

            if (other.CompareTag("Solo"))
            {
                anima.SetBool("BombaExplosao", true);
                circle2D.enabled = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (selecionarObjetos == SelecionarObjetos.barrilExplosivo)
        {
            if (other.CompareTag("Pirata"))
            {
                anima.SetBool("Explosao", true);
                explosaoBarril = true;
            }
        }

        if (selecionarObjetos == SelecionarObjetos.barril)
        {
            if (other.CompareTag("PirataArmas"))
            {
                anima.SetBool("Quebrado", true);
            }
        }

        if(selecionarObjetos == SelecionarObjetos.bau)
        {
            if (other.CompareTag("PirataArmas"))
            {
                anima.SetBool("BauAbrir", true);

            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        explosaoBarril = false;
        if (selecionarObjetos == SelecionarObjetos.boladocanhao)
        {
            dentro = false;
        }
    }


}
