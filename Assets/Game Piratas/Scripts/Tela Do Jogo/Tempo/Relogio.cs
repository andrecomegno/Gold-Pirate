using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public enum SelecionarRelogio
{
    nome, tempo, bonus, congelado, relogio, ponteiro
}

public class Relogio : MonoBehaviour
{
    public static Relogio gm;
    public SelecionarRelogio selecionarRelogio;

    // VARIAVEIS DA ANIMACÃO TEMPO
    public bool _tempo = false;
    public bool _bonus = false;
    public bool _congelado = false;

    public GameObject Tempo;
    public GameObject Bonus;
    public GameObject Congelado;

    void Start()
    {
        gm = this;

        // LINHA DE COMANDO QUE ATIVA E DESATIVA OS SPRITES
        if (selecionarRelogio == SelecionarRelogio.tempo || selecionarRelogio == SelecionarRelogio.bonus || selecionarRelogio == SelecionarRelogio.congelado)
        {
            Tempo.SetActive(true);
            Bonus.SetActive(false);
            Congelado.SetActive(false);
        }
    }

    void Update()
    {
        SwicthTempo();
    }

    void SwicthTempo()
    {
        switch (selecionarRelogio)
        {
            case SelecionarRelogio.tempo:
                TempoNormal();
                break;

            case SelecionarRelogio.bonus:
                TempoBonus();
                break;

            case SelecionarRelogio.congelado:
                TempoCongelado();
                break;
        }

        SpritesLogic();
    }

    #region TEMPO SPRITES
    void SpritesLogic()
    {
        if (_tempo == true)
        {
            if (selecionarRelogio != SelecionarRelogio.tempo)
            {
                selecionarRelogio = SelecionarRelogio.tempo;
            }
        }

        if (_bonus == true)
        {
            if (selecionarRelogio != SelecionarRelogio.bonus)
            {
                selecionarRelogio = SelecionarRelogio.bonus;
            }
        }

        if (_congelado == true)
        {
            if (selecionarRelogio != SelecionarRelogio.congelado)
            {
                selecionarRelogio = SelecionarRelogio.congelado;
            }
        }
    }

    void TempoNormal()
    {
        if (selecionarRelogio == SelecionarRelogio.tempo)
        {
            Tempo.SetActive(true);
            Bonus.SetActive(false);
            Congelado.SetActive(false);
        }
    }

    void TempoBonus()
    {
        if (selecionarRelogio == SelecionarRelogio.bonus)
        {
            StartCoroutine(SpritesTempo(Bonus, Tempo, Congelado, 0.8f));
            StartCoroutine(TempoOn());
        }
    }

    void TempoCongelado()
    {
        if (selecionarRelogio == SelecionarRelogio.congelado)
        {
            StartCoroutine(SpritesTempo(Congelado, Tempo, Bonus, 0.8f));
            StartCoroutine(TempoOn());
        }
    }

    IEnumerator SpritesTempo(GameObject liga, GameObject des1, GameObject des2, float tempo)
    {
        // LINHA DE COMANDO QUE ATIVA E DESATIVA OS SPRITES
        liga.SetActive(true);
        des1.SetActive(false);
        des2.SetActive(false);
        yield return new WaitForSeconds(tempo);
        liga.SetActive(false);
        des1.SetActive(true);
    }

    IEnumerator TempoOn()
    {
        // VARIAIES SAO UTILIZADAS PARA RESETAR OS SPRITES.
        _bonus = false;
        _congelado = false;
        yield return new WaitForSeconds(0.4f);
        _tempo = true;
        yield return new WaitForSeconds(0.4f);
        _tempo = false;
    }
    #endregion
}
