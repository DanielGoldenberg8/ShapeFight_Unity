using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour
{
    public ParticleSystem bulletDeath;

    private float speed;
    private float damage;
    private float gravity;

    private Rigidbody2D rb;
    private PlayerShooting player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();

        SetVariables();
        StartCoroutine(Deploy());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            enemy.health -= damage;
            enemy.Hurt();

            Destroy();
        }

        if (other.CompareTag("Ground"))
        {
            Destroy();
        }
    }

    void Destroy()
    {
        Instantiate(bulletDeath, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    void SetVariables()
    {
        speed = player.bulletSpeed;
        damage = player.bulletDamage;
        gravity = player.bulletGravity;
    }

    IEnumerator Deploy()
    {
        rb.velocity = transform.right * speed;

        yield return new WaitForSeconds(0.25f);

        rb.gravityScale = gravity;
    }
}
