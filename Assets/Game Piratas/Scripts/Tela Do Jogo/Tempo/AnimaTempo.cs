using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SelecionarTempo
{
    nome, acabou, ponteiro
}

public class AnimaTempo : MonoBehaviour
{
    public static AnimaTempo gm;
    public SelecionarTempo SelecionarTempo;
    private Animator anima;

    public bool _relogio = false;
    public bool _ponteiro = false;

    void Start()
    {
        gm = this;
        anima = GetComponent<Animator>();
    }

    void Update()
    {
        TempoAcabou();
    }

    void TempoAcabou()
    {
        if(SelecionarTempo == SelecionarTempo.acabou)
        {
            if (Cronometro.gm.Minutes <= 0 && Cronometro.gm.Seconds <= 0)
            {
                anima.SetBool("TempoAcabou", true);
            }
        }
    }

    #region ESTA VINCULADA NA ANIMAÇAO DO SCPRIT ADD EVENT
    public void TempoPonteiro()
    {
        // LINHA DE COMANDO QUE PARA A ANIMAÇAO DO PONTEIRO QUANDO O CRONOMETRO ZERAR OU ATIVA O MENU FRACASSOU OU COMPLETOU
        if (SelecionarTempo == SelecionarTempo.ponteiro)
        {
            if (Cronometro.gm.Minutes <= 0 && Cronometro.gm.Seconds <= 0)
            {
                anima.enabled = false;
            }

            if(MenuInGame.gm.fracassou == true || MenuInGame.gm.completou == true)
            {
                anima.enabled = false;
            }
        }
    }
    #endregion
}
