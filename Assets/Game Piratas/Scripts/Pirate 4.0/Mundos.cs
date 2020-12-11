using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum SelectModo{
	Nome, selecMapaUm, selectGame, selectMoedas
}

public enum LevelComplet{
	Nome, Level0, Level1, Level2, Level3, Level4, Level5, Level6, Level7, Level8, Level9
}

public class Mundos : MonoBehaviour {
	private MenuSelectScenes menuSelectScenes;
	public SelectModo selecionarModo;
	public LevelComplet levelComplet;

	public static Mundos gm;

    // Variaveis dentro do jogo
    public int coins = 0;
    public Text CoinText;

    // MUNDO UM
    private GameObject Star_0_0;
    private GameObject Star_0_1;
    private GameObject Star_0_2;

    private GameObject Star_1_0;
    private GameObject Star_1_1;
    private GameObject Star_1_2;

	private GameObject Star_2_0;
	private GameObject Star_2_1;
	private GameObject Star_2_2;

	private GameObject Star_3_0;
	private GameObject Star_3_1;
	private GameObject Star_3_2;

	private GameObject Star_4_0;
	private GameObject Star_4_1;
	private GameObject Star_4_2;

	private GameObject Star_5_0;
	private GameObject Star_5_1;
	private GameObject Star_5_2;

	private GameObject Star_6_0;
	private GameObject Star_6_1;
	private GameObject Star_6_2;

	private GameObject Star_7_0;
	private GameObject Star_7_1;
	private GameObject Star_7_2;

	private GameObject Star_8_0;
	private GameObject Star_8_1;
	private GameObject Star_8_2;

    private GameObject Star_9_0;
    private GameObject Star_9_1;
    private GameObject Star_9_2;


    void Awake(){
		if (selecionarModo == SelectModo.selectGame) {
            gm = this;
		}

        // LINHA DE COMANDO QUE PROCURA O SCRITP MenuSelectScenes VINCULADO NO MAPA 1
        if (selecionarModo == SelectModo.selecMapaUm) {
			menuSelectScenes = GameObject.Find ("Mapa 1").GetComponent < MenuSelectScenes > ();
			OpenFindMapaUm ();
		}
    }

    void Start () {
		if (selecionarModo == SelectModo.selecMapaUm) {			
			SetActiveMapaUm ();
		}

		if (selecionarModo == SelectModo.selectMoedas) {
			CoinText = GetComponent<Text> () as Text;
		}
    }

	void Update(){
		//LINHA DE COMANDO QUE RESET O SALVE
		if (Input.GetKeyDown (KeyCode.F1)) {
			PlayerPrefs.DeleteAll ();
			Debug.Log("RESET SALVE");
		}

		HabilitarEstrelasFases ();
		CompleteInGame ();
	}

    // LINHA DE COMANDO QUE MOSTRA O QUANTO DE MOEDAS 
    //FOI PEGO DENTRO DO JOGO PARA HABILITAR AS ESTRELAS NO MAPA
    #region MOEDAS
    void CoinLogic()
    {
		GetComponent<Text> ().text = coins.ToString ("00");
    }

	public void Coins(int adj)
    {
		coins += adj;
    }
    
    // LINHA DE COMANDO MISSAO COMPLETA DE COLETAS E SALVA AS 10 MOEDAS NO DENTRO DO JOGO
    void CompleteInGame()
    {
        // LINHA DE COMANDO ESTA VINCULADA NO MAPA E NA TELA DA MOEDA TXT DENTRO DO JOGO
        if (selecionarModo == SelectModo.selectGame)
        {
            // LINHA DE COMANDO DAS MOEDAS
			CoinLogic ();
            
            // LINHA DE COAMNDO VERIFICA SE ESTA SELECIONADO O LEVELO 
            if (levelComplet == LevelComplet.Level0){
				//PlayerPrefs.SetInt ("Coins0", coins);

                // LINHA DE COMANDO QUE VERIFICA SE O LEVEL0 E IGUAL A 10 MOEDAS COLETDAS DENTRO DO JOGO
				if (levelComplet == LevelComplet.Level0 && coins == 10) {

                    // LINHA DE COMANDO QUE HABILITA O MENU MISSAO COMPLETA CASO COLETADOS AS 10 MOEDAS
                    MenuInGame.gm.CompleteiMissao();
				}
			}

			if(levelComplet == LevelComplet.Level1){				
				if (levelComplet == LevelComplet.Level1 && coins == 10) {
                    MenuInGame.gm.CompleteiMissao();
                }
			}

			if(levelComplet == LevelComplet.Level2){				
				if (levelComplet == LevelComplet.Level2 && coins == 10) {
                    MenuInGame.gm.CompleteiMissao();
                }
			}

			if(levelComplet == LevelComplet.Level3){				
				if (levelComplet == LevelComplet.Level3 && coins == 10) {
                    MenuInGame.gm.CompleteiMissao();
                }
			}

			if(levelComplet == LevelComplet.Level4){				
				if (levelComplet == LevelComplet.Level4 && coins == 10) {
                    MenuInGame.gm.CompleteiMissao();
                }
			}

			if(levelComplet == LevelComplet.Level5){				
				if (levelComplet == LevelComplet.Level5 && coins == 10) {
                    MenuInGame.gm.CompleteiMissao();
                }
			}

			if(levelComplet == LevelComplet.Level6){				
				if (levelComplet == LevelComplet.Level6 && coins == 10) {
                    MenuInGame.gm.CompleteiMissao();
                }
			}

			if(levelComplet == LevelComplet.Level7){				
				if (levelComplet == LevelComplet.Level7 && coins == 10) {
                    MenuInGame.gm.CompleteiMissao();
                }
			}

			if(levelComplet == LevelComplet.Level8){
                if (levelComplet == LevelComplet.Level8 && coins == 10) {
                    MenuInGame.gm.CompleteiMissao();
                }
			}

			if(levelComplet == LevelComplet.Level9){				
				if (levelComplet == LevelComplet.Level9 && coins == 10) {
                    MenuInGame.gm.CompleteiMissao();
                }
			}
		}
	}
    #endregion

    // LINHA DE COMANDO RESPONSAVEL PARA HABILITAR UMA NOVA FASE NO MENU SELECIONAR MAPA
    // E TAMBEM MOSTRAR A QUANTIDA DE ESTRELAS QUE VOCE TIROU NA FASE
    void HabilitarEstrelasFases(){

        #region MAPA 1 DO JOGO
        // LINHA DE COMANDO QUE VERIFICA SE O MAPA 1 ESTA SELECIONA 
        if (selecionarModo == SelectModo.selecMapaUm){

            // LINHA DE COMANDO QUE VERIFICA SE A STAR_0_1 OU STAR 0_2 ESTA HABILITADO COMO TRUE
			if (Star_0_1.activeSelf == true || Star_0_2.activeSelf == true ) {

                // LINHA DE COMANDO QUE HABILITA A FASE 1 DO JOGO E DESABILITA A FASE TRANCADA DA FASE 1
				menuSelectScenes.Open1.SetActive (true);
				menuSelectScenes.Close1.SetActive (false);
			}
            
			if (Star_1_1.activeSelf == true || Star_1_2.activeSelf == true ) {
				menuSelectScenes.Open2.SetActive (true);
				menuSelectScenes.Close2.SetActive (false);
			}

			if (Star_2_1.activeSelf == true || Star_2_2.activeSelf == true ) {
				menuSelectScenes.Open3.SetActive (true);
				menuSelectScenes.Close3.SetActive (false);
			}

			if (Star_3_1.activeSelf == true || Star_3_2.activeSelf == true ) {
				menuSelectScenes.Open4.SetActive (true);
				menuSelectScenes.Close4.SetActive (false);
			}

			if (Star_4_1.activeSelf == true || Star_4_2.activeSelf == true ) {
				menuSelectScenes.Open5.SetActive (true);
				menuSelectScenes.Close5.SetActive (false);
			}

			if (Star_5_1.activeSelf == true || Star_5_2.activeSelf == true ) {
				menuSelectScenes.Open6.SetActive (true);
				menuSelectScenes.Close6.SetActive (false);
			}

			if (Star_6_1.activeSelf == true || Star_6_2.activeSelf == true ) {
				menuSelectScenes.Open7.SetActive (true);
				menuSelectScenes.Close7.SetActive (false);
			}

			if (Star_7_1.activeSelf == true || Star_7_2.activeSelf == true ) {
				menuSelectScenes.Open8.SetActive (true);
				menuSelectScenes.Close8.SetActive (false);
			}

			if (Star_8_1.activeSelf == true || Star_8_2.activeSelf == true ) {
				menuSelectScenes.Open9.SetActive (true);
				menuSelectScenes.Close9.SetActive (false);
			}

            if (Star_9_1.activeSelf == true || Star_9_2.activeSelf == true)
            {
                // HABILITA O MAPA 2
            }


            // LINHA DE COMANDO QUE VERIFICA SE A FASE ESTA SELECIONADO COMO LEVEL0 
            if (levelComplet == LevelComplet.Level0) {

                // LINHA DE COMANDO QUE PEGA A VARIAVEL SALVA STAR_0_0 PARA HABILITAR UMA ESTRELA NO JOGO
                // ESSE COMANDO PlayerPrefs.HasKey ESTA SENDO SALVO NO SCRITP ESTRELA.CS
                if (PlayerPrefs.HasKey ("Star_0_0")) {

                    // LINHA DE COMANDO DO GAMEOBJECT DA UMA ESTRELA NO JOGO
					Star_0_0.SetActive (true);
				}
				if (PlayerPrefs.HasKey ("Star_0_1")) {
					Star_0_1.SetActive (true);
				}
				if (PlayerPrefs.HasKey ("Star_0_2")) {
					Star_0_2.SetActive (true);
				}
			}

			if (levelComplet == LevelComplet.Level1) {
				if (PlayerPrefs.HasKey ("Star_1_0")) {
					Star_1_0.SetActive (true);
				}
				if (PlayerPrefs.HasKey ("Star_1_1")) {
					Star_1_1.SetActive (true);
				}
				if (PlayerPrefs.HasKey ("Star_1_2")) {
					Star_1_2.SetActive (true);
				}				
			}

			if (levelComplet == LevelComplet.Level2) {
				if (PlayerPrefs.HasKey ("Star_2_0")) {
					Star_2_0.SetActive (true);
				}
				if (PlayerPrefs.HasKey ("Star_2_1")) {
					Star_2_1.SetActive (true);
				}
				if (PlayerPrefs.HasKey ("Star_2_2")) {
					Star_2_2.SetActive (true);
				}				
			}

			if (levelComplet == LevelComplet.Level3) {
				if (PlayerPrefs.HasKey ("Star_3_0")) {
					Star_3_0.SetActive (true);
				}
				if (PlayerPrefs.HasKey ("Star_3_1")) {
					Star_3_1.SetActive (true);
				}
				if (PlayerPrefs.HasKey ("Star_3_2")) {
					Star_3_2.SetActive (true);
				}				
			}

			if (levelComplet == LevelComplet.Level4) {
				if (PlayerPrefs.HasKey ("Star_4_0")) {
					Star_4_0.SetActive (true);
				}
				if (PlayerPrefs.HasKey ("Star_4_1")) {
					Star_4_1.SetActive (true);
				}
				if (PlayerPrefs.HasKey ("Star_4_2")) {
					Star_4_2.SetActive (true);
				}				
			}

			if (levelComplet == LevelComplet.Level5) {
				if (PlayerPrefs.HasKey ("Star_5_0")) {
					Star_5_0.SetActive (true);
				}
				if (PlayerPrefs.HasKey ("Star_5_1")) {
					Star_5_1.SetActive (true);
				}
				if (PlayerPrefs.HasKey ("Star_5_2")) {
					Star_5_2.SetActive (true);
				}				
			}

			if (levelComplet == LevelComplet.Level6) {
				if (PlayerPrefs.HasKey ("Star_6_0")) {
					Star_6_0.SetActive (true);
				}
				if (PlayerPrefs.HasKey ("Star_6_1")) {
					Star_6_1.SetActive (true);
				}
				if (PlayerPrefs.HasKey ("Star_6_2")) {
					Star_6_2.SetActive (true);
				}				
			}

			if (levelComplet == LevelComplet.Level7) {
				if (PlayerPrefs.HasKey ("Star_7_0")) {
					Star_7_0.SetActive (true);
				}
				if (PlayerPrefs.HasKey ("Star_7_1")) {
					Star_7_1.SetActive (true);
				}
				if (PlayerPrefs.HasKey ("Star_7_2")) {
					Star_7_2.SetActive (true);
				}				
			}

			if (levelComplet == LevelComplet.Level8) {
				if (PlayerPrefs.HasKey ("Star_8_0")) {
					Star_8_0.SetActive (true);
				}
				if (PlayerPrefs.HasKey ("Star_8_1")) {
					Star_8_1.SetActive (true);
				}
				if (PlayerPrefs.HasKey ("Star_8_2")) {
					Star_8_2.SetActive (true);
				}				
			}

            if (levelComplet == LevelComplet.Level9)
            {
                if (PlayerPrefs.HasKey("Star_9_0"))
                {
                    Star_9_0.SetActive(true);
                }
                if (PlayerPrefs.HasKey("Star_9_1"))
                {
                    Star_9_1.SetActive(true);
                }
                if (PlayerPrefs.HasKey("Star_9_2"))
                {
                    Star_9_2.SetActive(true);
                }
            }
        }

        #endregion

    }

    void OpenFindMapaUm(){
		Star_0_0 = GameObject.Find ("Open0/Estrelas/1");
		Star_0_1 = GameObject.Find ("Open0/Estrelas/2");
		Star_0_2 = GameObject.Find ("Open0/Estrelas/3");

		Star_1_0 = GameObject.Find ("Open1/Estrelas/1");
		Star_1_1 = GameObject.Find ("Open1/Estrelas/2");
		Star_1_2 = GameObject.Find ("Open1/Estrelas/3");

		Star_2_0 = GameObject.Find ("Open2/Estrelas/1");
		Star_2_1 = GameObject.Find ("Open2/Estrelas/2");
		Star_2_2 = GameObject.Find ("Open2/Estrelas/3");

		Star_3_0 = GameObject.Find ("Open3/Estrelas/1");
		Star_3_1 = GameObject.Find ("Open3/Estrelas/2");
		Star_3_2 = GameObject.Find ("Open3/Estrelas/3");

		Star_4_0 = GameObject.Find ("Open4/Estrelas/1");
		Star_4_1 = GameObject.Find ("Open4/Estrelas/2");
		Star_4_2 = GameObject.Find ("Open4/Estrelas/3");

		Star_5_0 = GameObject.Find ("Open5/Estrelas/1");
		Star_5_1 = GameObject.Find ("Open5/Estrelas/2");
		Star_5_2 = GameObject.Find ("Open5/Estrelas/3");

		Star_6_0 = GameObject.Find ("Open6/Estrelas/1");
		Star_6_1 = GameObject.Find ("Open6/Estrelas/2");
		Star_6_2 = GameObject.Find ("Open6/Estrelas/3");

		Star_7_0 = GameObject.Find ("Open7/Estrelas/1");
		Star_7_1 = GameObject.Find ("Open7/Estrelas/2");
		Star_7_2 = GameObject.Find ("Open7/Estrelas/3");

		Star_8_0 = GameObject.Find ("Open8/Estrelas/1");
		Star_8_1 = GameObject.Find ("Open8/Estrelas/2");
		Star_8_2 = GameObject.Find ("Open8/Estrelas/3");

        Star_9_0 = GameObject.Find ("Open9/Estrelas/1");
        Star_9_1 = GameObject.Find ("Open9/Estrelas/2");
        Star_9_2 = GameObject.Find ("Open9/Estrelas/3");
    }

	void SetActiveMapaUm(){
		Star_0_0.SetActive (false);
		Star_0_1.SetActive (false);
		Star_0_2.SetActive (false);

		Star_1_0.SetActive (false);
		Star_1_1.SetActive (false);
		Star_1_2.SetActive (false);

		Star_2_0.SetActive (false);
		Star_2_1.SetActive (false);
		Star_2_2.SetActive (false);

		Star_3_0.SetActive (false);
		Star_3_1.SetActive (false);
		Star_3_2.SetActive (false);

		Star_4_0.SetActive (false);
		Star_4_1.SetActive (false);
		Star_4_2.SetActive (false);

		Star_5_0.SetActive (false);
		Star_5_1.SetActive (false);
		Star_5_2.SetActive (false);

		Star_6_0.SetActive (false);
		Star_6_1.SetActive (false);
		Star_6_2.SetActive (false);

		Star_7_0.SetActive (false);
		Star_7_1.SetActive (false);
		Star_7_2.SetActive (false);

		Star_8_0.SetActive (false);
		Star_8_1.SetActive (false);
		Star_8_2.SetActive (false);

        Star_9_0.SetActive(false);
        Star_9_1.SetActive(false);
        Star_9_2.SetActive(false);
    }
}

