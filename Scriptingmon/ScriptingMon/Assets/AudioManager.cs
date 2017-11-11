using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    AudioSource audioSource;
    [SerializeField] AudioClip Atacar;
    [SerializeField] AudioClip Vida;
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    public void PlayAtacar()
    {
        audioSource.clip = Atacar;
        audioSource.Play();
    }

    public void PlayVida()
    {
        audioSource.clip = Vida;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
