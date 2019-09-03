using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
	public string playerName;

	private Color color = Color.black;
	private Color hurtColor = Color.white;
	public float startingHealth;

	public ParticleSystem deathEffect;
	private SpriteRenderer currentColor;

	[HideInInspector] public float health;
	[HideInInspector] public bool isDead = false;

	public Image healthBar;
	public Color maxColor;
	public Color minColor;

	private GameObject spawnPoint;

	void Awake()
	{
		if (playerName == "")
		{
			playerName = "Player";
		}
	}

	void Start()
    {
		spawnPoint = GameObject.FindGameObjectWithTag("Respawn");

		health = startingHealth;

		currentColor = GetComponent<SpriteRenderer>();

		float num = Mathf.CeilToInt(Random.Range(0f, 3f));

		if (num == 1)
        {
            AudioManager.instance.Play("Theme1");
        }
        else if (num == 2)
        {
            AudioManager.instance.Play("Theme2");
        }
        else if (num == 3)
        {
            AudioManager.instance.Play("Theme3");
        }
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
		isDead = true;

		Instantiate(deathEffect, transform.position, Quaternion.identity);

		AnimationManager.instance.ShakeAnim();

		MessageManager.instance.SendMessageToChat(playerName + " died", Message.Color.red);

		gameObject.SetActive(false);

		health = startingHealth;
		
		Invoke("Respawn", 1f);
	}

	void Respawn()
	{
		isDead = false;

		Scoreboard.instance.totalScore = 0;

		transform.position = spawnPoint.transform.position;

		currentColor.color = color;

		gameObject.SetActive(true);
	}
}
