using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject greenEnemy;
    public GameObject orangeEnemy;
    public GameObject redEnemy;

    [HideInInspector] public GameObject chosenEnemy;

    [HideInInspector] public float damage;
    [HideInInspector] public float speed;

    public static EnemyManager instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void SetEnemyStats()
    {
        ChooseEnemy();

        damage = chosenEnemy.GetComponent<RangedEnemy>().bulletDamage;
        speed = chosenEnemy.GetComponent<RangedEnemy>().bulletSpeed;

        MessageManager.instance.SendMessageToChat("Enemy spawned!", Message.Color.green);
    }   

    void ChooseEnemy()
    {
        float num = Mathf.Round(Random.Range(0f, 100f));

        if (num >= 90)
        {
            chosenEnemy = redEnemy;
        }
        else if (num >= 50 && num < 90)
        {
            chosenEnemy = orangeEnemy;
        }
        else if (num < 50)
        {
            chosenEnemy = greenEnemy;
        }
    }
}
