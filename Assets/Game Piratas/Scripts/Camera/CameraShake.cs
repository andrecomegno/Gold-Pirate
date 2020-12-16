using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public static CameraShake gm;
    public Camera mainCam;
    public float shakeAmount = 0;

    void Awake()
    {
        if (mainCam == null)
        {
            mainCam = Camera.main;
        }
    }

    void Start()
    {
        gm = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Shake(0.1f, 0.2f);
        }
    }

    // LINHA DE COMANDO QUE FAZ COM QUE A CAMERA CHAQUALE
    public void Shake(float amt, float leagth)
    {
        shakeAmount = amt;
        InvokeRepeating("BeginShake", 0, 0.1f);
        Invoke("StopShake", leagth);
    }

    // LINHA DE COMANDO QUE COMEÇA O SHAKE
    void BeginShake()
    {
        if(shakeAmount > 0)
        {
            Vector3 camPos = mainCam.transform.position;

            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += offsetX;
            camPos.y += offsetY;

            mainCam.transform.position = camPos;
        }
    }

    //LINHA DE COMANDO QUE PARA O SHAKE
    void StopShake()
    {
        CancelInvoke("BeginShake");
        mainCam.transform.localPosition = Vector3.zero;
    }
}
