﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{
    Vector3 posA;
    Vector3 posB;
    Vector3 newPosition;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    GameObject ModoDeJuego;
    [SerializeField]
    GameObject txtNombreValido;
    [SerializeField]
    GameObject seleccionNombre2;

    [SerializeField]
    ScriptableHighscore highScore;

    [SerializeField]
    Jugadores jugadoresActivos;

    [SerializeField]
    PokemonesDisponibles scriptingmonDisponibles;

    bool asignoPlayer;

    private void Start()
    {
        posA = transform.localPosition;
        posB = new Vector3 (0,0,0);
        newPosition = posA;
        txtNombreValido.SetActive(false);
    }

    void Update ()
    {
        if (Input.anyKeyDown)
        {
            newPosition = posB;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, newPosition, 0.05f);
    }

    public void VolverMenu()
    {
        newPosition = posA;
    }
    public void VolverModoDeJuego ()
    {
        seleccionNombre2.transform.localPosition = new Vector3(-1280, 0);
    }
    public void Listo(string userInput)
    {
        if (userInput != "" && asignoPlayer)
        {
            txtNombreValido.SetActive(false);
            ModoDeJuego.GetComponent<Animator>().SetBool("Active", true);
            CrearJugador(userInput);
            audioSource.Play();  
        }
        else
        {
            txtNombreValido.SetActive(true);
        }

    }


    public void AsignarCharmander()
    {
        jugadoresActivos.scriptmonJugador1 = scriptingmonDisponibles.ScriptmonDisponibles[1];
        asignoPlayer = true;
    }

    public void AsignarPikachu()
    {
        jugadoresActivos.scriptmonJugador1 = scriptingmonDisponibles.ScriptmonDisponibles[0];
        asignoPlayer = true;
    }

    public void AsignarSquirtle()
    {
        jugadoresActivos.scriptmonJugador1 = scriptingmonDisponibles.ScriptmonDisponibles[2];
        asignoPlayer = true;
    }

    public void CrearJugador(string nombreNuevo)
    {
        if (highScore.nombresJugadores.Count != 0)
        {
            bool found = false;
            for(int i = 0; i< highScore.nombresJugadores.Count - 1; i++)
            {
                if (highScore.nombresJugadores[i].Substring(0, highScore.nombresJugadores[i].Length-2).Equals(nombreNuevo))
                {
                    found = true;
                    jugadoresActivos.jugador1 = highScore.nombresJugadores[i];
                    Debug.Log("Ya existía");
                }
            }
            if (!found)
            {
                highScore.nombresJugadores.Add(nombreNuevo + " " + "0");
                jugadoresActivos.jugador1 = highScore.nombresJugadores[highScore.nombresJugadores.Count-1];
                Debug.Log("Crea un jugador");
            }
        }
        else
        {
            highScore.nombresJugadores.Add(nombreNuevo + " " + "0");
            jugadoresActivos.jugador1 = highScore.nombresJugadores[highScore.nombresJugadores.Count-1];
            Debug.Log("Primer elemento de la lista");
        }
    }
}