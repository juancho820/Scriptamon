using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleControllerSingle : MonoBehaviour {

    [SerializeField]
    PantallaFinal pantallaFinal;
    [SerializeField]
    ScriptableHighscore scores;
    [SerializeField]
    Jugadores jugadoresActivos;
    public Text statusText;
    public Text moveText;

    int player1Health = 100;
    int player2Health = 100;

    Scriptmon player1Scriptmon;
    Scriptmon player2Scriptmon;

    bool player1Turn = true;
    bool ataqueNormal = true;
    string winner;

    [SerializeField]
    SpriteRenderer sprScritmon1;
    [SerializeField]
    SpriteRenderer sprScritmon2;

    [SerializeField]
    PokemonesDisponibles scriptmonDisponibles;

    //Get Vida Players
    public int Player1Health
    {
        get
        {
            return player1Health;
        }
    }
    public int Player2Health
    {
        get
        {
            return player2Health;
        }
    }

    public delegate void CambiarSalud();
    public event CambiarSalud CambiandoSalud;

    void Start ()
    {
        player1Scriptmon = jugadoresActivos.scriptmonJugador1;
        player2Scriptmon = scriptmonDisponibles.ScriptmonDisponibles[UnityEngine.Random.Range(0, 3)];
        //player2Scriptmon = jugadoresActivos.scriptmonJugador2;
        sprScritmon1.sprite = jugadoresActivos.scriptmonJugador1.sprite;
        sprScritmon2.sprite = player2Scriptmon.sprite;
        StartPlayer1Turn();
		
	}
	
    void Update()
    {
        if(player1Turn == false)
        {
            StartCoroutine(Player2Turn());
            int decidir = UnityEngine.Random.Range(0, 11);
            Debug.Log(decidir);

            if (decidir <= 8)
            {
                atacarPlayer2();
            }
            if (decidir > 8 && decidir <= 10)
            {
                curarsePlayer2();
            }
        }
    }

    void StartPlayer1Turn()
    {
        statusText.text = "Player1 turn";
    }

    void StartPlayer2Turn()
    {
        statusText.text = "Player2 turn";
    }

    public void Player1Fight()
    {
        int probGolpe = UnityEngine.Random.Range(0, 101);

        if (probGolpe >= 0 && probGolpe < 81)
        {
            moveText.text = "Player 1 Atacó";
            float damage = UnityEngine.Random.Range(player1Scriptmon.ATK - 10, player1Scriptmon.ATK + 11);
            player2Health -= (int)(damage - damage * (player2Scriptmon.DEF / 100));
            EstadosAnimacion.Instance.ReproducirAnimacion("Atacar", (int)(damage - damage * (player2Scriptmon.DEF / 100)), 2);
            CambiarPersonaje.Instance.AnimacionAtacar();
            StartCoroutine(CambiarPersonaje.Instance.AnimacionHitEnemigo());
        }

        else if (probGolpe >= 81 && probGolpe <= 100)
        {
            EstadosAnimacion.Instance.ReproducirAnimacion("Atacar", 0, 2);
            CambiarPersonaje.Instance.AnimacionAtacar();
            StartCoroutine(CambiarPersonaje.Instance.AnimacionHitEnemigo());
        }

        /*
        else
        {
            int damage = UnityEngine.Random.Range(1, 5);
            player2Health -= damage;
            ataqueNormal = true;
            EstadosAnimacion.Instance.ReproducirAnimacion("Atacar", damage, 2);
        }
        */
        //Win State
        if (player2Health <= 0)
        {
            winner = "Player 1";
            for (int i = 0; i < scores.nombresJugadores.Count; i++)
            {
                if (scores.nombresJugadores[i].Equals(jugadoresActivos.jugador1))
                {
                    int aux;
                    aux = Int32.Parse(scores.nombresJugadores[i].Substring(scores.nombresJugadores[i].Length - 1));
                    aux++;
                    scores.nombresJugadores[i] = scores.nombresJugadores[i].Substring(0, scores.nombresJugadores[i].Length - 2) + " " + aux;
                    jugadoresActivos.jugador1 = scores.nombresJugadores[i];
                }
            }
            pantallaFinal.Activar(winner);
            player2Health = 0;
        }
        else
        {
            StartCoroutine(Player2Turn());
        }
        //Event
        if (CambiandoSalud != null)
            CambiandoSalud();
    }
    public void Player2Fight()
    {

        int probGolpe = UnityEngine.Random.Range(0, 101);

        if (probGolpe >= 0 && probGolpe < 81)
        {
            moveText.text = "Player 2 Atacó";
            float damage = UnityEngine.Random.Range(player2Scriptmon.ATK - 10, player2Scriptmon.ATK + 11);
            player1Health -= (int)(damage - damage * (player1Scriptmon.DEF / 100));
            EstadosAnimacion.Instance.ReproducirAnimacion("Atacar", (int)(damage - damage * (player1Scriptmon.DEF / 100)), 1);
            CambiarPersonaje.Instance.AnimacionAtacarEnemigo();
            StartCoroutine(CambiarPersonaje.Instance.AnimacionHit());
        }

        else if (probGolpe >= 81 && probGolpe <= 100)
        {
            EstadosAnimacion.Instance.ReproducirAnimacion("Atacar", 0, 2);
            CambiarPersonaje.Instance.AnimacionAtacarEnemigo();
            StartCoroutine(CambiarPersonaje.Instance.AnimacionHit());
        }
        /*
        else
        {
            int damage = UnityEngine.Random.Range(1, 5);
            player1Health -= damage;
            ataqueNormal = true;
            EstadosAnimacion.Instance.ReproducirAnimacion("Atacar", damage, 1);
        }
        */
        if (player1Health <= 0)
        {
            //win state
            winner = "CPU";
            for (int i = 0; i < scores.nombresJugadores.Count; i++)
            {
                if (scores.nombresJugadores[i].Equals(jugadoresActivos.jugador1))
                {
                    int aux;
                    aux = Int32.Parse(scores.nombresJugadores[i].Substring(scores.nombresJugadores[i].Length - 1));
                    aux++;
                    scores.nombresJugadores[i] = scores.nombresJugadores[i].Substring(0, scores.nombresJugadores[i].Length - 2) + " " + aux;
                    jugadoresActivos.jugador1 = scores.nombresJugadores[i];
                }
            }
            pantallaFinal.Activar(winner);
            player1Health = 0;
        }
        //Event
        if (CambiandoSalud != null)
            CambiandoSalud();
    }

    void CurarsePlayer1()
    {
        moveText.text = "Player 1 Se curó";
        int Pocion = UnityEngine.Random.Range(8, 20);
        player1Health += Pocion;
        StartCoroutine(Player2Turn());
        if (player1Health > 100)
        {
            player1Health = 100;
        }
        EstadosAnimacion.Instance.ReproducirAnimacion("Curarse", Pocion, 1);
        //Event
        if (CambiandoSalud != null)
            CambiandoSalud();
    }
    void CurarsePlayer2()
    {
        moveText.text = "Player 2 Se curó";
        int Pocion = UnityEngine.Random.Range(8, 20);
        player2Health += Pocion;
        if (player2Health > 100)
        {
            player2Health = 100;
        }
        EstadosAnimacion.Instance.ReproducirAnimacion("Curarse", Pocion, 2);
        //Event
        if (CambiandoSalud != null)
            CambiandoSalud();
    }

    void SwitchPlayer()
    {
        //player1Text.text = ""+ player1Health;
        //player2Text.text = ""+ player2Health;
        player1Turn = !player1Turn;

        if (player1Turn)
        {
            StartPlayer1Turn();
        }
        else
        {
            StartPlayer2Turn();
        }
    }

    public void DefendersePlayer1()
    {
        moveText.text = "Player 1 Se defendio";
        if (player1Turn)
        {
            ataqueNormal = false;
            SwitchPlayer();
            EstadosAnimacion.Instance.ReproducirAnimacion("Defender", 0, 1);
        }
        StartCoroutine(Player2Turn());
        //Event
        if (CambiandoSalud != null)
            CambiandoSalud();
    }

    public void DefendersePlayer2()
    {
        moveText.text = "Player 2 Se defendio";
        if (player1Turn == false)
        {
            ataqueNormal = false;
            SwitchPlayer();
            EstadosAnimacion.Instance.ReproducirAnimacion("Defender", 0, 2);
        }
        //Event
        if (CambiandoSalud != null)
            CambiandoSalud();
    }

    public void atacarPlayer1()
    {
        if (player1Turn)
        {
            Player1Fight();
            SwitchPlayer();
        }
        //Event
        if (CambiandoSalud != null)
            CambiandoSalud();
    }

    public void atacarPlayer2()
    {
        if (player1Turn == false)
        {
            Player2Fight();
            SwitchPlayer();
        }
        //Event
        if (CambiandoSalud != null)
            CambiandoSalud();
    }
    public void curarsePlayer1()
    {
        if (player1Turn)
        {
            CurarsePlayer1();
            SwitchPlayer();
        }
        //Event
        if (CambiandoSalud != null)
            CambiandoSalud();
    }
    public void curarsePlayer2()
    {
        if (player1Turn == false)
        {
            CurarsePlayer2();
            SwitchPlayer();
        }
        //Event
        if (CambiandoSalud != null)
            CambiandoSalud();
    }

    IEnumerator Player2Turn()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(1, 3));
    }
}
