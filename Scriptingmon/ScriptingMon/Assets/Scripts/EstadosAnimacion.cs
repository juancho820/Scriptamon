using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstadosAnimacion : MonoBehaviour
{
    [SerializeField]
    Text txtDamage;
    [SerializeField]
    Image imgDefend;
    [SerializeField]
    Text txtHealth;
    [SerializeField]
    ParticleSystem healthParticel;
    [SerializeField]
    Vector3 objetivo1;
    [SerializeField]
    Vector3 objetivo2;
    public void ReproducirAnimacion (string estado,int valor,int objetivo)
    {
        if (objetivo == 1)
            transform.localPosition = objetivo1;
        if (objetivo == 2)
            transform.localPosition = objetivo2;

        switch (estado)
        {
            case "Atacar":
                txtDamage.text = "-" + valor;
                txtDamage.GetComponent<Animator>().Play("Damage", 0, 0);
                break;
            case "Defender":
                imgDefend.GetComponent<Animator>().Play("Defend", 0, 0);
                break;
            case "Curarse":
                txtHealth.text = "+" + valor;
                txtHealth.GetComponent<Animator>().Play("Health", 0, 0);
                healthParticel.Play();
                break;
        }
    }

    #region Singleton

    private static EstadosAnimacion instance;
    private EstadosAnimacion() { }

    public static EstadosAnimacion Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("EstadosAnimacion.Instance es nula pero se esta intentando accederla");
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (this != instance)
                DestroyImmediate(this.gameObject);
        }
    }

    #endregion
}
