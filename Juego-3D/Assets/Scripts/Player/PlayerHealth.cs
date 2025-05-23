using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class PlayerHealth : MonoBehaviour
{
    public int vidaMax = 500;
    public int vidaActual;

    public Slider barraVida; 

    void Start()
    {
        vidaActual = vidaMax;
        ActualizarBarra();
    }

    public void RecibirDanio(int danio)
    {
        vidaActual -= danio;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMax);
        ActualizarBarra(); 

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Escena3");
        Debug.Log("El jugador ha muerto.");
    }

    public int GetVidaActual()
    {
        return vidaActual;
    }

    void ActualizarBarra()
    {
        if (barraVida != null)
        {
            barraVida.value = (float)vidaActual / vidaMax;
        }
    }
}
