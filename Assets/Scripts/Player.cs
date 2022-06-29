using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;

    public int health;

    private Rigidbody2D rb;

    private Animator anim;

    private Vector2 moveAmount;

    public Image[] hearts;

    public Sprite fullHeart;

    public Sprite emptyHeart;

    public Animator hurtAnim;

    public GameObject hurtSound;

    public GameObject trail;

    private float timeBtwTrail;

    public float startTimeBtwTrail;

    public Transform groundPos;

    private SceneTransitions sceneTransitions;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sceneTransitions = FindObjectOfType<SceneTransitions>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;

        if (moveInput != Vector2.zero)
        {
            if (timeBtwTrail <= 0)
            {
                Instantiate(trail, groundPos.position, Quaternion.identity);
                timeBtwTrail = startTimeBtwTrail;
            }
            else
            {
                timeBtwTrail -= Time.deltaTime;
            }

            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damageAmount)
    {
        Instantiate(hurtSound, transform.position, Quaternion.identity);

        health -= damageAmount;

        UpdateHealthUI(health);

        hurtAnim.SetTrigger("hurt");

        if (health <= 0)
        {
            Destroy(gameObject);
            sceneTransitions.LoadScene("Lose");
        }
    }

    public void ChangeWeapon(Weapon weaponToEquip)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(weaponToEquip, transform.position, transform.rotation, transform);
    }

    private void UpdateHealthUI(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    public void Heal(int healAmount)
    {
        if (health + healAmount > 5)
        {
            health = 5;
        }
        else
        {
            health += healAmount;
        }

        UpdateHealthUI(health);
    }
}
