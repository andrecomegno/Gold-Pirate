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

	public LevelMapa menuSelectScenes;

	public GameObject[] stars;

	void Awake() {
		if (selecionarModo == SelectModo.NoJogo) {
			gm = this;
		}

		if (selecionarModo == SelectModo.Mundo_I) {
			menuSelectScenes = GameObject.Find("Mapa I").GetComponent<LevelMapa>();
			SetActiveMapa_I();
		}
	}

	void Start() {
		if (selecionarModo == SelectModo.Moedas) {
			CoinText = GetComponent<Text>() as Text;
		}
	}

	void Update() {
		//LINHA DE COMANDO QUE RESET O SALVE
		if (Input.GetKeyDown(KeyCode.F1)) {
			PlayerPrefs.DeleteAll();
			Debug.Log("RESET SALVE");
		}

		HabilitarEstrelasFases();
		CompleteInGame();
	}

	/* LINHA DE COMANDO QUE MOSTRA O QUANTO DE MOEDAS FOI
	 * PEGO DENTRO DO JOGO PARA HABILITAR AS ESTRELAS NO MAPA */
	#region MOEDAS
	void CoinLogic()
	{
		GetComponent<Text>().text = coins.ToString("00");
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
			CoinLogic();

			// LINHA DE COAMNDO VERIFICA SE ESTA SELECIONADO O LEVEL_1 
			if (levelComplet == LevelComplet.Level_1) {

				// LINHA DE COMANDO QUE VERIFICA SE O LEVEL_1 E IGUAL A 10 MOEDAS COLETDAS DENTRO DO JOGO
				if (levelComplet == LevelComplet.Level_1 && coins == 10) {

					// LINHA DE COMANDO QUE HABILITA O MENU MISSAO COMPLETA CASO COLETADOS AS 10 MOEDAS
					MenuInGame.gm.CompleteiMissao();
				}
			}

			if (levelComplet == LevelComplet.Level_2) {
				if (levelComplet == LevelComplet.Level_2 && coins == 10) {
					MenuInGame.gm.CompleteiMissao();
				}
			}

			if (levelComplet == LevelComplet.Level_3) {
				if (levelComplet == LevelComplet.Level_3 && coins == 10) {
					MenuInGame.gm.CompleteiMissao();
				}
			}

			if (levelComplet == LevelComplet.Level_4) {
				if (levelComplet == LevelComplet.Level_4 && coins == 10) {
					MenuInGame.gm.CompleteiMissao();
				}
			}

			if (levelComplet == LevelComplet.Level_5) {
				if (levelComplet == LevelComplet.Level_5 && coins == 10) {
					MenuInGame.gm.CompleteiMissao();
				}
			}

			if (levelComplet == LevelComplet.Level_6) {
				if (levelComplet == LevelComplet.Level_6 && coins == 10) {
					MenuInGame.gm.CompleteiMissao();
				}
			}

			if (levelComplet == LevelComplet.Level_7) {
				if (levelComplet == LevelComplet.Level_7 && coins == 10) {
					MenuInGame.gm.CompleteiMissao();
				}
			}

			if (levelComplet == LevelComplet.Level_8) {
				if (levelComplet == LevelComplet.Level_8 && coins == 10) {
					MenuInGame.gm.CompleteiMissao();
				}
			}

			if (levelComplet == LevelComplet.Level_9) {
				if (levelComplet == LevelComplet.Level_9 && coins == 10) {
					MenuInGame.gm.CompleteiMissao();
				}
			}

			if (levelComplet == LevelComplet.Level_10) {
				if (levelComplet == LevelComplet.Level_10 && coins == 10) {
					MenuInGame.gm.CompleteiMissao();
				}
			}
		}
	}
	#endregion

	/* LINHA DE COMANDO RESPONSAVEL PARA HABILITAR UMA NOVA FASE NO MENU SELECIONAR MAPA
     * E TAMBEM MOSTRAR A QUANTIDA DE ESTRELAS QUE VOCE TIROU NA FASE */
	void HabilitarEstrelasFases() {

		#region MAPA I DO JOGO
		// LINHA DE COMANDO QUE VERIFICA SE O MAPA 1 ESTA SELECIONA 
		if (selecionarModo == SelectModo.Mundo_I) {
			// LINHA DE COMANDO QUE VERIFICA SE A FASE ESTA SELECIONADO COMO LEVEL_1 
			if (levelComplet == LevelComplet.Level_1)
			{
				if (stars[1].activeSelf == true || stars[2].activeSelf == true)
				{
					// LINHA DE COMANDO QUE HABILITA A LEVEL_2 DO MUNDO I
					menuSelectScenes.Open2.SetActive(true);
					menuSelectScenes.Close2.SetActive(false);
				}

				if (PlayerPrefs.HasKey("Star_1_0"))
				{
					// MOSTRA UMA ESTRELA NO JOGO
					stars[0].SetActive(true);
				}
				if (PlayerPrefs.HasKey("Star_1_1"))
				{
					// MOSTRA DUAS ESTRELA NO JOGO
					stars[1].SetActive(true);
				}
				if (PlayerPrefs.HasKey("Star_1_2"))
				{
					// TRÊS ESTRELA NO JOGO
					stars[2].SetActive(true);
				}
			}

			if (levelComplet == LevelComplet.Level_2)
			{
				if (stars[1].activeSelf == true || stars[2].activeSelf == true)
				{
					menuSelectScenes.Open3.SetActive(true);
					menuSelectScenes.Close3.SetActive(false);
				}

				if (PlayerPrefs.HasKey("Star_2_0"))
				{
					stars[0].SetActive(true);
				}
				if (PlayerPrefs.HasKey("Star_2_1"))
				{
					stars[1].SetActive(true);
				}
				if (PlayerPrefs.HasKey("Star_2_2"))
				{
					stars[2].SetActive(true);
				}
			}

			if (levelComplet == LevelComplet.Level_3)
			{
				if (stars[1].activeSelf == true || stars[2].activeSelf == true)
				{
					menuSelectScenes.Open4.SetActive(true);
					menuSelectScenes.Close4.SetActive(false);
				}

				if (PlayerPrefs.HasKey("Star_3_0"))
				{
					stars[0].SetActive(true);
				}
				if (PlayerPrefs.HasKey("Star_3_1"))
				{
					stars[1].SetActive(true);
				}
				if (PlayerPrefs.HasKey("Star_3_2"))
				{
					stars[2].SetActive(true);
				}
			}

			if (levelComplet == LevelComplet.Level_4)
			{
				if (stars[1].activeSelf == true || stars[2].activeSelf == true)
				{
					menuSelectScenes.Open5.SetActive(true);
					menuSelectScenes.Close5.SetActive(false);
				}

				if (PlayerPrefs.HasKey("Star_4_0"))
				{
					stars[0].SetActive(true);
				}
				if (PlayerPrefs.HasKey("Star_4_1"))
				{
					stars[1].SetActive(true);
				}
				if (PlayerPrefs.HasKey("Star_4_2"))
				{
					stars[2].SetActive(true);
				}
			}

			if (levelComplet == LevelComplet.Level_5)
			{
				if (stars[1].activeSelf == true || stars[2].activeSelf == true)
				{
					menuSelectScenes.Open6.SetActive(true);
					menuSelectScenes.Close6.SetActive(false);
				}

				if (PlayerPrefs.HasKey("Star_5_0"))
				{
					stars[0].SetActive(true);
				}
				if (PlayerPrefs.HasKey("Star_5_1"))
				{
					stars[1].SetActive(true);
				}
				if (PlayerPrefs.HasKey("Star_5_2"))
				{
					stars[2].SetActive(true);
				}
			}

			if (levelComplet == LevelComplet.Level_6)
			{
				if (stars[1].activeSelf == true || stars[2].activeSelf == true)
				{
					menuSelectScenes.Open7.SetActive(true);
					menuSelectScenes.Close7.SetActive(false);
				}

				if (PlayerPrefs.HasKey("Star_6_0"))
				{
					stars[0].SetActive(true);
				}
				if (PlayerPrefs.HasKey("Star_6_1"))
				{
					stars[1].SetActive(true);
				}
				if (PlayerPrefs.HasKey("Star_6_2"))
				{
					stars[2].SetActive(true);
				}
			}

			if (levelComplet == LevelComplet.Level_7)
			{
				if (stars[1].activeSelf == true || stars[2].activeSelf == true)
				{
					menuSelectScenes.Open8.SetActive(true);
					menuSelectScenes.Close8.SetActive(false);
				}

				if (PlayerPrefs.HasKey("Star_7_0"))
				{
					stars[0].SetActive(true);
				}
				if (PlayerPrefs.HasKey("Star_7_1"))
				{
					stars[1].SetActive(true);
				}
				if (PlayerPrefs.HasKey("Star_7_2"))
				{
					stars[2].SetActive(true);
				}
			}

			if (levelComplet == LevelComplet.Level_8)
			{
				if (stars[1].activeSelf == true || stars[2].activeSelf == true)
				{
					menuSelectScenes.Open9.SetActive(true);
					menuSelectScenes.Close9.SetActive(false);
				}

				if (PlayerPrefs.HasKey("Star_8_0"))
				{
					stars[0].SetActive(true);
				}
				if (PlayerPrefs.HasKey("Star_8_1"))
				{
					stars[1].SetActive(true);
				}
				if (PlayerPrefs.HasKey("Star_8_2"))
				{
					stars[2].SetActive(true);
				}
			}

			if (levelComplet == LevelComplet.Level_9)
			{
				if (stars[1].activeSelf == true || stars[2].activeSelf == true)
				{
					menuSelectScenes.Open10.SetActive(true);
					menuSelectScenes.Close10.SetActive(false);
				}

				if (PlayerPrefs.HasKey("Star_9_0"))
				{
					stars[0].SetActive(true);
				}
				if (PlayerPrefs.HasKey("Star_9_1"))
				{
					stars[1].SetActive(true);
				}
				if (PlayerPrefs.HasKey("Star_9_2"))
				{
					stars[2].SetActive(true);
				}
			}

            if (levelComplet == LevelComplet.Level_10)
            {
				if (stars[1].activeSelf == true || stars[2].activeSelf == true)
				{
					// MUNDO 2
				}

				if (PlayerPrefs.HasKey("Star_10_0"))
				{
					stars[0].SetActive(true);
				}
				if (PlayerPrefs.HasKey("Star_10_1"))
				{
					stars[1].SetActive(true);
				}
				if (PlayerPrefs.HasKey("Star_10_2"))
				{
					stars[2].SetActive(true);
				}
			}
		}

		#endregion

		#region MAPA II DO JOGO
		if (selecionarModo == SelectModo.Mundo_II)
		{

		}
		#endregion

	}

	void SetActiveMapa_I()
	{
		stars[0].SetActive(false);
		stars[1].SetActive(false);
		stars[2].SetActive(false);
	}
}

