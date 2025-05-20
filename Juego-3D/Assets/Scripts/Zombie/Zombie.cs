using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public int vidaMax;
    public int vidaActual;
    bool muerto;

    private Animator animator;
    public Transform player;
    private NavMeshAgent agent;

    int danioJugador;

    AudioManager AudioManager;
    float tiempoUltimoSonidoAtaque = 0f;
    public float delaySonidoAtaque = 0.9f; 


    void Start()
    {
        vidaMax = 100;
        vidaActual = vidaMax;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        danioJugador = 10;

        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }

        AudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    void Update()
    {
        if (player != null && !muerto)
        {
            // Movimiento hacia el jugador
            agent.SetDestination(player.position);

            // Control de animacion de movimiento
            float velocidad = agent.velocity.magnitude;
            if (animator != null)
            {
                animator.SetFloat("velocidad", velocidad);
            }

            // Animacion de ataque
            float distancia = Vector3.Distance(transform.position, player.position);
            if (distancia < 2f)
            {
                if (Time.time - tiempoUltimoSonidoAtaque >= delaySonidoAtaque)
                {
                    tiempoUltimoSonidoAtaque = Time.time;
                    AudioManager.reproducirEfecto(AudioManager.zombieAtaque);
                }
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
        AudioManager.reproducirEfecto(AudioManager.zombieMuerte);
        
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

        // Destruye el zombie tras 3 segundos (tiempo para que se reproduzca la animaci�n)
        Destroy(gameObject, 1f);
    }

    public void HacerDanio()
    {

        player.transform.GetComponent<PlayerHealth>().RecibirDanio(danioJugador);
    }
}
