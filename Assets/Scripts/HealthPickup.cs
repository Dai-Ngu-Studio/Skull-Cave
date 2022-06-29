using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    Player playerScript;

    public int healthAmount;

    public GameObject effect;

    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            
            playerScript.Heal(healthAmount);

            Destroy(gameObject);
        }
    }
}
