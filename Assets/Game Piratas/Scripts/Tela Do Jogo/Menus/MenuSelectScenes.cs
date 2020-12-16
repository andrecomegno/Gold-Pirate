using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum SelectScenes{
	intro, home, MapaUm
}

public class MenuSelectScenes : MonoBehaviour
{
    public static MenuSelectScenes gm;

    private string home = "Home";
    private string creditos = "Creditos";

    //VARIAVEIS DO PRIMEIRO MAP DO JOGO
    private string MapaUm = "MapaUm";
    private string episodio0 = "Episodio0";
    private string episodioI = "EpisodioI";
    private string episodioII = "EpisodioII";
    private string episodioIII = "EpisodioIII";
    private string episodioIV = "EpisodioIV";
    private string episodioV = "EpisodioV";
    private string episodioVI = "EpisodioVI";
    private string episodioVII = "EpisodioVII";
    private string episodioVIII = "EpisodioVIII";
    private string episodioIX = "EpisodioIX";

    public SelectScenes selectScenes;

    //VARIAVEIS DO PRIMEIRO MAP DO JOGO
    public GameObject Open0;
    public GameObject Open1;
    public GameObject Open2;
    public GameObject Open3;
    public GameObject Open4;
    public GameObject Open5;
    public GameObject Open6;
    public GameObject Open7;
    public GameObject Open8;
    public GameObject Open9;

    public GameObject Close1;
    public GameObject Close2;
    public GameObject Close3;
    public GameObject Close4;
    public GameObject Close5;
    public GameObject Close6;
    public GameObject Close7;
    public GameObject Close8;
    public GameObject Close9;

    // Use this for initialization
    void Start()
    {
        gm = this;

        if (selectScenes == SelectScenes.MapaUm)
        {
            PrimeiroMapa();
        }
    }

    // LINHA DE COMANDO DOS BOTOES DO MUNDO 1
    #region
    public void Episodio0()
    {
        SceneManager.LoadScene(episodio0);
        AudioBotaoClick();
    }

    public void EpisodioI()
    {
        SceneManager.LoadScene(episodioI);
        AudioBotaoClick();
    }

    public void EpisodioII()
    {
        SceneManager.LoadScene(episodioII);
        AudioBotaoClick();
    }

    public void EpisodioIII()
    {
        SceneManager.LoadScene(episodioIII);
        AudioBotaoClick();
    }

    public void EpisodioIV()
    {
        SceneManager.LoadScene(episodioIV);
        AudioBotaoClick();
    }

    public void EpisodioV()
    {
        SceneManager.LoadScene(episodioV);
        AudioBotaoClick();
    }

    public void EpisodioVI()
    {
        SceneManager.LoadScene(episodioVI);
        AudioBotaoClick();
    }

    public void EpisodioVII()
    {
        SceneManager.LoadScene(episodioVII);
        AudioBotaoClick();
    }

    public void EpisodioVIII()
    {
        SceneManager.LoadScene(episodioVIII);
        AudioBotaoClick();
    }

    public void EpisodioIX()
    {
        SceneManager.LoadScene(episodioIX);
        AudioBotaoClick();
    }

    #endregion

    // LINHA DE COMANDO BOTOES DOS MUNDOS
    public void Voltar()
    {
        SceneManager.LoadScene(home);
        AudioBotaoClick();
    }

    public void VoltarMundoUm()
    {
        SceneManager.LoadScene(MapaUm);
        AudioBotaoClick();
    }

    // Linha de comando Tela Inicio
    #region
    public void PlayerGame()
    {
        SceneManager.LoadScene(MapaUm);
        AudioBotaoClick();
    }

    public void Creditos()
    {
        SceneManager.LoadScene(creditos);
        AudioBotaoClick();
    }

    public void Sair()
    {
        Application.Quit();
        AudioBotaoClick();
    }
    #endregion

    // Linha de comando que muda de cena apresentaçao para inicio
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(home);
    }

    // LINHA DE COMANDO DO PRIMEIRO MAP DO JOGO
    void PrimeiroMapa()
    {
        // LINHA DE COMANDO FASES ABERTAS
        if (Open0 == null)
        {
            Open0 = GameObject.Find("Open0");
            Open0.SetActive(true);
        }
        else
        {
            Open0.SetActive(true);
        }

        if (Open1 == null)
        {
            Open1 = GameObject.Find("Open1");
            Open1.SetActive(false);
        }
        else
        {
            Open1.SetActive(false);
        }

        if (Open2 == null)
        {
            Open2 = GameObject.Find("Open2");
            Open2.SetActive(false);
        }
        else
        {
            Open2.SetActive(false);
        }

        if (Open3 == null)
        {
            Open3 = GameObject.Find("Open3");
            Open3.SetActive(false);
        }
        else
        {
            Open3.SetActive(false);
        }

        if (Open4 == null)
        {
            Open4 = GameObject.Find("Open4");
            Open4.SetActive(false);
        }
        else
        {
            Open4.SetActive(false);
        }

        if (Open5 == null)
        {
            Open5 = GameObject.Find("Open5");
            Open5.SetActive(false);
        }
        else
        {
            Open5.SetActive(false);
        }

        if (Open6 == null)
        {
            Open6 = GameObject.Find("Open6");
            Open6.SetActive(false);
        }
        else
        {
            Open6.SetActive(false);
        }

        if (Open7 == null)
        {
            Open7 = GameObject.Find("Open7");
            Open7.SetActive(false);
        }
        else
        {
            Open7.SetActive(false);
        }

        if (Open8 == null)
        {
            Open8 = GameObject.Find("Open8");
            Open8.SetActive(false);
        }
        else
        {
            Open8.SetActive(false);
        }

        if (Open9 == null)
        {
            Open9 = GameObject.Find("Open9");
            Open9.SetActive(false);
        }
        else
        {
            Open9.SetActive(false);
        }

        // LINHA DE COMANDO DAS FASES FECHADAS
        if (Close1 == null)
        {
            Close1 = GameObject.Find("Close1");
            Close1.SetActive(true);
        }
        else
        {
            Close1.SetActive(true);
        }

        if (Close2 == null)
        {
            Close2 = GameObject.Find("Close2");
            Close2.SetActive(true);
        }
        else
        {
            Close2.SetActive(true);
        }

        if (Close3 == null)
        {
            Close3 = GameObject.Find("Close3");
            Close3.SetActive(true);
        }
        else
        {
            Close3.SetActive(true);
        }

        if (Close4 == null)
        {
            Close4 = GameObject.Find("Close4");
            Close4.SetActive(true);
        }
        else
        {
            Close4.SetActive(true);
        }

        if (Close5 == null)
        {
            Close5 = GameObject.Find("Close5");
            Close5.SetActive(true);
        }
        else
        {
            Close5.SetActive(true);
        }

        if (Close6 == null)
        {
            Close6 = GameObject.Find("Close6");
            Close6.SetActive(true);
        }
        else
        {
            Close6.SetActive(true);
        }

        if (Close7 == null)
        {
            Close7 = GameObject.Find("Close7");
            Close7.SetActive(true);
        }
        else
        {
            Close7.SetActive(true);
        }

        if (Close8 == null)
        {
            Close8 = GameObject.Find("Close8");
            Close8.SetActive(true);
        }
        else
        {
            Close8.SetActive(true);
        }

        if (Close9 == null)
        {
            Close9 = GameObject.Find("Close9");
            Close9.SetActive(true);
        }
        else
        {
            Close9.SetActive(true);
        }
    }

    // LINHA DE COMANDO DO EFEITOS DO SOM - SCRIPT AUDIO DO JOGO
    void AudioBotaoClick() {
        AudiosDoJogo.gm.Click(); 
    }
}