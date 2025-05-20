using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider slider;
    public PlayerHealth playerHealth;
    public Image fillImage; 

    void Start()
    {
        slider.maxValue = playerHealth.vidaMax;
        slider.value = playerHealth.vidaMax;
        UpdateColor(); // Para inicializar con el color correcto
    }

    void Update()
    {
        slider.value = playerHealth.GetVidaActual();
        UpdateColor();
    }

    void UpdateColor()
    {
        float vidaPorcentaje = (float)playerHealth.GetVidaActual() / playerHealth.vidaMax;

        if (vidaPorcentaje >= 0.8f)
        {
            fillImage.color = Color.green;
        }
        else if (vidaPorcentaje >= 0.5f)
        {
            fillImage.color = Color.yellow;
        }
        else if (vidaPorcentaje >= 0.2f)
        {
            fillImage.color = new Color(1f, 0.5f, 0f); // Naranja
        }
        else
        {
            fillImage.color = Color.red;
        }
    }
}
