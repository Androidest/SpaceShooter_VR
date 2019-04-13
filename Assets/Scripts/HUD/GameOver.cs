using UnityEngine.UI;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    Text gameoverText;

    private void Start()
    {
        gameoverText = GetComponent<Text>();
        gameoverText.text = "";
    }

    private void OnEnable()
    {
        EventManager.AddEvent("GameOver", ShowGameOverMsg);
    }

    private void OnDisable()
    {
        EventManager.RemoveEvent("GameOver", ShowGameOverMsg);
    }

    private void ShowGameOverMsg()
    {
        gameoverText.text = "Game Over";
    }
}
