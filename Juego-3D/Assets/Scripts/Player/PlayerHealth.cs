using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int vidaMax=100;
    int vidaActual;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaActual = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecibirDanio(int danio)
    {
        vidaActual -= danio;
        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        SceneManager.LoadScene("Escena3");
        Debug.Log("El jugador ha muerto.");
    }

}
