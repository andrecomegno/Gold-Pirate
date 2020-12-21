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

		EstrelasMundo_I.gm.EstrelaMundoI ();
        //EstrelasMundo_II.gm.EstrelaMundoII();
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
