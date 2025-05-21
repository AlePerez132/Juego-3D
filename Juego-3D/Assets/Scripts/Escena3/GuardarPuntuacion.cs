using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GuardarPuntuacion : MonoBehaviour
{
    public TMP_InputField inputNombre;
    public TMP_Text textoTiempo;

    private int tiempoFinal;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        tiempoFinal = PlayerPrefs.GetInt("TiempoFinal", 9999); //Para obtener el tiempo final guardado en PlayerPrefs. 
        //El segundo argumento es el valor por defecto en caso de que no exista el tiempo guardado.
        textoTiempo.text = "Tu tiempo: " + tiempoFinal + " segundos";
    }

    public void Guardar()
    {
        string nombre = inputNombre.text;

        if (string.IsNullOrEmpty(nombre))
            return;

        Record nuevo = new Record(nombre, tiempoFinal);
        RecordManager.AgregarRecord(nuevo);

        SceneManager.LoadScene("TablaRecords");
    }
}
