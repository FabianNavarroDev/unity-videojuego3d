using UnityEngine;
using TMPro;

public class GestorScore : MonoBehaviour
{
    public TextMeshProUGUI textoScore;
    public TextMeshProUGUI textoHighScore;
    public TextMeshProUGUI textoNivel;

    private float score = 0f;
    private float highScore = 0f;
    private int nivel = 1;

    public GeneradorNiveles generador;
    public MovimientoJugador jugador;

     public Color[] coloresCielo = new Color[]
    {
        new Color(0.5f, 0.7f, 1f),
        new Color(1f, 0.5f, 0.2f),
        new Color(0.05f, 0.05f, 0.2f)
    };

    void Start()
    {
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
        textoHighScore.text = "Best: " + Mathf.FloorToInt(highScore);
        textoNivel.text = "Nivel: 1";
    }

    void Update()
    {
        score += Time.deltaTime * 5f;
        textoScore.text = "Score: " + Mathf.FloorToInt(score);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);
            textoHighScore.text = "Best: " + Mathf.FloorToInt(highScore);
        }

        ActualizarNivel();
    }

    void ActualizarNivel()
    {
        int nuevoNivel = 1;

        if (score >= 100f) nuevoNivel = 3;
        else if (score >= 50f) nuevoNivel = 2;

        if (nuevoNivel != nivel)
        {
            nivel = nuevoNivel;
            textoNivel.text = "Nivel: " + nivel;

            if (generador != null)
                generador.incrementoDificultad += 0.2f;

            if (jugador != null)
                jugador.velocidad += 2f;
                
                 RenderSettings.skybox = null;
        Camera.main.backgroundColor = coloresCielo[nivel - 1];
        }
    }
}