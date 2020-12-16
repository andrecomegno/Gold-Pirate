using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TouchUI : MonoBehaviour
{
    public static TouchUI gm;

    void Awake()
    {
        gm = this;
    }

    #region PIRATA
    // LINHA DE COMANDO TOUCH QUE FAZ A MOVIMENTAÇAO DO PIRATA
    public void MovePirata(float move)
    {
        PirataControle.gm.TouchMove(move);
    }

    // LINHA DE COMANDO TOUCH QUE PARA A MOVIMENTAÇAO DO PERSONAGEM
    public void PararPirata()
    {
        PirataControle.gm.TouchStopMove();
    }

    // LINHA DE COMANDO TOUCH QUE FAZ O PERSONAGEM PULAR
    public void PularPirata()
    {
        PirataControle.gm.TouchJump();
    }

    // LINHA DE COMANDO TOUCH DO ATACAR COM ESPADA
    public void PirataEspadaParado()
    {
        PirataControle.gm.TouchEspadaAtacar();
    }

    // LINHA DE COMANDO TOUCH QUE PARA ANIMACAO DA ESPADA
    public void PirataEspadaStop()
    {
        PirataControle.gm.TouchEspadaStop();
    }

    #endregion

    #region PAPAGAIOS
    // LINHA DE COMANDO TOUCH QUE FAZ A MOVIMENTAÇAO DO PAPAGAIO
    public void MovePapagaio(float move)
    {
        PapagaioControle.gm.TouchMove(move);
    }

    // LINHA DE COMANDO TOUCH QUE PARA A MOVIMENTAÇAO DO PERSONAGEM
    public void PararPapagaio()
    {
        PapagaioControle.gm.TouchStopMove();
    }

    // LINHA DE COMANDO TOUCH QUE FAZ O PERSONAGEM PULAR
    public void VoarPapagaio()
    {
        PapagaioControle.gm.TouchVoar();
    }
    #endregion
}
