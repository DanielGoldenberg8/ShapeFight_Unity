using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainEnemy : MonoBehaviour
{
    public ParticleSystem deathEffect;

    private Color color;
    public Color hurtColor;
    public Image healthBar;
    
    public float health;
    private float startHealth;

    public float minSize;
    public float maxSize;

    public int killScore;

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

        AudioManager.instance.Play("Enemy Death");

        AnimationManager.instance.ShakeAnim();

        Instantiate(deathEffect, transform.position, Quaternion.identity);

        Scoreboard.instance.AddScore(killScore);

        DropWeapon();

        Destroy(gameObject);
    }

    void DropWeapon()
    {
        WeaponDrops.instance.ChooseDrop();

        Instantiate(WeaponDrops.instance.chosenDrop, transform.position, transform.rotation);
    }
}
