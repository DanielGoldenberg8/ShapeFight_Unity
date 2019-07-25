using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject greenEnemy;
    public GameObject orangeEnemy;
    public GameObject redEnemy;

    private GameObject chosenEnemy;

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

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ChooseEnemy();

            damage = chosenEnemy.GetComponent<RangedEnemy>().bulletDamage;
            speed = chosenEnemy.GetComponent<RangedEnemy>().bulletSpeed;

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(chosenEnemy, mousePos, Quaternion.identity); 

            MessageManager.instance.SendMessageToChat("Enemy spawned!", Message.Color.green);
        }
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
