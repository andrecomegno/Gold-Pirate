using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum SelectScenes{
	intro, home, Mapa_I, Mapa_II
}

public class LevelMapa : MonoBehaviour
{
    public static LevelMapa gm;

    private string home = "Home";
    private string creditos = "Creditos";

    //VARIAVEIS DO PRIMEIRO MAPA DO JOGO
    private string MapaI = "Mapa I";
    private string episodioI_I = "Episodio I-I";
    private string episodioI_II = "Episodio I-II";
    private string episodioI_III = "Episodio I-III";
    private string episodioI_IV = "Episodio I-IV";
    private string episodioI_V = "Episodio I-V";
    private string episodioI_VI = "Episodio I-VI";
    private string episodioI_VII = "Episodio I-VII";
    private string episodioI_VIII = "Episodio I-VIII";
    private string episodioI_IX = "Episodio I-IX";
    private string episodioI_X = "Episodio I-X";

    //VARIAVEIS DO SEGUNDO MAPA DO JOGO
    private string MapaII = "Mapa II";
    private string episodioII_I = "Episodio II-I";
    private string episodioII_II = "Episodio II-II";
    private string episodioII_III = "Episodio II-III";
    private string episodioII_IV = "Episodio II-IV";
    private string episodioII_V = "Episodio II-V";
    private string episodioII_VI = "Episodio II-VI";
    private string episodioII_VII = "Episodio II-VII";
    private string episodioII_VIII = "Episodio II-VIII";
    private string episodioII_IX = "Episodio II-IX";
    private string episodioII_X = "Episodio II-X";

    public SelectScenes selectScenes;

    //VARIAVEIS DO PRIMEIRO MAP DO JOGO
    public GameObject Open1;
    public GameObject Open2;
    public GameObject Open3;
    public GameObject Open4;
    public GameObject Open5;
    public GameObject Open6;
    public GameObject Open7;
    public GameObject Open8;
    public GameObject Open9;
    public GameObject Open10;

    public GameObject Close2;
    public GameObject Close3;
    public GameObject Close4;
    public GameObject Close5;
    public GameObject Close6;
    public GameObject Close7;
    public GameObject Close8;
    public GameObject Close9;
    public GameObject Close10;

    private void Awake()
    {
        if (selectScenes == SelectScenes.Mapa_I)
        {
            PrimeiroMapa();
        }
    }


    void Start()
    {
        gm = this;
    }

    // LINHA DE COMANDO DOS BOTOES DO MUNDO 1
    #region
    public void EpisodioI_I()
    {
        SceneManager.LoadScene(episodioI_I);
        AudioBotaoClick();
    }

    public void EpisodioI_II()
    {
        SceneManager.LoadScene(episodioI_II);
        AudioBotaoClick();
    }

    public void EpisodioI_III()
    {
        SceneManager.LoadScene(episodioI_III);
        AudioBotaoClick();
    }

    public void EpisodioI_IV()
    {
        SceneManager.LoadScene(episodioI_IV);
        AudioBotaoClick();
    }

    public void EpisodioI_V()
    {
        SceneManager.LoadScene(episodioI_V);
        AudioBotaoClick();
    }

    public void EpisodioI_VI()
    {
        SceneManager.LoadScene(episodioI_VI);
        AudioBotaoClick();
    }

    public void EpisodioI_VII()
    {
        SceneManager.LoadScene(episodioI_VII);
        AudioBotaoClick();
    }

    public void EpisodioI_VIII()
    {
        SceneManager.LoadScene(episodioI_VIII);
        AudioBotaoClick();
    }

    public void EpisodioI_IX()
    {
        SceneManager.LoadScene(episodioI_IX);
        AudioBotaoClick();
    }

    public void EpisodioI_X()
    {
        SceneManager.LoadScene(episodioI_X);
        AudioBotaoClick();
    }

    #endregion

    // LINHA DE COMANDO BOTOES DOS MUNDOS
    public void Home()
    {
        SceneManager.LoadScene(home);
        AudioBotaoClick();
    }

    public void Mundo_I()
    {
        SceneManager.LoadScene(MapaI);
        AudioBotaoClick();
    }

    public void Mundo_II()
    {
        SceneManager.LoadScene(MapaII);
        AudioBotaoClick();
    }

    // Linha de comando Tela Inicio
    #region
    public void PlayerGame()
    {
        SceneManager.LoadScene(MapaI);
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
        if (Open1 == null)
        {
            Open1 = GameObject.Find("Open1");
            Open1.SetActive(true);
        }
        else
        {
            Open1.SetActive(true);
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

        if (Open10 == null)
        {
            Open10 = GameObject.Find("Open10");
            Open10.SetActive(false);
        }
        else
        {
            Open9.SetActive(false);
        }

        // LINHA DE COMANDO DAS FASES FECHADAS
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

        if (Close10 == null)
        {
            Close10 = GameObject.Find("Close10");
            Close10.SetActive(true);
        }
        else
        {
            Close10.SetActive(true);
        }
    }

    // LINHA DE COMANDO DO EFEITOS DO SOM - SCRIPT AUDIO DO JOGO
    void AudioBotaoClick() {
        AudiosDoJogo.gm.Click(); 
    }
}