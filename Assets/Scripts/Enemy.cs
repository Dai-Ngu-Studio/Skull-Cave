using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    public float speed;

    public int damage;

    public float timeBetweenAttack;

    public int pickupChance;

    public GameObject[] pickups;

    public int healthPickupChance;

    public GameObject healthPickup;

    public GameObject deathEffect;

    [HideInInspector]
    public Transform player;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        
        if (health <= 0)
        {
            int randNum = Random.Range(0, 101);

            if (randNum < pickupChance)
            {
                GameObject randPickup = pickups[Random.Range(0, pickups.Length)];
                Instantiate(randPickup, transform.position, transform.rotation);
            }

            int randHealth = Random.Range(0, 101);

            if (randHealth < healthPickupChance)
            {
                Instantiate(healthPickup, transform.position, transform.rotation);
            }

            Instantiate(deathEffect, transform.position, transform.rotation);
            
            Destroy(gameObject);
        }
    }
}
