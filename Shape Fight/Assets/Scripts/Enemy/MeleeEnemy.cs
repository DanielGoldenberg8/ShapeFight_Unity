using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public float damage;
    public GameObject deathEffect;

    private float reloadTimer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            player.health -= damage;
            player.Hurt();

            Instantiate(deathEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
