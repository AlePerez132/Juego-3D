using UnityEngine;

using UnityEngine;

[RequireComponent(typeof(Zombie))]
public class FuzzyZombieAI : MonoBehaviour
{
    public Transform player;
    private Zombie zombie;
    private UnityEngine.AI.NavMeshAgent agent;
    private FuzzyVariable fuzzy = new FuzzyVariable();

    void Start()
    {
        zombie = GetComponent<Zombie>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (zombie == null || player == null || agent == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        float playerHealth = player.GetComponent<PlayerHealth>().vidaActual;

        // Variables difusas
        float distNear = fuzzy.EvaluateLow(distance, 0, 5); //Esto es para la distancia cercana
        float distMid = fuzzy.EvaluateMedium(distance, 6, 20, 30); //Esto es para la distancia media
        float distFar = fuzzy.EvaluateHigh(distance, 21, 50); //Esto es para la distancia lejana

        float healthLow = fuzzy.EvaluateLow(playerHealth, 0, 100);
        float healthMid = fuzzy.EvaluateMedium(playerHealth, 101, 200, 300);
        float healthHigh = fuzzy.EvaluateHigh(playerHealth, 301, 500);

        // Reglas difusas
        float rule1 = Mathf.Min(distNear, healthLow);    // Muy agresivo
        float rule2 = Mathf.Min(distMid, healthMid);     // Moderado
        float rule3 = Mathf.Min(distFar, healthHigh);    // Pasivo

        float aggression = (rule1 * 1.0f + rule2 * 0.5f + rule3 * 0.2f) / (rule1 + rule2 + rule3 + 0.0001f);

        // Aplicar: ajustar velocidad o daño según agresividad
        agent.speed = Mathf.Lerp(2.5f, 12f, aggression); //Esto cambia la velocidad del zombie. 
        zombie.SetDanioJugador(Mathf.RoundToInt(Mathf.Lerp(5, 15, aggression))); //Esto cambia el daño del zombie.
    }
}
