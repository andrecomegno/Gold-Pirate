using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Estrelas : MonoBehaviour {
	public static Estrelas gm;
	public GameObject umaestrela;
	public GameObject duasestrela;
	public GameObject tresestrela;
	public GameObject fundo1;
	public GameObject fundo2;
	public GameObject fundo3;

    public GameObject FundoMF;
    public GameObject FundoMC;

	void Awake(){
        gm = this;
		umaestrela = GameObject.Find ("Estrelas/Estrela/um");
		duasestrela = GameObject.Find ("Estrelas/Estrela/dois");
		tresestrela = GameObject.Find ("Estrelas/Estrela/tres");
		fundo1 = GameObject.Find ("Estrelas/Estrela/Fundo1");
		fundo2 = GameObject.Find ("Estrelas/Estrela/Fundo2");
		fundo3 = GameObject.Find ("Estrelas/Estrela/Fundo3");

        FundoMC = GameObject.Find("Estrelas/FundoMC");
        FundoMF = GameObject.Find("Estrelas/FundoMF");
    }

	// Use this for initialization
	void Start () {
		umaestrela.SetActive (false);
		duasestrela.SetActive (false);
		tresestrela.SetActive (false);
		fundo1.SetActive (false);
		fundo2.SetActive (false);
		fundo3.SetActive (false);

        FundoMC.SetActive (false);
        FundoMF.SetActive (false);
	}

	void Update(){
		//LINHA DE COMANDO QUE RESET O SALVE
		if (Input.GetKeyDown (KeyCode.F1)) {
			PlayerPrefs.DeleteAll ();
			Debug.Log("RESET SALVE");
		}

		EstrelasDoMundoUm ();
		EstrelaDoMundoDois ();
	}

	// LINHA DE COMANDO DO MAPA 1 PARA MOSTRAR E SALVAR ESTRELAS 
	void EstrelasDoMundoUm(){
        // LINHA DE COMANDO QUE VERIFICA EM QUAL MAPA ESTA
		if (Mundos.gm.levelComplet == LevelComplet.Level0) {

            // LINHA DE COMANDO QUE VERIFICA SE COLETOU TODAS AS MOEDAS DO MAPA
			if (Mundos.gm.coins == 10) {

                // LINHA DE COMANDO QUE VERIFICA SE O TEMPO ESTA IGUAL OU ABAIXO DE 21 SEGUNDOS
				if (Cronometro.gm.Seconds <= 5) {

                    // LINHA DE COMANDO QUE SALVA 2 ESTRELAS NO JOGO
					PlayerPrefs.SetInt ("Star_0_1", 2);

                    // LINHA DE COMANDO QUE MOSTRA AS 2 ESTRELAS
                    StartCoroutine(StarDuasEstrelas());
				}

                // LINHA DE COMANDO QUE VERIFICA SE O TEMPO ESTA IGUAL OU ACIMA DE 22 SEGUNDOS
				if (Cronometro.gm.Seconds >= 6) {

                    // LINHA DE COMANDO QUE SALVA AS 3 ESTRELAS NO JOGO
					PlayerPrefs.SetInt ("Star_0_2", 3);

                    // LINHA DE COMANDO QUE MOSTRA AS 3 ESTRELAS
                    StartCoroutine(StarTresEstrelas());
                }

                // LINHA DE COMANDO QUE APARECE O FUNDO DAS ENTRELAS 
                StartCoroutine(FundoEstrelas());

                // LINHA DE COMANDO QUE MOSTRA O FUNDO DO MENU COMPLETO
                StartCoroutine(FundoMenuCompleto());

            }

            // LINHA DE COMANDO QUE VERIFICA SE O TEMPO E MENOR OU IGUAL A 0, E TAMBEM VERIFCA SE O PIRATA MORREU
            if (Cronometro.gm.Seconds <= 0 || PirataControle.gm.morreu == true) {

                // LINHA DE COMANDO QUE SALVA 1 ESTRELA NO JOGO
				PlayerPrefs.SetInt ("Star_0_0", 1);

                // LINHA DE COMANDO QUE MOSTRA 1 ESTRELA NO JOGO
                StartCoroutine(StarUmEstrelas());

                // LINHA DE COMANDO QUE MOSTRA O FUNDO DA ESTRELA
                StartCoroutine(FundoEstrelas());

                // LINHA DE COMANDO QUE MOSTRA O FUNDO DO MENU FRACASSADO
                StartCoroutine(FundoMenuFracassado());
			}
		}

		if (Mundos.gm.levelComplet == LevelComplet.Level1) {
			if (Mundos.gm.coins == 10) {
				if (Cronometro.gm.Seconds <= 15) {
					PlayerPrefs.SetInt ("Star_1_1", 2);
                    StartCoroutine(StarDuasEstrelas());
                }

				if (Cronometro.gm.Seconds >= 16) {
					PlayerPrefs.SetInt ("Star_1_2", 3);
                    StartCoroutine(StarTresEstrelas());
                }
                StartCoroutine(FundoEstrelas());
                StartCoroutine(FundoMenuCompleto());
            }

			if (Cronometro.gm.Seconds <= 0 || PirataControle.gm.morreu == true) {
				PlayerPrefs.SetInt ("Star_1_0", 1);
                StartCoroutine(StarUmEstrelas());
                StartCoroutine(FundoEstrelas());
                StartCoroutine(FundoMenuFracassado());
            }
		}

		if (Mundos.gm.levelComplet == LevelComplet.Level2) {
			if (Mundos.gm.coins == 10) {
				if (Cronometro.gm.Seconds <= 9) {
					PlayerPrefs.SetInt ("Star_2_1", 2);
                    StartCoroutine(StarDuasEstrelas());
                }

				if (Cronometro.gm.Seconds >= 10) {
					PlayerPrefs.SetInt ("Star_2_2", 3);
                    StartCoroutine(StarTresEstrelas());
                }
                StartCoroutine(FundoEstrelas());
                StartCoroutine(FundoMenuCompleto());
            }

			if (Cronometro.gm.Seconds <= 0 || PirataControle.gm.morreu == true) {
				PlayerPrefs.SetInt ("Star_2_0", 1);
                StartCoroutine(StarUmEstrelas());
                StartCoroutine(FundoEstrelas());
                StartCoroutine(FundoMenuFracassado());
            }
		}

		if (Mundos.gm.levelComplet == LevelComplet.Level3) {
			if (Mundos.gm.coins == 10) {
				if (Cronometro.gm.Seconds <= 29) {
					PlayerPrefs.SetInt ("Star_3_1", 2);
                    StartCoroutine(StarDuasEstrelas());
                }

				if (Cronometro.gm.Seconds >= 30) {
					PlayerPrefs.SetInt ("Star_3_2", 3);
                    StartCoroutine(StarTresEstrelas());
                }
                StartCoroutine(FundoEstrelas());
                StartCoroutine(FundoMenuCompleto());
            }

			if (Cronometro.gm.Seconds <= 0 || PirataControle.gm.morreu == true) {
				PlayerPrefs.SetInt ("Star_3_0", 1);
                StartCoroutine(StarUmEstrelas());
                StartCoroutine(FundoEstrelas());
                StartCoroutine(FundoMenuFracassado());
            }
		}

		if (Mundos.gm.levelComplet == LevelComplet.Level4) {
			if (Mundos.gm.coins == 10) {
				if (Cronometro.gm.Seconds <= 13) {
					PlayerPrefs.SetInt ("Star_4_1", 2);
                    StartCoroutine(StarDuasEstrelas());
                }

				if (Cronometro.gm.Seconds >= 14) {
					PlayerPrefs.SetInt ("Star_4_2", 3);
                    StartCoroutine(StarTresEstrelas());
                }
                StartCoroutine(FundoEstrelas());
                StartCoroutine(FundoMenuCompleto());
            }

			if (Cronometro.gm.Seconds <= 0 || PirataControle.gm.morreu == true) {
				PlayerPrefs.SetInt ("Star_4_0", 1);
                StartCoroutine(StarUmEstrelas());
                StartCoroutine(FundoEstrelas());
                StartCoroutine(FundoMenuFracassado());
            }
		}

		if (Mundos.gm.levelComplet == LevelComplet.Level5) {
			if (Mundos.gm.coins == 10) {
				if (Cronometro.gm.Seconds <= 20) {
					PlayerPrefs.SetInt ("Star_5_1", 2);
                    StartCoroutine(StarDuasEstrelas());
                }

				if (Cronometro.gm.Seconds >= 21) {
					PlayerPrefs.SetInt ("Star_5_2", 3);
                    StartCoroutine(StarTresEstrelas());
                }
                StartCoroutine(FundoEstrelas());
                StartCoroutine(FundoMenuCompleto());
            }

			if (Cronometro.gm.Seconds <= 0 || PirataControle.gm.morreu == true) {
				PlayerPrefs.SetInt ("Star_5_0", 1);
                StartCoroutine(StarUmEstrelas());
                StartCoroutine(FundoEstrelas());
                StartCoroutine(FundoMenuFracassado());
            }
		}

		if (Mundos.gm.levelComplet == LevelComplet.Level6) {
			if (Mundos.gm.coins == 10) {
				if (Cronometro.gm.Seconds <= 20) {
					PlayerPrefs.SetInt ("Star_6_1", 2);
                    StartCoroutine(StarDuasEstrelas());
                }

				if (Cronometro.gm.Seconds >= 21) {
					PlayerPrefs.SetInt ("Star_6_2", 3);
                    StartCoroutine(StarTresEstrelas());
                }
                StartCoroutine(FundoEstrelas());
                StartCoroutine(FundoMenuCompleto());
            }

			if (Cronometro.gm.Seconds <= 0 || PirataControle.gm.morreu == true) {
				PlayerPrefs.SetInt ("Star_6_0", 1);
                StartCoroutine(StarUmEstrelas());
                StartCoroutine(FundoEstrelas());
                StartCoroutine(FundoMenuFracassado());
            }
		}

		if (Mundos.gm.levelComplet == LevelComplet.Level7) {
			if (Mundos.gm.coins == 10) {
				if (Cronometro.gm.Seconds <= 10) {
					PlayerPrefs.SetInt ("Star_7_1", 2);
                    StartCoroutine(StarDuasEstrelas());
                }

				if (Cronometro.gm.Seconds >= 11) {
					PlayerPrefs.SetInt ("Star_7_2", 3);
                    StartCoroutine(StarTresEstrelas());
                }
                StartCoroutine(FundoEstrelas());
                StartCoroutine(FundoMenuCompleto());
            }

			if (Cronometro.gm.Seconds <= 0 || PirataControle.gm.morreu == true) {
				PlayerPrefs.SetInt ("Star_7_0", 1);
                StartCoroutine(StarUmEstrelas());
                StartCoroutine(FundoEstrelas());
                StartCoroutine(FundoMenuFracassado());
            }
		}

		if (Mundos.gm.levelComplet == LevelComplet.Level8) {
			if (Mundos.gm.coins == 10) {
				if (Cronometro.gm.Seconds <= 10) {
					PlayerPrefs.SetInt ("Star_8_1", 2);
                    StartCoroutine(StarDuasEstrelas());
                }

				if (Cronometro.gm.Seconds >= 11) {
					PlayerPrefs.SetInt ("Star_8_2", 3);
                    StartCoroutine(StarTresEstrelas());
                }
                StartCoroutine(FundoEstrelas());
                StartCoroutine(FundoMenuCompleto());
            }

			if (Cronometro.gm.Seconds <= 0 || PirataControle.gm.morreu == true) {
				PlayerPrefs.SetInt ("Star_8_0", 1);
                StartCoroutine(StarUmEstrelas());
                StartCoroutine(FundoEstrelas());
                StartCoroutine(FundoMenuFracassado());
            }
		}

		if (Mundos.gm.levelComplet == LevelComplet.Level9) {
			if (Mundos.gm.coins == 10) {
				if (Cronometro.gm.Seconds <= 10) {
					PlayerPrefs.SetInt ("Star_9_1", 2);
                    StartCoroutine(StarDuasEstrelas());
                }

				if (Cronometro.gm.Seconds >= 11) {
					PlayerPrefs.SetInt ("Star_9_2", 3);
                    StartCoroutine(StarTresEstrelas());
                }
                StartCoroutine(FundoEstrelas());
                StartCoroutine(FundoMenuCompleto());
            }

			if (Cronometro.gm.Seconds <= 0 || PirataControle.gm.morreu == true) {
				PlayerPrefs.SetInt ("Star_9_0", 1);
                StartCoroutine(StarUmEstrelas());
                StartCoroutine(FundoEstrelas());
                StartCoroutine(FundoMenuFracassado());
            }
		}
	}

	void EstrelaDoMundoDois()
    {	
	}

    //LINHA DE COMANDO DO FUNDA DAS ESTRELAS
    public IEnumerator FundoEstrelas(){
        yield return new WaitForSeconds(2f);
        fundo1.SetActive (true);
		fundo2.SetActive (true);
		fundo3.SetActive (true);	
	}

    // LINHA DE COMANDO QUE ESPERA 0.5 SEG PARA ATIVAR UMA ESTRELA
    public IEnumerator StarUmEstrelas()
    {
        yield return new WaitForSeconds(2f);
        umaestrela.SetActive(true);
    }

    // LINHA DE COMANDO QUE ESPERA 0.5 SEG PARA ATIVAR DUAS ESTRELA
    public IEnumerator StarDuasEstrelas()
    {
        yield return new WaitForSeconds(2.2f);
        umaestrela.SetActive(true);
        yield return new WaitForSeconds(1f);
        duasestrela.SetActive(true);
        tresestrela.SetActive(false);
    }

    // LINHA DE COMANDO QUE ESPERA 0.5 SEG PARA ATIVAR TRES ESTRELA
    public IEnumerator StarTresEstrelas()
    {
        yield return new WaitForSeconds(2.2f);
        umaestrela.SetActive(true);
        yield return new WaitForSeconds(1f);
        duasestrela.SetActive(true);
        yield return new WaitForSeconds(1f);
        tresestrela.SetActive(true);
    }

    // LINHA DE COMANDO DO FUNDO DO MENU FRACASSADO
    public IEnumerator FundoMenuFracassado()
    {
        yield return new WaitForSeconds(2f);
        FundoMF.SetActive(true);
        FundoMC.SetActive(false);
        yield return new WaitForSeconds(2f);
        FundoMF.SetActive(false);
    }

    // LINHA DE COMANDO DO FUNDO DO MENU COMPLETO
    public IEnumerator FundoMenuCompleto()
    {
        yield return new WaitForSeconds(2f);
        FundoMC.SetActive(true);
        FundoMF.SetActive(false);
        yield return new WaitForSeconds(2f);
        FundoMC.SetActive(false);
    }
}
