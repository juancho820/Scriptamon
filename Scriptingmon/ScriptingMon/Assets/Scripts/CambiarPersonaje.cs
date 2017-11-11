using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarPersonaje : MonoBehaviour {
    [SerializeField]
    Jugadores jugadoresActivos;
    [SerializeField]
    GameObject arquero1, arquero2, arquero3;
    [SerializeField]
    GameObject enemigo1, enemigo2, enemigo3;

    GameObject arqueroActivo;
    GameObject arqueroActivo2;
	void Start ()
    {
        if (jugadoresActivos.scriptmonJugador1.nombre == "Pikachu")
        {
            arquero2.SetActive(false);
            arquero3.SetActive(false);
            arqueroActivo = arquero1;
        }
        if (jugadoresActivos.scriptmonJugador2.nombre == "Pikachu")
        {
            enemigo2.SetActive(false);
            enemigo3.SetActive(false);
            arqueroActivo2 = enemigo1;
        }
        if (jugadoresActivos.scriptmonJugador1.nombre == "Charmander")
        {
            arquero2.SetActive(true);
            arquero1.SetActive(false);
            arquero3.SetActive(false);
            arqueroActivo = arquero2;
        }
        if (jugadoresActivos.scriptmonJugador2.nombre == "Charmander")
        {
            enemigo2.SetActive(true);
            enemigo1.SetActive(false);
            enemigo3.SetActive(false);
            arqueroActivo2 = enemigo2;
        }
        if (jugadoresActivos.scriptmonJugador1.nombre == "Squirtle")
        {
            arquero1.SetActive(false);
            arquero2.SetActive(false);
            arquero3.SetActive(true);
            arqueroActivo = arquero3;
        }
        if (jugadoresActivos.scriptmonJugador2.nombre == "Squirtle")
        {
            enemigo2.SetActive(false);
            enemigo1.SetActive(false);
            enemigo3.SetActive(true);
            arqueroActivo2 = enemigo3;
        }
        if (jugadoresActivos.scriptmonJugador2 == null)
        {
            arqueroActivo = enemigo3;
        }
    }
	public IEnumerator AnimacionHit ()
    {
        yield return new WaitForSeconds(0.5f);
        arqueroActivo.GetComponent<Animator>().SetInteger("Estado", 2);
        Invoke("AnimacionIdle", 0.5f);
    }
    public IEnumerator AnimacionHitEnemigo ()
    {
        yield return new WaitForSeconds(0.5f);
        arqueroActivo2.GetComponent<Animator>().SetInteger("Estado", 2);
        Invoke("AnimacionIdleEnemigo", 0.5f);
    } 
    public void AnimacionAtacar ()
    {
        arqueroActivo.GetComponent<Animator>().SetInteger("Estado", 1);
        Invoke("AnimacionIdle", 0.5f);
    }
    public void AnimacionAtacarEnemigo ()
    {
        arqueroActivo2.GetComponent<Animator>().SetInteger("Estado", 1);
        Invoke("AnimacionIdleEnemigo", 0.5f);
    }
    public void AnimacionIdle()
    {
        arqueroActivo.GetComponent<Animator>().SetInteger("Estado", 0);
    }
    public void AnimacionIdleEnemigo ()
    {
        arqueroActivo2.GetComponent<Animator>().SetInteger("Estado", 0);
    }
    #region Singleton

    // Implementacion del Singleton 
    private static CambiarPersonaje instance;
    private CambiarPersonaje() { }

    public static CambiarPersonaje Instance
    {
        get
        {
            if (instance == null)
            {
                
            }

            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            //Si soy la primera instancia, hacerme el Singleton
            instance = this;
            //Descomentar esta linea si el singleton debe persistir entre escenas
            //DontDestroyOnLoad(this);
        }
        else
        {
            //Si ya existe este singleton en la escena entonces destruir este objeto 
            if (this != instance)
                DestroyImmediate(this.gameObject);
        }
    }

    #endregion
}
