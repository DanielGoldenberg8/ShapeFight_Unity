using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public GameObject bullet;
    public Transform blaster;
    public Transform blastPoint;

    [Space]

    public float rotSpeed; 
    public float reloadSpeed;
    public float bulletSpeed;
    public float bulletDamage;
    
    private float reloadTimer;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        RotateBlaster();

        if (reloadTimer > 0)
        {
            reloadTimer -= Time.deltaTime;
        }
        else if (reloadTimer < 0)
        {
            reloadTimer = 0;
        }

        if (reloadTimer == 0)
        {
            reloadTimer = reloadSpeed;
            Shoot();
        }
    
    }

    void RotateBlaster()
    {
        if (player.GetComponent<Player>().isDead == false)
        {
            Vector2 dir = player.transform.position - blaster.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);

            blaster.rotation = Quaternion.Slerp(blaster.rotation, rot, rotSpeed * Time.deltaTime);
        }
    }

    void Shoot()
    {
        AudioManager.instance.Play("Shoot");

        Instantiate(bullet, blastPoint.position, blaster.rotation);
    }
}
