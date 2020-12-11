using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SelecionarCanhoes
{
    PirataCanhaoEsquerdo, PirataCanhaoDireito, PirataCanhaoFrente
}

public class PirataCanhao : MonoBehaviour
{

    public static PirataCanhao gm;
    public SelecionarCanhoes selecionarCanhoes;

    private Animator anima;
    public GameObject Pirata;

    public bool canhao; // VARIAVEL QUE VERIFICA SE ENTROU DENTRO OU SAIU DO OnTrigger

    //VARIAVEL DO INSTATIATE
    public GameObject ClonePirata;
    public GameObject clo;
    public GameObject Tag; // VARIAVEL PRESISOU PARA CRIAR A TAG CANHAO EM UM GameObject EM VEZ DO OBJETO EM SI
    public Transform myTransform;

    public GameObject canhao0;
    public GameObject canhao1;
    public GameObject canhao2;
    public GameObject canhao3;
    public GameObject canhao4;
    public GameObject canhao5;
    public GameObject canhao6;
    public GameObject canhao7;

    public int contar;

    void Start()
    {
        gm = this;
        anima = GetComponent<Animator>();
        Tag.SetActive(false);
    }

    // O PIRATA TAG FOI COLOCADO NO FIXEDUPDATE PARA UMA MELHOR PERFORMACE
    void FixedUpdate()
    {
        Pirata = GameObject.FindWithTag("Pirata");
    }

    //LINHA DE COMANDO ADICIONADA NO DISPARO ANIMAÇAO DO CANHAO ADD EVENT, SOMENTE Pirata Canhao Padrao
    void DisparoCanhao()
    {
        if (selecionarCanhoes == SelecionarCanhoes.PirataCanhaoFrente)
        {
            clo = Instantiate(ClonePirata, myTransform.position, myTransform.rotation) as GameObject;
            CameraShake.gm.Shake(0.2f, 0.4f);
            PirataControle.gm.facingRight = true;
        }

        if (selecionarCanhoes == SelecionarCanhoes.PirataCanhaoEsquerdo)
        {
            clo = Instantiate(ClonePirata, myTransform.position, myTransform.rotation) as GameObject;
            CameraShake.gm.Shake(0.2f, 0.4f);
            PirataControle.gm.facingRight = false;
        }

        if (selecionarCanhoes == SelecionarCanhoes.PirataCanhaoDireito)
        {
            clo = Instantiate(ClonePirata, myTransform.position, myTransform.rotation) as GameObject;
            CameraShake.gm.Shake(0.2f, 0.4f);
            PirataControle.gm.facingRight = true;
        }
    }

    // LINHA DE COMANDO QUE DIFERENCIA VARIOS CANHOES NA MESMA FASE, COLOCANDO UMA INT PARA CONTAR OS CANHOES E DIFERENCIAR ENTRE ELES
    void CanhaoLogic()
    {
        if (contar == 0)
        {
            canhao0.SetActive(true);
            
            // LINHA DE COMANDO FOI CRIADO PARA NAO EXIBIR O ERRO CASO NAO EXISTA OS CANHOES 1 ETC
            if (canhao1 == null)
            {
                return;
            }
            else
            {
                canhao1.SetActive(false);
            }

            if (canhao2 == null)
            {
                return;
            }
            else
            {
                canhao2.SetActive(false);
            }

            if (canhao3 == null)
            {
                return;
            }
            else
            {
                canhao3.SetActive(false);
            }

            if (canhao4 == null)
            {
                return;
            }
            else
            {
                canhao4.SetActive(false);
            }

            if (canhao5 == null)
            {
                return;
            }
            else
            {
                canhao5.SetActive(false);
            }

            if (canhao6 == null)
            {
                return;
            }
            else
            {
                canhao6.SetActive(false);
            }

            if (canhao7 == null)
            {
                return;
            }
            else
            {
                canhao7.SetActive(false);
            }
        }

        if (contar == 1)
        {
            canhao0.SetActive(false);

            canhao1.SetActive(true);

            if (canhao2 == null)
            {
                return;
            }
            else
            {
                canhao2.SetActive(false);
            }

            if (canhao3 == null)
            {
                canhao3 = null;
                return;
            }
            else
            {
                canhao3.SetActive(false);
            }

            if (canhao4 == null)
            {
                return;
            }
            else
            {
                canhao4.SetActive(false);
            }

            if (canhao5 == null)
            {
                return;
            }
            else
            {
                canhao5.SetActive(false);
            }

            if (canhao6 == null)
            {
                return;
            }
            else
            {
                canhao6.SetActive(false);
            }

            if (canhao7 == null)
            {
                return;
            }
            else
            {
                canhao7.SetActive(false);
            }
        }

        if (contar == 2)
        {
            canhao0.SetActive(false);
            canhao1.SetActive(false);

            canhao2.SetActive(true);

            if (canhao3 == null)
            {
                canhao3 = null;
                return;
            }
            else
            {
                canhao3.SetActive(false);
            }

            if (canhao4 == null)
            {
                return;
            }
            else
            {
                canhao4.SetActive(false);
            }

            if (canhao5 == null)
            {
                return;
            }
            else
            {
                canhao5.SetActive(false);
            }

            if (canhao6 == null)
            {
                return;
            }
            else
            {
                canhao6.SetActive(false);
            }

            if (canhao7 == null)
            {
                return;
            }
            else
            {
                canhao7.SetActive(false);
            }
        }

        if (contar == 3)
        {
            canhao0.SetActive(false);
            canhao1.SetActive(false);
            canhao2.SetActive(false);

            canhao3.SetActive(true);

            if (canhao4 == null)
            {
                return;
            }
            else
            {
                canhao4.SetActive(false);
            }

            if (canhao5 == null)
            {
                return;
            }
            else
            {
                canhao5.SetActive(false);
            }

            if (canhao6 == null)
            {
                return;
            }
            else
            {
                canhao6.SetActive(false);
            }

            if (canhao7 == null)
            {
                return;
            }
            else
            {
                canhao7.SetActive(false);
            }
        }

        if (contar == 4)
        {
            canhao0.SetActive(false);
            canhao1.SetActive(false);
            canhao2.SetActive(false);
            canhao3.SetActive(false);

            canhao4.SetActive(true);

            if (canhao5 == null)
            {
                return;
            }
            else
            {
                canhao5.SetActive(false);
            }

            if (canhao6 == null)
            {
                return;
            }
            else
            {
                canhao6.SetActive(false);
            }

            if (canhao7 == null)
            {
                return;
            }
            else
            {
                canhao7.SetActive(false);
            }
        }

        if (contar == 5)
        {
            canhao0.SetActive(false);
            canhao1.SetActive(false);
            canhao2.SetActive(false);
            canhao3.SetActive(false);
            canhao4.SetActive(false);

            canhao5.SetActive(true);

            if (canhao6 == null)
            {
                return;
            }
            else
            {
                canhao6.SetActive(false);
            }

            if (canhao7 == null)
            {
                return;
            }
            else
            {
                canhao7.SetActive(false);
            }
        }

        if (contar == 6)
        {
            canhao0.SetActive(false);
            canhao1.SetActive(false);
            canhao2.SetActive(false);
            canhao3.SetActive(false);
            canhao4.SetActive(false);
            canhao5.SetActive(false);

            canhao6.SetActive(true);

            if (canhao7 == null)
            {
                return;
            }
            else
            {
                canhao7.SetActive(false);
            }
        }

        if (contar == 7)
        {
            canhao0.SetActive(false);
            canhao1.SetActive(false);
            canhao2.SetActive(false);
            canhao3.SetActive(false);
            canhao4.SetActive(false);
            canhao5.SetActive(false);
            canhao6.SetActive(false);

            canhao7.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Pirata"))
        {
            // LINHA DE COMANDO QUE DESABILITA O MENU TOUCH, QUANDO ESTIVER VOANDO 
            MenuInGame.gm.TouchScreen.SetActive(false);

            // VARIAVEL canhao NECESSARIA PARA DIFERENCIAR CADA COLLIDER
            if (selecionarCanhoes == SelecionarCanhoes.PirataCanhaoFrente && !canhao) 
            {
                // O GAMEOBJECT TAG E PIRATA TEM QUE SER OS PRIMEIROS A SER LIDO PARA
                // PODER TER FUNCIONALIDADE DA TROCA DE CAMERA. O THIS EM PITATA TER QUE TER PARA DESTROIR SOMENTE ELE MESMO
                Tag.SetActive(true);  
                Destroy(this.Pirata); 

                PirataControle.gm.voar = true;
                anima.SetBool("Disparo", true);

                CameraSeguir.gm.minhacamera = CameraSeguir.SelecionarCamera.canhao;
                canhao = true;
                CanhaoLogic();
            }

            if (selecionarCanhoes == SelecionarCanhoes.PirataCanhaoEsquerdo && !canhao)
            {
                Tag.SetActive(true);
                Destroy(this.Pirata); 

                PirataControle.gm.voar = true;
                anima.SetBool("Disparo", true);

                CameraSeguir.gm.minhacamera = CameraSeguir.SelecionarCamera.canhao;
                canhao = true;
                CanhaoLogic();
            }

            if (selecionarCanhoes == SelecionarCanhoes.PirataCanhaoDireito && !canhao)
            {
                Tag.SetActive(true);
                Destroy(this.Pirata);

                PirataControle.gm.voar = true;
                anima.SetBool("Disparo", true);

                CameraSeguir.gm.minhacamera = CameraSeguir.SelecionarCamera.canhao;
                canhao = true;
                CanhaoLogic();
            }
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Pirata"))
        {
            Tag.SetActive(false);
            anima.SetBool("Disparo", false);

            CameraSeguir.gm.minhacamera = CameraSeguir.SelecionarCamera.pirata;
            canhao = false;
        }
    }
}
