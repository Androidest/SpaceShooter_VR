using UnityEngine;

public class StaticPlanet : MonoBehaviour 
{
	private struct Rotator
	{
		public static float minAngleSpeed;
		public static float maxAngleSpeed;

		public Transform transform;
		public Vector3 rotation;
		public float speed;

		public static void SetRange(float min, float max){ minAngleSpeed = min; maxAngleSpeed = max; }

		public void Set(Transform t)
		{
			transform = t;
			rotation = Random.insideUnitSphere;
			speed = Random.Range(minAngleSpeed, maxAngleSpeed);
		}

		public void Rotate() { transform.Rotate (rotation, speed); }
	}

	[Range(0.0001f,0.1f)] public float minAngleSpeed;
	[Range(0.1f,3f)] public float maxAngleSpeed;
	public GameObject[] planets;
	private Rotator[] rotator;
	private int size;

	void Start()
	{
		Rotator.SetRange (minAngleSpeed, maxAngleSpeed);
		size = planets.Length;
		rotator = new Rotator[size];

		for (int i = 0; i < size; ++i) 
			rotator [i].Set(planets [i].transform);
	}

	void FixedUpdate()
	{
		for (int i = 0; i < size; ++i)
			rotator [i].Rotate(); 
	}
}
