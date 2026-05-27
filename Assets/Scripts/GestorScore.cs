using UnityEngine;
using TMPro;

public class GestorScore : MonoBehaviour
{
    public TextMeshProUGUI textoScore;
    public TextMeshProUGUI textoHighScore;

    private float score = 0f;
    private float highScore = 0f;

    void Start()
    {
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
        textoHighScore.text = "Best: " + Mathf.FloorToInt(highScore);
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
    }
}