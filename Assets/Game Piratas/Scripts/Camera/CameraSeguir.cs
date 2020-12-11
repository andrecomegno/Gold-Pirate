using UnityEngine;
using System.Collections;

public class CameraSeguir : MonoBehaviour {

    public enum SelecionarCamera
    {
        Name, pirata, papagaio, pirataTransfo, papagaioTransfo, canhao
    }

    public SelecionarCamera minhacamera;
    public static CameraSeguir gm;

    public Transform pirata;
    public Transform papagaio;
    public Transform canhao;

    private float smoothTime = 0.3F;
	private float yVelocity = 0.0F;

    void Start()
    {
        gm = this;       
        minhacamera = SelecionarCamera.pirata;
    }

    void Update()
    {
        CameraLogic();
    }

    void CameraLogic()
    {
        switch (minhacamera)
        {
            case SelecionarCamera.pirata:
                CameraPirata();
                break;

            case SelecionarCamera.papagaio:
                CameraPapagaio();
                break;

            case SelecionarCamera.canhao:
                CameraCanhao();
                break;

            case SelecionarCamera.pirataTransfo:
                StartCoroutine(CameraPirataTransfo());                
                break;

            case SelecionarCamera.papagaioTransfo:
                StartCoroutine(CameraPapagaioTransfo());                
                break;               
        }
    }

    void CameraPirata()
    {
        pirata = GameObject.FindWithTag("Pirata").transform;

        // LINHA QUE PEGA A POSISÇAO DO PIRATA PARA SEGUIR 
        float newPosition = Mathf.SmoothDamp(transform.position.y, pirata.position.y, ref yVelocity, smoothTime);
        transform.position = new Vector3(pirata.position.x, newPosition, transform.position.z);
    }

    void CameraPapagaio()
    {
        papagaio = GameObject.FindWithTag("Papagaio").transform;

        // LINHA QUE PEGA A POSISÇAO DO PIRATA PARA SEGUIR
        float newPosition = Mathf.SmoothDamp(transform.position.y, papagaio.position.y, ref yVelocity, smoothTime);
        transform.position = new Vector3(papagaio.position.x, newPosition, transform.position.z);
    }

    void CameraCanhao()
    {
        canhao = GameObject.FindWithTag("Canhao").transform;

        // PROCURA A TAG CANHAO PARA FIXAR A CAMERA QUANDO O PIRATA ENTRA NO CANHAO
        float newPosition = Mathf.SmoothDamp(transform.position.y, canhao.position.y, ref yVelocity, smoothTime);
        transform.position = new Vector3(canhao.position.x, newPosition, transform.position.z);
    }

    IEnumerator CameraPirataTransfo()
    {
        yield return new WaitForSeconds(1);
        pirata = GameObject.FindWithTag("Pirata").transform;

        // LINHA QUE PEGA A POSISÇAO DO PIRATA PARA SEGUIR 
        float newPosition = Mathf.SmoothDamp(transform.position.y, pirata.position.y, ref yVelocity, smoothTime);
        transform.position = new Vector3(pirata.position.x, newPosition, transform.position.z);

        yield return new WaitForSeconds(0.2f);
        minhacamera = SelecionarCamera.pirata ;
    }

    IEnumerator CameraPapagaioTransfo()
    {
        yield return new WaitForSeconds(1);
        papagaio = GameObject.FindWithTag("Papagaio").transform;

        // LINHA QUE PEGA A POSISÇAO DO PIRATA PARA SEGUIR
        float newPosition = Mathf.SmoothDamp(transform.position.y, papagaio.position.y, ref yVelocity, smoothTime);
        transform.position = new Vector3(papagaio.position.x, newPosition, transform.position.z);

        yield return new WaitForSeconds(0.2f);
        minhacamera = SelecionarCamera.papagaio;
    }

}
