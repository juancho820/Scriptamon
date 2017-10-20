using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour {

    public Text statusText;
    public Text player1Text;
    public Text player2Text;

    int player1Health = 100;
    int player2Health = 100;

    bool player1Turn = true;
    bool ataqueNormal = true;

    // Use this for initialization
    void Start () {

        StartPlayer1Turn();
		
	}
	
	// Update is called once per frame
	void Update () {
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
        if (ataqueNormal == true)
        {
            int damage = Random.Range(8, 25);
            player2Health -= damage;
        }
        else
        {
            int damage = Random.Range(1, 5);
            player2Health -= damage;
            ataqueNormal = true;
        }

        if (player2Health <= 0)
        {
            //win state
            player2Health = 0;
        }
    }

    void CurarsePlayer1()
    {
        int Pocion = Random.Range(6, 15);
        player1Health += Pocion;
    }
    void CurarsePlayer2()
    {
        int Pocion = Random.Range(6, 15);
        player2Health += Pocion;
    }

    public void Player2Fight()
    {
        if (ataqueNormal == true)
        {
            int damage = Random.Range(8, 25);
            player1Health -= damage;
        }
        else
        {
            int damage = Random.Range(1, 5);
            player1Health -= damage;
            ataqueNormal = true;
        }

        if (player1Health <= 0)
        {
            //win state
            player1Health = 0;
        }
    }

    void SwitchPlayer()
    {
        player1Text.text = "Health: " + player1Health;
        player2Text.text = "Health: " + player2Health;
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
        if (player1Turn)
        {
            ataqueNormal = false;
            SwitchPlayer();
        }
    }

    public void DefendersePlayer2()
    {
        if (player1Turn == false)
        {
            ataqueNormal = false;
            SwitchPlayer();
        }
    }

    public void atacarPlayer1()
    {
        if (player1Turn)
        {
            Player1Fight();
            SwitchPlayer();
        }
    }

    public void atacarPlayer2()
    {
        if (player1Turn == false)
        {
            Player2Fight();
            SwitchPlayer();
        }
    }
    public void curarsePlayer1()
    {
        if (player1Turn)
        {
            CurarsePlayer1();
            SwitchPlayer();
        }
    }
    public void curarsePlayer2()
    {
        if (player1Turn == false)
        {
            CurarsePlayer2();
            SwitchPlayer();
        }
    }
}
