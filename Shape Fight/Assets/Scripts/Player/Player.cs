using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
	public string playerName;

	public ParticleSystem deathEffect;
	private SpriteRenderer currentColor;

	public Color color;
	public Color hurtColor;
	public float startingHealth;
	[HideInInspector] public float health;

	public Image healthBar;
	public Color maxColor;
	public Color minColor;

	private GameObject spawnPoint;

	void Start()
    {
		spawnPoint = GameObject.FindGameObjectWithTag("Respawn");

		health = startingHealth;

		currentColor = GetComponent<SpriteRenderer>();
    }

	public void Update()
	{
		healthBar.fillAmount = health / startingHealth;
		healthBar.color = Color.Lerp(minColor, maxColor, healthBar.fillAmount);

		if (health <= 0)
		{
			Die();
		}
	}

	public void Hurt()
	{
		AudioManager.instance.Play("Player Hurt");

		StartCoroutine(HurtAnim());

		AnimationManager.instance.ShakeAnim();
	}

	public IEnumerator HurtAnim()
    {
        currentColor.color = hurtColor;
        yield return new WaitForSeconds(0.1f);
        currentColor.color = color;
    }

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);

		AnimationManager.instance.ShakeAnim();

		MessageManager.instance.SendMessageToChat(playerName + " died", Message.Color.red);

		gameObject.SetActive(false);

		health = startingHealth;
		
		Invoke("Respawn", 1f);
	}

	void Respawn()
	{
		transform.position = spawnPoint.transform.position;
		currentColor.color = color;
		gameObject.SetActive(true);
	}
}
