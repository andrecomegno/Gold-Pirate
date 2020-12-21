using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour {

    public static MenuInGame gm;

    private string Mapa_I = "Mapa I";
	private string Mapa_II = "Mapa II";
	private string Home = "Home";
	public bool _pause = false;

	public int cronometroTime = 0;

	public GameObject Menus;
    public GameObject MenuPrincipal;
	public GameObject MissaoCompleta;
	public GameObject MissaoFracassada;
	public GameObject GamePause;
    public GameObject TouchScreen;

    public bool fracassou = false;
    public bool completou = false;

	void Awake(){
        gm = this;
        Menus = GameObject.Find ("Menus");
        MenuPrincipal = GameObject.Find("Menus/MenuJogo");
        MissaoCompleta = GameObject.Find ("Menus/MissaoCompleta");
		MissaoFracassada = GameObject.Find ("Menus/MissaoFracassada");
        GamePause = GameObject.Find("Canvas/Pause");
        TouchScreen = GameObject.Find("Canvas/Touch Screen");
    }

	void Start(){
        Menus.SetActive(false);
        MissaoCompleta.SetActive (false);
     	MissaoFracassada.SetActive (false);
	}

	// LINHA DE COMANDO DOS BOTOES JOGAR NOVAMENTE TODOS OS MUNDOS
    public void BotaoNovamenteEpisodio() {
        // LINHA DE COMANDO QUE DA O REOLOAD NA CENA
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // LINHA DE COMANDO QUE RESETA AS MOEDAS PARA 0 QUANDO INICIA UM NOVO JOGO
        Time.timeScale = 1.0f;

        // LINHA DE COMANDO QUE RESETA O TEMPO CASO ESTEJA EM MODO PAUSE NO GAME;
        Mundos.gm.coins = 0; 
    }

	public void BotaoMundoUm(){
		SceneManager.LoadScene(Mapa_I);
		Time.timeScale = 1.0f; 
	}

	public void BotaoMundoDois(){
		SceneManager.LoadScene(Mapa_II);
		Time.timeScale = 1.0f; 	
	}

	public void ButtonSair(){
		SceneManager.LoadScene(Home);
		Time.timeScale = 1.0f;
//		Debug.Log("Sair");		
	}

	// LINHA DE COMANDO DO PAUSE DO JOGO
	public void ButtonPause(){
		if (_pause = !_pause) {
            Menus.gameObject.SetActive (true);
            TouchScreen.SetActive(false);
        } else {
            Menus.gameObject.SetActive (false);
            TouchScreen.SetActive(true);
        }	

		PauseLogic ();
	}

	// LINHA DE COMANDO QUE PARA O TEMPO
	public void PauseLogic(){
		if (Time.timeScale == 1.0f){ 
			Time.timeScale = 0f;
		}
		else{
			Time.timeScale = 1.0f;
		}		
	}

	public void CompleteiMissao(){
        if (!completou)
        {
            completou = true;

            MenuPrincipal.SetActive(false);
            MissaoFracassada.SetActive(false);

            StartCoroutine(Wait(Menus, 2f));

            // LINHA DE COMANDO DESABILITA O CONTROLE DO JOGO
            TouchScreen.SetActive(false);

            // LINHA DE COMANDO DESABILITA O POUSE DO JOGO
            GamePause.SetActive(false); 

            StartCoroutine(Wait(MissaoCompleta, 4f));
        }
	}

	public void FracassouMissao(){
        if (!fracassou)
        {
            fracassou = true;

            MenuPrincipal.SetActive(false);
            MissaoCompleta.SetActive(false);
            TouchScreen.SetActive(false);

            StartCoroutine(Wait(Menus, 2f));

            // LINHA DE COMANDO DESABILITA O CRONOMETRO DO JOGO
            Cronometro.gm.stopCronometro = true;

            GamePause.SetActive(false);

            StartCoroutine(Wait(MissaoFracassada, 4f));
        }
    }

    public IEnumerator Wait(GameObject OnOff, float time)
    {
        yield return new WaitForSeconds(time);
        OnOff.SetActive(true);        
    }



}
