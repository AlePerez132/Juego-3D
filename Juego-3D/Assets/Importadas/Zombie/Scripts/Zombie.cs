using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int vidaMax=100;
    public int vidaActual;
    bool muerto;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaMax = 100;
        vidaActual = vidaMax;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecibirDanio(int danio)
    {
        vidaActual = vidaActual - danio;
        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        muerto = true;
        if (animator != null)
        {
            animator.SetBool("muerto", true);
        }

        Destroy(gameObject, 5f);
    }
}
