using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public ParticleSystem bulletDeath;

    private float speed;
    private float damage;

    private Rigidbody2D rb;

    void Start()
    {
        damage = EnemyManager.instance.damage;
        speed = EnemyManager.instance.speed;

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            player.health -= damage;
            player.Hurt();
        
            Destroy();
        }

        if (other.CompareTag("Ground"))
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        Instantiate(bulletDeath, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
