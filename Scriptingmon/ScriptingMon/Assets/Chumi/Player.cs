using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string nombre;
    public int score;

    public Player(string nombrePara, int scorePara)
    {
        nombre = nombrePara;
        score = scorePara;
    }
}
