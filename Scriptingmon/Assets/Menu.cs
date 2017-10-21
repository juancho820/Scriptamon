using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	public void Local()
    {
        Application.LoadLevel("Local");
    }
    public void Single()
    {
        Application.LoadLevel("SinglePlayer");
    }
}
