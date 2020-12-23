using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstrelasMundo_I : MonoBehaviour
{
    public static EstrelasMundo_I gm;

    void Awake()
    {
        gm = this;
    }

    // LINHA DE COMANDO DO MAPA 1 PARA MOSTRAR E SALVAR ESTRELAS 
    public void EstrelaMundoI()
    {
        // LINHA DE COMANDO QUE VERIFICA EM QUAL MAPA ESTA
        if (Mundos.gm.levelComplet == LevelComplet.Level_1)
        {
            // LINHA DE COMANDO QUE VERIFICA SE COLETOU TODAS AS MOEDAS DO MAPA
            if (Mundos.gm.coins == 10)
            {
                // LINHA DE COMANDO QUE VERIFICA SE O TEMPO ESTA IGUAL OU ABAIXO DE 21 SEGUNDOS
                if (Cronometro.gm.Seconds <= 5)
                {

                    // LINHA DE COMANDO QUE SALVA 2 ESTRELAS NO JOGO
                    PlayerPrefs.SetInt("Star_1_1", 2);

                    // LINHA DE COMANDO QUE MOSTRA AS 2 ESTRELAS
                    StartCoroutine(Estrelas.gm.StarDuasEstrelas());
                }

                // LINHA DE COMANDO QUE VERIFICA SE O TEMPO ESTA IGUAL OU ACIMA DE 22 SEGUNDOS
                if (Cronometro.gm.Seconds >= 6)
                {

                    // LINHA DE COMANDO QUE SALVA AS 3 ESTRELAS NO JOGO
                    PlayerPrefs.SetInt("Star_1_2", 3);

                    // LINHA DE COMANDO QUE MOSTRA AS 3 ESTRELAS
                    StartCoroutine(Estrelas.gm.StarTresEstrelas());
                }

                // LINHA DE COMANDO QUE APARECE O FUNDO DAS ENTRELAS 
                StartCoroutine(Estrelas.gm.FundoEstrelas());

                // LINHA DE COMANDO QUE MOSTRA O FUNDO DO MENU COMPLETO
                StartCoroutine(Estrelas.gm.FundoMenuCompleto());

            }

            // LINHA DE COMANDO QUE VERIFICA SE O TEMPO E MENOR OU IGUAL A 0, E TAMBEM VERIFCA SE O PIRATA MORREU
            if (Cronometro.gm.Seconds <= 0 || PirataControle.gm.morreu == true)
            {

                // LINHA DE COMANDO QUE SALVA 1 ESTRELA NO JOGO
                PlayerPrefs.SetInt("Star_1_0", 1);

                // LINHA DE COMANDO QUE MOSTRA 1 ESTRELA NO JOGO
                StartCoroutine(Estrelas.gm.StarUmEstrelas());

                // LINHA DE COMANDO QUE MOSTRA O FUNDO DA ESTRELA
                StartCoroutine(Estrelas.gm.FundoEstrelas());

                // LINHA DE COMANDO QUE MOSTRA O FUNDO DO MENU FRACASSADO
                StartCoroutine(Estrelas.gm.FundoMenuFracassado());
            }
        }

        if (Mundos.gm.levelComplet == LevelComplet.Level_2)
        {
            if (Mundos.gm.coins == 10)
            {
                if (Cronometro.gm.Seconds <= 15)
                {
                    PlayerPrefs.SetInt("Star_2_1", 2);
                    StartCoroutine(Estrelas.gm.StarDuasEstrelas());
                }

                if (Cronometro.gm.Seconds >= 16)
                {
                    PlayerPrefs.SetInt("Star_2_2", 3);
                    StartCoroutine(Estrelas.gm.StarTresEstrelas());
                }
                StartCoroutine(Estrelas.gm.FundoEstrelas());
                StartCoroutine(Estrelas.gm.FundoMenuCompleto());
            }

            if (Cronometro.gm.Seconds <= 0 || PirataControle.gm.morreu == true)
            {
                PlayerPrefs.SetInt("Star_2_0", 1);
                StartCoroutine(Estrelas.gm.StarUmEstrelas());
                StartCoroutine(Estrelas.gm.FundoEstrelas());
                StartCoroutine(Estrelas.gm.FundoMenuFracassado());
            }
        }

        if (Mundos.gm.levelComplet == LevelComplet.Level_3)
        {
            if (Mundos.gm.coins == 10)
            {
                if (Cronometro.gm.Seconds <= 9)
                {
                    PlayerPrefs.SetInt("Star_3_1", 2);
                    StartCoroutine(Estrelas.gm.StarDuasEstrelas());
                }

                if (Cronometro.gm.Seconds >= 10)
                {
                    PlayerPrefs.SetInt("Star_3_2", 3);
                    StartCoroutine(Estrelas.gm.StarTresEstrelas());
                }
                StartCoroutine(Estrelas.gm.FundoEstrelas());
                StartCoroutine(Estrelas.gm.FundoMenuCompleto());
            }

            if (Cronometro.gm.Seconds <= 0 || PirataControle.gm.morreu == true)
            {
                PlayerPrefs.SetInt("Star_3_0", 1);
                StartCoroutine(Estrelas.gm.StarUmEstrelas());
                StartCoroutine(Estrelas.gm.FundoEstrelas());
                StartCoroutine(Estrelas.gm.FundoMenuFracassado());
            }
        }

        if (Mundos.gm.levelComplet == LevelComplet.Level_4)
        {
            if (Mundos.gm.coins == 10)
            {
                if (Cronometro.gm.Seconds <= 29)
                {
                    PlayerPrefs.SetInt("Star_4_1", 2);
                    StartCoroutine(Estrelas.gm.StarDuasEstrelas());
                }

                if (Cronometro.gm.Seconds >= 30)
                {
                    PlayerPrefs.SetInt("Star_4_2", 3);
                    StartCoroutine(Estrelas.gm.StarTresEstrelas());
                }
                StartCoroutine(Estrelas.gm.FundoEstrelas());
                StartCoroutine(Estrelas.gm.FundoMenuCompleto());
            }

            if (Cronometro.gm.Seconds <= 0 || PirataControle.gm.morreu == true)
            {
                PlayerPrefs.SetInt("Star_4_0", 1);
                StartCoroutine(Estrelas.gm.StarUmEstrelas());
                StartCoroutine(Estrelas.gm.FundoEstrelas());
                StartCoroutine(Estrelas.gm.FundoMenuFracassado());
            }
        }

        if (Mundos.gm.levelComplet == LevelComplet.Level_5)
        {
            if (Mundos.gm.coins == 10)
            {
                if (Cronometro.gm.Seconds <= 13)
                {
                    PlayerPrefs.SetInt("Star_5_1", 2);
                    StartCoroutine(Estrelas.gm.StarDuasEstrelas());
                }

                if (Cronometro.gm.Seconds >= 14)
                {
                    PlayerPrefs.SetInt("Star_5_2", 3);
                    StartCoroutine(Estrelas.gm.StarTresEstrelas());
                }
                StartCoroutine(Estrelas.gm.FundoEstrelas());
                StartCoroutine(Estrelas.gm.FundoMenuCompleto());
            }

            if (Cronometro.gm.Seconds <= 0 || PirataControle.gm.morreu == true)
            {
                PlayerPrefs.SetInt("Star_5_0", 1);
                StartCoroutine(Estrelas.gm.StarUmEstrelas());
                StartCoroutine(Estrelas.gm.FundoEstrelas());
                StartCoroutine(Estrelas.gm.FundoMenuFracassado());
            }
        }

        if (Mundos.gm.levelComplet == LevelComplet.Level_6)
        {
            if (Mundos.gm.coins == 10)
            {
                if (Cronometro.gm.Seconds <= 20)
                {
                    PlayerPrefs.SetInt("Star_6_1", 2);
                    StartCoroutine(Estrelas.gm.StarDuasEstrelas());
                }

                if (Cronometro.gm.Seconds >= 21)
                {
                    PlayerPrefs.SetInt("Star_6_2", 3);
                    StartCoroutine(Estrelas.gm.StarTresEstrelas());
                }
                StartCoroutine(Estrelas.gm.FundoEstrelas());
                StartCoroutine(Estrelas.gm.FundoMenuCompleto());
            }

            if (Cronometro.gm.Seconds <= 0 || PirataControle.gm.morreu == true)
            {
                PlayerPrefs.SetInt("Star_6_0", 1);
                StartCoroutine(Estrelas.gm.StarUmEstrelas());
                StartCoroutine(Estrelas.gm.FundoEstrelas());
                StartCoroutine(Estrelas.gm.FundoMenuFracassado());
            }
        }

        if (Mundos.gm.levelComplet == LevelComplet.Level_7)
        {
            if (Mundos.gm.coins == 10)
            {
                if (Cronometro.gm.Seconds <= 20)
                {
                    PlayerPrefs.SetInt("Star_7_1", 2);
                    StartCoroutine(Estrelas.gm.StarDuasEstrelas());
                }

                if (Cronometro.gm.Seconds >= 21)
                {
                    PlayerPrefs.SetInt("Star_7_2", 3);
                    StartCoroutine(Estrelas.gm.StarTresEstrelas());
                }
                StartCoroutine(Estrelas.gm.FundoEstrelas());
                StartCoroutine(Estrelas.gm.FundoMenuCompleto());
            }

            if (Cronometro.gm.Seconds <= 0 || PirataControle.gm.morreu == true)
            {
                PlayerPrefs.SetInt("Star_7_0", 1);
                StartCoroutine(Estrelas.gm.StarUmEstrelas());
                StartCoroutine(Estrelas.gm.FundoEstrelas());
                StartCoroutine(Estrelas.gm.FundoMenuFracassado());
            }
        }

        if (Mundos.gm.levelComplet == LevelComplet.Level_8)
        {
            if (Mundos.gm.coins == 10)
            {
                if (Cronometro.gm.Seconds <= 10)
                {
                    PlayerPrefs.SetInt("Star_8_1", 2);
                    StartCoroutine(Estrelas.gm.StarDuasEstrelas());
                }

                if (Cronometro.gm.Seconds >= 11)
                {
                    PlayerPrefs.SetInt("Star_8_2", 3);
                    StartCoroutine(Estrelas.gm.StarTresEstrelas());
                }
                StartCoroutine(Estrelas.gm.FundoEstrelas());
                StartCoroutine(Estrelas.gm.FundoMenuCompleto());
            }

            if (Cronometro.gm.Seconds <= 0 || PirataControle.gm.morreu == true)
            {
                PlayerPrefs.SetInt("Star_8_0", 1);
                StartCoroutine(Estrelas.gm.StarUmEstrelas());
                StartCoroutine(Estrelas.gm.FundoEstrelas());
                StartCoroutine(Estrelas.gm.FundoMenuFracassado());
            }
        }

        if (Mundos.gm.levelComplet == LevelComplet.Level_9)
        {
            if (Mundos.gm.coins == 10)
            {
                if (Cronometro.gm.Seconds <= 10)
                {
                    PlayerPrefs.SetInt("Star_9_1", 2);
                    StartCoroutine(Estrelas.gm.StarDuasEstrelas());
                }

                if (Cronometro.gm.Seconds >= 11)
                {
                    PlayerPrefs.SetInt("Star_9_2", 3);
                    StartCoroutine(Estrelas.gm.StarTresEstrelas());
                }
                StartCoroutine(Estrelas.gm.FundoEstrelas());
                StartCoroutine(Estrelas.gm.FundoMenuCompleto());
            }

            if (Cronometro.gm.Seconds <= 0 || PirataControle.gm.morreu == true)
            {
                PlayerPrefs.SetInt("Star_9_0", 1);
                StartCoroutine(Estrelas.gm.StarUmEstrelas());
                StartCoroutine(Estrelas.gm.FundoEstrelas());
                StartCoroutine(Estrelas.gm.FundoMenuFracassado());
            }
        }

        if (Mundos.gm.levelComplet == LevelComplet.Level_10)
        {
            if (Mundos.gm.coins == 10)
            {
                if (Cronometro.gm.Seconds <= 10)
                {
                    PlayerPrefs.SetInt("Star_10_1", 2);
                    StartCoroutine(Estrelas.gm.StarDuasEstrelas());
                }

                if (Cronometro.gm.Seconds >= 11)
                {
                    PlayerPrefs.SetInt("Star_10_2", 3);
                    StartCoroutine(Estrelas.gm.StarTresEstrelas());
                }
                StartCoroutine(Estrelas.gm.FundoEstrelas());
                StartCoroutine(Estrelas.gm.FundoMenuCompleto());
            }

            if (Cronometro.gm.Seconds <= 0 || PirataControle.gm.morreu == true)
            {
                PlayerPrefs.SetInt("Star_10_0", 1);
                StartCoroutine(Estrelas.gm.StarUmEstrelas());
                StartCoroutine(Estrelas.gm.FundoEstrelas());
                StartCoroutine(Estrelas.gm.FundoMenuFracassado());
            }
        }
    }
}
