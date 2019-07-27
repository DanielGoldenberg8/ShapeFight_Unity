using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public float damage;
    
    private float reloadTimer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            player.health -= damage;
            player.Hurt();

            Destroy(gameObject);
        }
    }
}
