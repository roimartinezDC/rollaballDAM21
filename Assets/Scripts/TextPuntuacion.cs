using TMPro;
using UnityEngine;

public class TextPuntuacion : MonoBehaviour
{
    [SerializeField] private TMP_Text texto;
    void Start()
    {
        
    }

    void Update()
    {
        texto.text = "Puntuación: " + PlayerController.puntuacion.ToString();
    }
}
