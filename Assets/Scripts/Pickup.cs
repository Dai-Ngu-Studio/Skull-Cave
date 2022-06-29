using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Weapon weaponToEquip;

    public GameObject effect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            
            other.GetComponent<Player>().ChangeWeapon(weaponToEquip);
            
            Destroy(gameObject);
        }
    }
}
