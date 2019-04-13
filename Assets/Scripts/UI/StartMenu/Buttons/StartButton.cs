using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("MainScene");
    }
}