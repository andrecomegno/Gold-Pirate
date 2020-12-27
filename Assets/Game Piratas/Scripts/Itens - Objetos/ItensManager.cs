using UnityEngine;
using System.Collections;

public enum ItensList
{
    name, moeda, bonusTempo, moedaSeguir
}

public class ItensManager : MonoBehaviour
{
    public static ItensManager gm;
    public ItensList itensList;
    public Transform pirata;
    public Animator anima;
    public AudioSource audioSource;
    public CircleCollider2D circle2D;
    public Rigidbody2D rigi2d;

    // MOEDAS SEGUIR
    private float TubaNadar = 8f;
    private float TubaAtacar = 35f;

    // VARIAVEIS DO AUDIOS
    public AudioClip[] AudiosItens;

    void Start()
    {
        gm = this;
        audioSource = GetComponent<AudioSource>();
        anima = GetComponent<Animator>();
        rigi2d = GetComponent<Rigidbody2D>();
        circle2D = GetComponent<CircleCollider2D>();
        pirata = GameObject.FindWithTag("Pirata").transform;
    }

    void FixedUpdate()
    {
        if(itensList == ItensList.moedaSeguir)
        {
            transform.position = Vector2.MoveTowards(transform.position, pirata.position, 15 * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (itensList == ItensList.moeda || itensList == ItensList.moedaSeguir)
        {
            if (other.CompareTag("Pirata") || other.CompareTag("Papagaio"))
            {
                // ESSA LINHA ADICIONA +1 NAS MOEDAS DO JOGO
                Mundos.gm.Coins(+01);                
                Destroy(gameObject);
            }
        }

        if (itensList == ItensList.bonusTempo)
        {
            if (other.CompareTag("Pirata") || other.CompareTag("Papagaio"))
            {
                // ESSA LINHA QUE ADD +5 SEGUNDOS NO TEMPO DO JOGO
                Cronometro.gm.Seconds += 5;

                Relogio.gm._bonus = true;

                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
    }






}
