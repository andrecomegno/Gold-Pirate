using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa_I : MonoBehaviour
{
	private MenuSelectScenes menuSelectScenes;

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

	private GameObject Star_10_0;
	private GameObject Star_10_1;
	private GameObject Star_10_2;

	public static Mapa_I gm;

	private void Awake()
    {
		// LINHA DE COMANDO QUE PROCURA O SCRITP MenuSelectScenes VINCULADO NO MAPA 1
		menuSelectScenes = GameObject.Find("Mapa I").GetComponent<MenuSelectScenes>();
		gm = this;
	}

    public void HabilitarFase ()
    {
		// LINHA DE COMANDO QUE VERIFICA SE A STAR_1_1 OU STAR 1_2 ESTA HABILITADO COMO TRUE
		if (Star_1_1.activeSelf == true || Star_1_2.activeSelf == true)
		{

			// LINHA DE COMANDO QUE HABILITA A FASE 2 DO MUNDO I
			menuSelectScenes.Open2.SetActive(true);
			menuSelectScenes.Close2.SetActive(false);
		}

		if (Star_2_1.activeSelf == true || Star_2_2.activeSelf == true)
		{
			menuSelectScenes.Open3.SetActive(true);
			menuSelectScenes.Close3.SetActive(false);
		}

		if (Star_3_1.activeSelf == true || Star_3_2.activeSelf == true)
		{
			menuSelectScenes.Open4.SetActive(true);
			menuSelectScenes.Close4.SetActive(false);
		}

		if (Star_4_1.activeSelf == true || Star_4_2.activeSelf == true)
		{
			menuSelectScenes.Open5.SetActive(true);
			menuSelectScenes.Close5.SetActive(false);
		}

		if (Star_5_1.activeSelf == true || Star_5_2.activeSelf == true)
		{
			menuSelectScenes.Open6.SetActive(true);
			menuSelectScenes.Close6.SetActive(false);
		}

		if (Star_6_1.activeSelf == true || Star_6_2.activeSelf == true)
		{
			menuSelectScenes.Open7.SetActive(true);
			menuSelectScenes.Close7.SetActive(false);
		}

		if (Star_7_1.activeSelf == true || Star_7_2.activeSelf == true)
		{
			menuSelectScenes.Open8.SetActive(true);
			menuSelectScenes.Close8.SetActive(false);
		}

		if (Star_8_1.activeSelf == true || Star_8_2.activeSelf == true)
		{
			menuSelectScenes.Open9.SetActive(true);
			menuSelectScenes.Close9.SetActive(false);
		}

		if (Star_9_1.activeSelf == true || Star_9_2.activeSelf == true)
		{
			menuSelectScenes.Open10.SetActive(true);
			menuSelectScenes.Close10.SetActive(false);
		}

		if (Star_10_1.activeSelf == true || Star_10_2.activeSelf == true)
		{
			// HABILITA O MAPA 2
		}
	}

	public void Level_1 () {
		/* LINHA DE COMANDO QUE PEGA A VARIAVEL STAR_1_0 PARA HABILITAR UMA ESTRELA NO JOGO
		 * ESSE COMANDO PlayerPrefs.HasKey ESTA SENDO SALVO NO SCRITP EtrelaMundo_I.CS */

		if (PlayerPrefs.HasKey("Star_1_0"))
		{
			// MOSTRA UMA ESTRELA NO JOGO
			Star_1_0.SetActive(true);
		}
		if (PlayerPrefs.HasKey("Star_1_1"))
		{
			// MOSTRA DUAS ESTRELA NO JOGO
			Star_1_1.SetActive(true);
		}
		if (PlayerPrefs.HasKey("Star_1_2"))
		{
			// TRÊS ESTRELA NO JOGO
			Star_1_2.SetActive(true);
		}
	}

	public void Level_2 ()
    {
		if (PlayerPrefs.HasKey("Star_2_0"))
		{
			Star_2_0.SetActive(true);
		}
		if (PlayerPrefs.HasKey("Star_2_1"))
		{
			Star_2_1.SetActive(true);
		}
		if (PlayerPrefs.HasKey("Star_2_2"))
		{
			Star_2_2.SetActive(true);
		}
	}

	public void Level_3()
    {
		if (PlayerPrefs.HasKey("Star_3_0"))
		{
			Star_3_0.SetActive(true);
		}
		if (PlayerPrefs.HasKey("Star_3_1"))
		{
			Star_3_1.SetActive(true);
		}
		if (PlayerPrefs.HasKey("Star_3_2"))
		{
			Star_3_2.SetActive(true);
		}
	}

	public void Level_4()
    {
		if (PlayerPrefs.HasKey("Star_4_0"))
		{
			Star_4_0.SetActive(true);
		}
		if (PlayerPrefs.HasKey("Star_4_1"))
		{
			Star_4_1.SetActive(true);
		}
		if (PlayerPrefs.HasKey("Star_4_2"))
		{
			Star_4_2.SetActive(true);
		}
	}

	public void Level_5()
    {
		if (PlayerPrefs.HasKey("Star_5_0"))
		{
			Star_5_0.SetActive(true);
		}
		if (PlayerPrefs.HasKey("Star_5_1"))
		{
			Star_5_1.SetActive(true);
		}
		if (PlayerPrefs.HasKey("Star_5_2"))
		{
			Star_5_2.SetActive(true);
		}
	}

	public void Level_6()
	{
		if (PlayerPrefs.HasKey("Star_6_0"))
		{
			Star_6_0.SetActive(true);
		}
		if (PlayerPrefs.HasKey("Star_6_1"))
		{
			Star_6_1.SetActive(true);
		}
		if (PlayerPrefs.HasKey("Star_6_2"))
		{
			Star_6_2.SetActive(true);
		}
	}

	public void Level_7()
	{
		if (PlayerPrefs.HasKey("Star_7_0"))
		{
			Star_7_0.SetActive(true);
		}
		if (PlayerPrefs.HasKey("Star_7_1"))
		{
			Star_7_1.SetActive(true);
		}
		if (PlayerPrefs.HasKey("Star_7_2"))
		{
			Star_7_2.SetActive(true);
		}
	}

	public void Level_8()
	{
		if (PlayerPrefs.HasKey("Star_8_0"))
		{
			Star_8_0.SetActive(true);
		}
		if (PlayerPrefs.HasKey("Star_8_1"))
		{
			Star_8_1.SetActive(true);
		}
		if (PlayerPrefs.HasKey("Star_8_2"))
		{
			Star_8_2.SetActive(true);
		}
	}

	public void Level_9()
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

	public void Level_10()
	{
		if (PlayerPrefs.HasKey("Star_10_0"))
		{
			Star_10_0.SetActive(true);
		}
		if (PlayerPrefs.HasKey("Star_10_1"))
		{
			Star_10_1.SetActive(true);
		}
		if (PlayerPrefs.HasKey("Star_10_2"))
		{
			Star_10_2.SetActive(true);
		}
	}

	public void OpenFindMapa ()
	{
		Star_1_0 = GameObject.Find("Open1/Estrelas/1");
		Star_1_1 = GameObject.Find("Open1/Estrelas/2");
		Star_1_2 = GameObject.Find("Open1/Estrelas/3");

		Star_2_0 = GameObject.Find("Open2/Estrelas/1");
		Star_2_1 = GameObject.Find("Open2/Estrelas/2");
		Star_2_2 = GameObject.Find("Open2/Estrelas/3");

		Star_3_0 = GameObject.Find("Open3/Estrelas/1");
		Star_3_1 = GameObject.Find("Open3/Estrelas/2");
		Star_3_2 = GameObject.Find("Open3/Estrelas/3");

		Star_4_0 = GameObject.Find("Open4/Estrelas/1");
		Star_4_1 = GameObject.Find("Open4/Estrelas/2");
		Star_4_2 = GameObject.Find("Open4/Estrelas/3");

		Star_5_0 = GameObject.Find("Open5/Estrelas/1");
		Star_5_1 = GameObject.Find("Open5/Estrelas/2");
		Star_5_2 = GameObject.Find("Open5/Estrelas/3");

		Star_6_0 = GameObject.Find("Open6/Estrelas/1");
		Star_6_1 = GameObject.Find("Open6/Estrelas/2");
		Star_6_2 = GameObject.Find("Open6/Estrelas/3");

		Star_7_0 = GameObject.Find("Open7/Estrelas/1");
		Star_7_1 = GameObject.Find("Open7/Estrelas/2");
		Star_7_2 = GameObject.Find("Open7/Estrelas/3");

		Star_8_0 = GameObject.Find("Open8/Estrelas/1");
		Star_8_1 = GameObject.Find("Open8/Estrelas/2");
		Star_8_2 = GameObject.Find("Open8/Estrelas/3");

		Star_9_0 = GameObject.Find("Open9/Estrelas/1");
		Star_9_1 = GameObject.Find("Open9/Estrelas/2");
		Star_9_2 = GameObject.Find("Open9/Estrelas/3");

		Star_10_0 = GameObject.Find("Open9/Estrelas/1");
		Star_10_1 = GameObject.Find("Open9/Estrelas/2");
		Star_10_2 = GameObject.Find("Open9/Estrelas/3");
	}

	public void SetActiveMapa ()
	{
		Star_1_0.SetActive(false);
		Star_1_1.SetActive(false);
		Star_1_2.SetActive(false);

		Star_2_0.SetActive(false);
		Star_2_1.SetActive(false);
		Star_2_2.SetActive(false);

		Star_3_0.SetActive(false);
		Star_3_1.SetActive(false);
		Star_3_2.SetActive(false);

		Star_4_0.SetActive(false);
		Star_4_1.SetActive(false);
		Star_4_2.SetActive(false);

		Star_5_0.SetActive(false);
		Star_5_1.SetActive(false);
		Star_5_2.SetActive(false);

		Star_6_0.SetActive(false);
		Star_6_1.SetActive(false);
		Star_6_2.SetActive(false);

		Star_7_0.SetActive(false);
		Star_7_1.SetActive(false);
		Star_7_2.SetActive(false);

		Star_8_0.SetActive(false);
		Star_8_1.SetActive(false);
		Star_8_2.SetActive(false);

		Star_9_0.SetActive(false);
		Star_9_1.SetActive(false);
		Star_9_2.SetActive(false);

		Star_10_0.SetActive(false);
		Star_10_1.SetActive(false);
		Star_10_2.SetActive(false);
	}
}
