using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GazeButton : MonoBehaviour
{
    Image image;
    Color color;
    Color colorOver;

    public void Start()
    {
        image = GetComponent<Image>();
        color = image.color;
        colorOver = new Color(color.r, color.g, color.b, 0.8f);
    }

    public void OnEnter()
    {
        image.color = colorOver;
    }

    public void OnExit()
    {
        image.color = color;
    }
}
