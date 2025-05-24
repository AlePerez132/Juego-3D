using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MostrarRecords : MonoBehaviour
{
    public GameObject contenedor;
    public GameObject prefabEntrada;

    void Start()
    {
        // Obtener los registros y ordenarlos de mayor a menor según el tiempo
        List<Record> records = RecordManager.ObtenerRecords();
        records.Sort((x, y) => y.tiempo.CompareTo(x.tiempo));  // Ordenar por tiempo (descendente)

        // Limitar a los 10 primeros
        int maxRecords = Mathf.Min(records.Count, 10);

        for (int i = 0; i < maxRecords; i++)
        {
            Record r = records[i];
            GameObject entrada = Instantiate(prefabEntrada, contenedor.transform);
            entrada.GetComponentInChildren<TMP_Text>().text = (i + 1) + ". " + r.nombre + " - " + r.tiempo + "s";
        }
    }
}
