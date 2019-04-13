using UnityEngine;

public class DynamicPlanet : MonoBehaviour {

    public float gravity = 0.001f;
    public int planetNumb;
	public GameObject otherPlanets;
    public GameObject[] templatePlanet;

    private Rigidbody[] rb;
	private int size;

    void Start ()
	{
		GameObject[] obj = otherPlanets.GetComponent<StaticPlanet>().planets;
		size = planetNumb + obj.Length;
		rb = new Rigidbody[size];

		for (int i = 0; i < planetNumb; ++i)
			rb[i] = Instantiate(templatePlanet[Random.Range(0, 3)],Random.insideUnitSphere * Random.Range(1000, 3000),transform.rotation).GetComponent<Rigidbody>();

		for (int i = planetNumb; i < size; ++i)
			rb[i] = obj[i-planetNumb].GetComponent<Rigidbody>();
	}

    void FixedUpdate()
    {
		for(int i = 0; i < planetNumb; ++i)
        {
			Rigidbody ri = rb [i];
			for (int j = i + 1; j < size; ++j)
            {
				Rigidbody rj = rb [j];
				Vector3 a = (rj.position - ri.position).normalized * gravity;
				ri.velocity += a * rj.mass;
				rj.velocity -= a * ri.mass;
            }
        }
    }
}
