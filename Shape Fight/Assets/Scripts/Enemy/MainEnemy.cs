using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainEnemy : MonoBehaviour
{
    public ParticleSystem deathEffect;

    private Color color;
    public Color hurtColor;
    public Image healthBar;

    public float minSize;
    public float maxSize;
    
    public float health;
    private float startHealth;

    void Start()
    {
        color = GetComponent<SpriteRenderer>().color;

        SetSizeAndHealth();
    }

    void Update()
    {
        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    void SetSizeAndHealth()
    {
        float sizeMuliplier = Random.Range(minSize, maxSize);

        transform.localScale = new Vector2(1f * sizeMuliplier, 1f * sizeMuliplier);

        float healthMultiplier = sizeMuliplier;

        health *= healthMultiplier;
        health = Mathf.Floor(health);

        startHealth = health;
    }

    public void Hurt()
    {
        AudioManager.instance.Play("Player Hurt");
        
        StartCoroutine(HurtAnim());
    }

    IEnumerator HurtAnim()
    {
        SpriteRenderer currentColor = GetComponent<SpriteRenderer>();

        currentColor.color = hurtColor;
        yield return new WaitForSeconds(0.1f);
        currentColor.color = color;
    }

    void Die()
    {
        AnimationManager.instance.ShakeAnim();

        Instantiate(deathEffect, transform.position, Quaternion.identity);

        AudioManager.instance.Play("Enemy Death");

        Destroy(gameObject);
    }
}
