using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum SelectModo{
	Nome, NoJogo, Moedas, Mundo_I, Mundo_II 
}

public enum LevelComplet{
	Nome, Level_1, Level_2, Level_3, Level_4, Level_5, Level_6, Level_7, Level_8, Level_9, Level_10
}

public class Mundos : MonoBehaviour {

	public SelectModo selecionarModo;
	public LevelComplet levelComplet;

	public static Mundos gm;

    // Variaveis dentro do jogo
    public int coins = 0;
    public Text CoinText;

	void Awake(){
		if (selecionarModo == SelectModo.NoJogo) {
            gm = this;
		}
        
        if (selecionarModo == SelectModo.Mundo_I) {
			OpenFindMapa_I ();
		}
    }

    void Start () {
		if (selecionarModo == SelectModo.Mundo_I) {			
			SetActiveMapa_I ();
		}

		if (selecionarModo == SelectModo.Mundo_II)
		{
			//SetActiveMapa_II();
		}

		if (selecionarModo == SelectModo.Moedas) {
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
        if (selecionarModo == SelectModo.NoJogo)
        {
            // LINHA DE COMANDO DAS MOEDAS
			CoinLogic ();
            
            // LINHA DE COAMNDO VERIFICA SE ESTA SELECIONADO O LEVEL_1 
            if (levelComplet == LevelComplet.Level_1){

                // LINHA DE COMANDO QUE VERIFICA SE O LEVEL0 E IGUAL A 10 MOEDAS COLETDAS DENTRO DO JOGO
				if (levelComplet == LevelComplet.Level_1 && coins == 10) {

                    // LINHA DE COMANDO QUE HABILITA O MENU MISSAO COMPLETA CASO COLETADOS AS 10 MOEDAS
                    MenuInGame.gm.CompleteiMissao();
				}
			}

			if(levelComplet == LevelComplet.Level_2){				
				if (levelComplet == LevelComplet.Level_2 && coins == 10) {
                    MenuInGame.gm.CompleteiMissao();
                }
			}

			if(levelComplet == LevelComplet.Level_3){				
				if (levelComplet == LevelComplet.Level_3 && coins == 10) {
                    MenuInGame.gm.CompleteiMissao();
                }
			}

			if(levelComplet == LevelComplet.Level_4){				
				if (levelComplet == LevelComplet.Level_4 && coins == 10) {
                    MenuInGame.gm.CompleteiMissao();
                }
			}

			if(levelComplet == LevelComplet.Level_5){				
				if (levelComplet == LevelComplet.Level_5 && coins == 10) {
                    MenuInGame.gm.CompleteiMissao();
                }
			}

			if(levelComplet == LevelComplet.Level_6){				
				if (levelComplet == LevelComplet.Level_6 && coins == 10) {
                    MenuInGame.gm.CompleteiMissao();
                }
			}

			if(levelComplet == LevelComplet.Level_7){				
				if (levelComplet == LevelComplet.Level_7 && coins == 10) {
                    MenuInGame.gm.CompleteiMissao();
                }
			}

			if(levelComplet == LevelComplet.Level_8){				
				if (levelComplet == LevelComplet.Level_8 && coins == 10) {
                    MenuInGame.gm.CompleteiMissao();
                }
			}

			if(levelComplet == LevelComplet.Level_9){
                if (levelComplet == LevelComplet.Level_9 && coins == 10) {
                    MenuInGame.gm.CompleteiMissao();
                }
			}

			if(levelComplet == LevelComplet.Level_10){				
				if (levelComplet == LevelComplet.Level_10 && coins == 10) {
                    MenuInGame.gm.CompleteiMissao();
                }
			}
		}
	}
    #endregion

    /* LINHA DE COMANDO RESPONSAVEL PARA HABILITAR UMA NOVA FASE NO MENU SELECIONAR MAPA
     * E TAMBEM MOSTRAR A QUANTIDA DE ESTRELAS QUE VOCE TIROU NA FASE */
    void HabilitarEstrelasFases(){

        #region MAPA I DO JOGO
        // LINHA DE COMANDO QUE VERIFICA SE O MAPA 1 ESTA SELECIONA 
        if (selecionarModo == SelectModo.Mundo_I){

			Mapa_I.gm.HabilitarFase();

			// LINHA DE COMANDO QUE VERIFICA SE A FASE ESTA SELECIONADO COMO LEVEL_1 
			if (levelComplet == LevelComplet.Level_1)
			{
				Mapa_I.gm.Level_1();
			}

			if (levelComplet == LevelComplet.Level_2)
			{
				Mapa_I.gm.Level_2();
			}

			if (levelComplet == LevelComplet.Level_3)
			{
				Mapa_I.gm.Level_3();
			}

			if (levelComplet == LevelComplet.Level_4)
			{
				Mapa_I.gm.Level_4();
			}

			if (levelComplet == LevelComplet.Level_5)
			{
				Mapa_I.gm.Level_5();
			}

			if (levelComplet == LevelComplet.Level_6)
			{
				Mapa_I.gm.Level_6();
			}

			if (levelComplet == LevelComplet.Level_7)
			{
				Mapa_I.gm.Level_7();
			}

			if (levelComplet == LevelComplet.Level_8)
			{
				Mapa_I.gm.Level_8();
			}

			if (levelComplet == LevelComplet.Level_9)
			{
				Mapa_I.gm.Level_9();
			}

            if (levelComplet == LevelComplet.Level_10)
            {
				Mapa_I.gm.Level_10();
			}
        }

        #endregion

        #region MAPA II DO JOGO
		if(selecionarModo == SelectModo.Mundo_II)
        {

        }
        #endregion

    }

	void OpenFindMapa_I()
	{
		Mapa_I.gm.OpenFindMapa();
	}

	void SetActiveMapa_I()
	{
		Mapa_I.gm.SetActiveMapa();
	}
}

