using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiosDoJogo : MonoBehaviour {
    public static AudiosDoJogo gm;

    public AudioSource audioSource;
    public AudioClip[] click;

    private void Awake()
    {
        // LINHA DE COMANDO QUE NAO DESTROI O SCRIPT NO LOAD DE UMA NOVA CENA
        if(gm == null)
        {
            gm = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    void Start () {
        audioSource = GetComponent<AudioSource>();
    }

    public void Click() {
        audioSource.clip = click[Random.Range(0, click.Length)];
        audioSource.Play();        
    }

}
