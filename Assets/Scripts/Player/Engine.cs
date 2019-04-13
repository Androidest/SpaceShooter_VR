using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour
{
    public float smoothTime = 5f;
    Renderer rend;
    Color emissionColor;
    Behaviour[] halo;
    public static bool isMoving = false;

    void Start ()
    { 
        rend = GetComponent<Renderer>();
        halo = new Behaviour[3];
        GameObject[] obj = GameObject.FindGameObjectsWithTag("engine");
        for( int i=0; i<3; i++ )
            halo[i] = (Behaviour)obj[i].GetComponent("Halo");
	}
	
	void Update ()
    {
        if (isMoving)
            emissionColor = Color.Lerp(emissionColor, Color.white, smoothTime * Time.deltaTime);
        else
            emissionColor = Color.Lerp(emissionColor, Color.black, smoothTime * Time.deltaTime);

        rend.material.SetColor("_EmissionColor", emissionColor);

        if (emissionColor.r > 0.95f)
            for (int i = 0; i < 3; i++)
                halo[i].enabled = true;
        else for (int i = 0; i < 3; i++)
                halo[i].enabled = false;
    }
}
