using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20f;
    public float moveSmoothness = 5f;
    public float ratateSmoothness = 5f;

    public Rigidbody spaceship;
    public Transform target;
    Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        if (spaceship == null) return; 

        spaceship.position = Vector3.Lerp(spaceship.position, target.position, moveSmoothness * Time.deltaTime);
        spaceship.rotation = Quaternion.Lerp(spaceship.rotation, target.rotation, ratateSmoothness * Time.deltaTime);
        if (Input.GetAxis("Fire1") != 0)
        {
            Engine.isMoving = true;
            rb.velocity = target.forward * speed;
        }

        else
        {
            Engine.isMoving = false;
        }
    }
}
