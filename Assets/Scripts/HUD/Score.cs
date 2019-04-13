using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    Text scoreText;

    private void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = "Score: 0";
    }

    private void OnEnable()
    {
        EventManager.AddEvent("KillOneEnemy", AddScore);
    }

    private void OnDisable()
    {
        EventManager.RemoveEvent("KillOneEnemy", AddScore);
    }

    private void AddScore()
    {
        scoreText.text = "Score: " + ++score;
    }
}
