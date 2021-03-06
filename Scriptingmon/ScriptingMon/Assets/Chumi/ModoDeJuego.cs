﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModoDeJuego : MonoBehaviour
{
    [SerializeField]
    GameObject seleccionNombre2;
    [SerializeField]
    GameObject txtNombreValido;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    ScriptableHighscore highScore;

    [SerializeField]
    Jugadores jugadoresActivos;

    [SerializeField]
    PokemonesDisponibles scriptingmonDisponibles;

    [SerializeField]
    Image sprCharmander, sprPikachu, sprSquirtle;
    [SerializeField]
    Sprite charmanderListo, pikachuListo, squirtleListo;

    Sprite charmanderOriginal, pikachuOriginal, squirtleOriginal;

    bool asignoPlayer;
    private void Start()
    {
        charmanderOriginal = sprCharmander.sprite;
        pikachuOriginal = sprPikachu.sprite;
        squirtleOriginal = sprSquirtle.sprite;
    }
    public void SinglePlayer()
    {
        SceneManager.LoadScene("SinglePlayer");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void Local ()
    {
        seleccionNombre2.transform.localPosition = Vector3.zero;
        txtNombreValido.SetActive(false);
    }
    public void Local_Listo (string userInput)
    {
        if (userInput != "" && asignoPlayer)
        {
            txtNombreValido.SetActive(false);
            CrearJugadorDos(userInput);
        }
        else
        {
            if (userInput != "")
                txtNombreValido.SetActive(true);

            if (asignoPlayer == false)
                txtNombreValido.SetActive(true);
        }
        audioSource.Play();
    }


    public void AsignarCharmander()
    {
        jugadoresActivos.scriptmonJugador2 = scriptingmonDisponibles.ScriptmonDisponibles[1];
        sprCharmander.sprite = charmanderListo;
        sprPikachu.sprite = pikachuOriginal;
        sprSquirtle.sprite = squirtleOriginal;
        asignoPlayer = true;
    }

    public void AsignarPikachu()
    {
        jugadoresActivos.scriptmonJugador2 = scriptingmonDisponibles.ScriptmonDisponibles[0];
        sprCharmander.sprite = charmanderOriginal;
        sprPikachu.sprite = pikachuListo;
        sprSquirtle.sprite = squirtleOriginal;
        asignoPlayer = true;
    }

    public void AsignarSquirtle()
    {
        jugadoresActivos.scriptmonJugador2 = scriptingmonDisponibles.ScriptmonDisponibles[2];
        sprCharmander.sprite = charmanderOriginal;
        sprPikachu.sprite = pikachuOriginal;
        sprSquirtle.sprite = squirtleListo;
        asignoPlayer = true;
    }


    public void CrearJugadorDos (string nombreNuevo)
    {
        if (highScore.nombresJugadores.Count != 0)
        {
            bool found = false;
            for (int i = 0; i < highScore.nombresJugadores.Count - 1; i++)
            {
                if (highScore.nombresJugadores[i].Substring(0, highScore.nombresJugadores[i].Length - 2).Equals(nombreNuevo))
                {
                    found = true;
                    jugadoresActivos.jugador2 = highScore.nombresJugadores[i];
                }
            }
            if (!found)
            {
                highScore.nombresJugadores.Add(nombreNuevo + " " + "0");
                jugadoresActivos.jugador2 = highScore.nombresJugadores[highScore.nombresJugadores.Count - 1];
            }
        }
        else
        {
            highScore.nombresJugadores.Add(nombreNuevo + " " + "0");
            jugadoresActivos.jugador2 = highScore.nombresJugadores[highScore.nombresJugadores.Count - 1];
        }
        SceneManager.LoadScene("Local");
    }
}
