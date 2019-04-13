using UnityEngine;

public class Planet : MonoBehaviour 
{
	void Awake()
	{
		GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * Random.Range(50,300);
	}
}
