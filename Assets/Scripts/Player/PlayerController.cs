using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static Transform trans;

    public float shootPeriod = 0.2f;
    public GameObject bullet;

    public GameObject explosion;
    public AudioSource shootSound;
    public AudioSource explosionSound;

    public static Vector3 Position { get { return trans.position; } }
    public static Quaternion Rotation { get { return trans.rotation; } }

    void Start ()
    {
        trans = transform;
        Invoke("Shoot", shootPeriod);
    }

    void Shoot()
    {
        shootSound.Play();
        Instantiate(bullet, transform.position, transform.rotation);
        Invoke("Shoot", shootPeriod);
    }

    public void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "enemyBullet")
        {
            EventManager.TriggerEvent("GameOver");
            explosionSound.Play();
            Instantiate(explosion, transform.position, transform.rotation);
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
