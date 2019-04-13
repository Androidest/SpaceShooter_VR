using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static float sensitivity = 4f;
    public static float speed = 20;

    static public float spawnRange = 100;
    
    static public float shootPeriod = 0.4f;
    public AudioSource shootSound;
    public GameObject bullet;
    private bool isShooting;

    public AudioSource explosionSound;
    public GameObject explosion;
    
    Rigidbody rb;

    void Start ()
    {
        isShooting = false;
        rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(Random.Range(-spawnRange, spawnRange), 
                                        Random.Range(-spawnRange, spawnRange), 
                                        Random.Range(-spawnRange, spawnRange));
    }

    public void StartShooting() { isShooting = true; Shoot(); }
    public void StopShooting() { isShooting = false; }

    public void Shoot()
    {
        shootSound.Play();
        Instantiate(bullet, transform.position, transform.rotation);
        if(isShooting)
            Invoke("Shoot", shootPeriod);
    }

    public void Approach()
    {
        Vector3 dir = PlayerController.Position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dir, transform.up);
        rb.rotation = Quaternion.Slerp(rb.rotation, rotation, sensitivity * Time.deltaTime);
        rb.velocity = transform.TransformDirection(Vector3.forward) * speed;
    }

    public void RandomMove()
    {
        rb.rotation *= Quaternion.Euler(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
        rb.velocity = transform.TransformDirection(Vector3.forward) * speed;
    }

    public void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "playerBullet")
        {
            explosionSound.Play();
            Object exp = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(exp, 1.6f);
            Instantiate(gameObject);
            Destroy(gameObject,0.5f);
            EventManager.TriggerEvent("KillOneEnemy");
        }      
    }
}
