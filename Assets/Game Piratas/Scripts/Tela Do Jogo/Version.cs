using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Version : MonoBehaviour
{
    public static Version gm;

    private void Awake()
    {
        // LINHA DE COMANDO QUE NAO DESTROI O SCRIPT NO LOAD DE UMA NOVA CENA
        if (gm == null)
        {
            gm = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
}
