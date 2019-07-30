using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject greenRangedEnemy;
    public GameObject orangeRangedEnemy;
    public GameObject redRangedEnemy;

    [Space]

    public GameObject greenMeleeEnemy;
    public GameObject orangeMeleeEnemy;
    public GameObject redMeleeEnemy;

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

    public void SetRangedEnemyStats()
    {
        ChooseRangedEnemy();

        damage = chosenEnemy.GetComponent<RangedEnemy>().bulletDamage;
        speed = chosenEnemy.GetComponent<RangedEnemy>().bulletSpeed;

        MessageManager.instance.SendMessageToChat("Ranged enemy spawned!", Message.Color.green);
    } 

    public void SetMeleeEnemyStats()
    {
        ChooseMeleeEnemy();

        damage = chosenEnemy.GetComponent<MeleeEnemy>().damage;

        MessageManager.instance.SendMessageToChat("Melee enemy spawned!", Message.Color.green);
    }  

    void ChooseRangedEnemy()
    {
        float num = Mathf.Round(Random.Range(0f, 100f));

        if (num >= 90)
        {
            chosenEnemy = redRangedEnemy;
        }
        else if (num >= 50 && num < 90)
        {
            chosenEnemy = orangeRangedEnemy;
        }
        else if (num < 50)
        {
            chosenEnemy = greenRangedEnemy;
        }
    }

    void ChooseMeleeEnemy()
    {
        float num = Mathf.Round(Random.Range(0f, 100f));

        if (num >= 90)
        {
            chosenEnemy = redMeleeEnemy;
        }
        else if (num >= 50 && num < 90)
        {
            chosenEnemy = orangeMeleeEnemy;
        }
        else if (num < 50)
        {
            chosenEnemy = greenMeleeEnemy;
        }
    }
}
