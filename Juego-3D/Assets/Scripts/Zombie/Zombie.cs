using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public int vidaMax = 100;
    public int vidaActual;
    bool muerto;

    private Animator animator;
    public Transform player;
    private NavMeshAgent agent;

    int danioJugador;

    void Start()
    {
        vidaActual = vidaMax;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        danioJugador = 20;
    }

    void Update()
    {
        if (player != null && !muerto)
        {
            // Movimiento hacia el jugador
            agent.SetDestination(player.position);

            // Control de animación de movimiento
            float velocidad = agent.velocity.magnitude;
            if (animator != null)
            {
                animator.SetFloat("velocidad", velocidad);
            }

            // Animación de ataque
            float distancia = Vector3.Distance(transform.position, player.position);
            if (distancia < 2f)
            {
                animator.SetTrigger("atacar"); 
            }
        }
    }

    public void RecibirDanio(int danio)
    {
        if (muerto) return;

        vidaActual -= danio;

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

        // Desactiva movimiento
        if (agent != null)
        {
            agent.enabled = false;
        }

        // Destruye el zombie tras 3 segundos (tiempo para que se reproduzca la animación)
        Destroy(gameObject, 1f);
    }

    public void HacerDanio()
    {
        player.transform.GetComponent<PlayerHealth>().RecibirDanio(danioJugador);
    }
}
