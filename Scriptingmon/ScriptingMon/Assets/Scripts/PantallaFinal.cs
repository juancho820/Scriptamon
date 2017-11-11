using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PantallaFinal : MonoBehaviour
{

    [SerializeField]
    Color colorPlayer1;
    [SerializeField]
    Color colorPlayer2;
    [SerializeField]
    Color colorCPU;
    [SerializeField]
    Image imgBackground;
    [SerializeField]
    Text txtGanador;
    [SerializeField]
    Text txtScore;
    [SerializeField]
    Jugadores jugadoresActivos;

    Animator gameoverAnimator;
    Vector3 posA, posB, newPosition;

    private void Awake()
    {
        gameoverAnimator = GetComponent<Animator>();
        posA = transform.localPosition;
        posB = Vector3.zero;
        newPosition = posA;
    }
    
    public void Activar(string ganador)
    {
        switch (ganador)
        {
            case "Player 1":
                txtGanador.text = jugadoresActivos.jugador1.Substring(0, jugadoresActivos.jugador1.Length - 2) + " " + "gana!";
                txtScore.text = "Score: " + jugadoresActivos.jugador1.Substring(jugadoresActivos.jugador1.Length - 2, 2);
                imgBackground.color = colorPlayer1;
                break;
            case "Player 2":
                txtGanador.text = jugadoresActivos.jugador2.Substring(0, jugadoresActivos.jugador2.Length - 2) + " " + "gana!";
                txtScore.text = "Score: " + jugadoresActivos.jugador2.Substring(jugadoresActivos.jugador2.Length - 2, 2);
                imgBackground.color = colorPlayer2;
                break;
            case "CPU":
                txtGanador.text = "CPU Gana!";
                imgBackground.color = colorCPU;
                break;
        }
        /*
        if (ganador == "Player 1")
        {
            txtGanador.text = jugadoresActivos.jugador1.Substring(0, jugadoresActivos.jugador1.Length - 2) + " " + "gana!";
            txtScore.text = "Score: " + jugadoresActivos.jugador1.Substring(jugadoresActivos.jugador1.Length - 2, 2);
            imgBackground.color = colorPlayer1;
        }
        else
        {
            txtGanador.text = jugadoresActivos.jugador2.Substring(0, jugadoresActivos.jugador2.Length - 2) + " " + "gana!";
            txtScore.text = "Score: " + jugadoresActivos.jugador2.Substring(jugadoresActivos.jugador2.Length - 2, 2);
            imgBackground.color = colorPlayer2;
        }
        */
        newPosition = posB;

        txtScore.CrossFadeAlpha(1, Time.timeScale, false);
        Invoke("MostrarTexto", 1f);
    }

    public void MostrarTexto ()
    {
        txtGanador.GetComponent<Animator>().SetBool("Active", true);
    }

    void Update ()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Activar("Player 2");
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, newPosition, 0.05f);
	}
}
