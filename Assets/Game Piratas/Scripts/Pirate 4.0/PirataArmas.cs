using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SelecionarArmas
{
    nome, espada
}

public class PirataArmas : MonoBehaviour
{
    public static PirataArmas gm;
    public SelecionarArmas selecionarArmas = SelecionarArmas.nome;
 //   private Animator anima;

    void Start()
    {
        gm = this;
 //       anima = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
    }
}
