using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleControllerSingle : MonoBehaviour {

    public Text statusText;
    public Text moveText;
    //public Text player1Text;
    //public Text player2Text;
    public Slider hp;
    public Slider hp2;
    

    int player1Health = 100;
    int player2Health = 100;

    bool player1Turn = true;
    bool ataqueNormal = true;

    // Use this for initialization
    void Start () {

        StartPlayer1Turn();
		
	}
	
	// Update is called once per frame
    void Update()
    {
        if(player1Turn == false)
        {
            StartCoroutine(Player2Turn());
            int decidir = Random.Range(0, 4);
            Debug.Log(decidir);

            if (decidir <= 1)
            {
                atacarPlayer2();
            }
            if (decidir <= 2 && decidir > 1)
            {
                DefendersePlayer2();
            }
            if (decidir <= 4 && decidir > 2)
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
        moveText.text = "Player 1 Atacó";
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
        StartCoroutine(Player2Turn());
    }
    public void Player2Fight()
    {
        moveText.text = "Player 2 Atacó";
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

    void CurarsePlayer1()
    {
        moveText.text = "Player 1 Se curó";
        int Pocion = Random.Range(8, 20);
        player1Health += Pocion;
        StartCoroutine(Player2Turn());
        if (player1Health > 100)
        {
            player1Health = 100;
        }
    }
    void CurarsePlayer2()
    {
        moveText.text = "Player 2 Se curó";
        int Pocion = Random.Range(8, 20);
        player2Health += Pocion;
        if (player2Health > 100)
        {
            player2Health = 100;
        }
    }

    void SwitchPlayer()
    {
        hp.value = player1Health;
        hp2.value = player2Health;
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
        }
        StartCoroutine(Player2Turn());
    }

    public void DefendersePlayer2()
    {
        moveText.text = "Player 2 Se defendio";
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

    IEnumerator Player2Turn()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
    }
}
