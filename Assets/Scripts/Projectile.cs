using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    public float lifeTime;

    public GameObject explosion;

    public int damage;

    public GameObject soundObject;

    public GameObject trail;

    private float timeBtwTrail;

    public float startTimeBtwTrail;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroyProjectile), lifeTime);
        Instantiate(soundObject, transform.position, transform.rotation);
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwTrail <= 0)
        {
            Instantiate(trail, transform.position, Quaternion.identity);
            timeBtwTrail = startTimeBtwTrail;
        }
        else
        {
            timeBtwTrail -= Time.deltaTime;
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            DestroyProjectile();
        }

        if (other.CompareTag("Boss"))
        {
            other.GetComponent<Boss>().TakeDamage(damage);
            DestroyProjectile();
        }
    }
}
