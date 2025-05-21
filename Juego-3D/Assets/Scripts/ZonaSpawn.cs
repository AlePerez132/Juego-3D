using System.Collections.Generic;
using UnityEngine;

public class SpawnerPorRondas : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public int enemigosPorRonda = 1;
    public float intervaloEntreRondas = 15f;

    private BoxCollider[] zonasSpawn;
    private float temporizador = 0f;

    void Start()
    {
        zonasSpawn = GetComponentsInChildren<BoxCollider>();
        IniciarNuevaRonda(); // Primer grupo al iniciar
        temporizador = intervaloEntreRondas;
    }

    void Update()
    {
        // Cuenta regresiva del temporizador
        temporizador -= Time.deltaTime;
        if (temporizador <= 0f)
        {
            IniciarNuevaRonda();
            temporizador = intervaloEntreRondas; // Reiniciar temporizador
        }
    }

    void IniciarNuevaRonda()
    {
        for (int i = 0; i < enemigosPorRonda; i++)
        {
            Vector3 punto = ObtenerPuntoAleatorioDesdeZonas();
            GameObject enemigo = Instantiate(enemigoPrefab, punto, Quaternion.identity);
        }
    }

    Vector3 ObtenerPuntoAleatorioDesdeZonas()
    {
        if (zonasSpawn.Length == 0) return transform.position;

        BoxCollider zona = zonasSpawn[Random.Range(0, zonasSpawn.Length)];
        Vector3 centro = zona.center + zona.transform.position;
        Vector3 tamanio = zona.size;

        float x = Random.Range(centro.x - tamanio.x / 2, centro.x + tamanio.x / 2);
        float z = Random.Range(centro.z - tamanio.z / 2, centro.z + tamanio.z / 2);
        float y = centro.y;

        return new Vector3(x, y, z);
    }
}
