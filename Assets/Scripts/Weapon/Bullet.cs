using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    float timeCounter = 0;

	void Start ()
    {
        transform.position += transform.forward * 2.5f;
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}

    void Update()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter > 2f)
            Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision hit)
    {
        Destroy(gameObject);
    }
}
