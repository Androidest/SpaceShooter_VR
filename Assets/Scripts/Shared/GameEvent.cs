using UnityEngine.SceneManagement;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.AddEvent("GameOver", GameOver);
    }

    private void OnDisable()
    {
        EventManager.RemoveEvent("GameOver", GameOver);
    }

    private void GoBackToStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    void GameOver()
    {
        Invoke("GoBackToStartMenu", 2f);
    }
}
