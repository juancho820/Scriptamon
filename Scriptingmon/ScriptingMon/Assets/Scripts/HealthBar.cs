using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    Slider sliderPlayer1;
    [SerializeField]
    Slider sliderPlayer2;
    [SerializeField]
    BattleControllerLocal manager;

    public int lastHealth1;
    public int lastHealth2;

    public int newHealth1;
    public int newHealth2;

	void Start ()
    {
        manager.CambiandoSalud += ActualizarVidas;
        ActualizarVidas();

        lastHealth1 = manager.Player1Health;
        lastHealth2 = manager.Player2Health;

        newHealth1 = 100;
    }

	public void ActualizarVidas ()
    {
        newHealth1 = manager.Player1Health;
        newHealth2 = manager.Player2Health;
	}

    private void Update()
    {
        sliderPlayer1.value = Mathf.Lerp(sliderPlayer1.value, manager.Player1Health, 0.04f);
        sliderPlayer2.value = Mathf.Lerp(sliderPlayer2.value, manager.Player2Health, 0.04f);
    }


}
