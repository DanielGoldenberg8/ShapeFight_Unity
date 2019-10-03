using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform blastPoint1;
    public Transform blastPoint2;
    public Transform blastPoint3;

    public ParticleSystem bulletShot;

    public GameObject blaster;
    public GameObject bullet;

    public WeaponType pistol;
    public WeaponType rifle;
    public WeaponType shotgun;
    public WeaponType sniper;

    public enum Weapon {pistol, rifle, shotgun, sniper, supergun};
    public Weapon currentWeapon;

    private float reloadSpeed;
    
    [HideInInspector] public Sprite blasterSprite;
    [HideInInspector] public float bulletSpeed;
    [HideInInspector] public float bulletDamage;
    [HideInInspector] public float bulletRecoil;
    [HideInInspector] public float bulletGravity;
    [HideInInspector] public float blasterSizeX;
    [HideInInspector] public float blasterSizeY;

    private float reloadTimer;

    void Update()
    {
        WeaponToggle();

        SetBlasterSize();
        SetBlasterSprite();

        if (reloadTimer > 0)
        {
            reloadTimer -= Time.deltaTime;
        }
        else if (reloadTimer < 0)
        {
            reloadTimer = 0;
        }

        if (Input.GetMouseButton(0) && (reloadTimer == 0))
        {
            reloadTimer = reloadSpeed;

            if (currentWeapon != Weapon.shotgun)
            {
                StandardShoot();
            }
            else if (currentWeapon == Weapon.shotgun)
            {
                ShotgunShoot();
            }
        }
    }

    void StandardShoot()
    {
        AudioManager.instance.Play("Shoot");

        Instantiate(bullet, blastPoint1.position, blastPoint1.rotation);
        
        Instantiate(bulletShot, blastPoint1.position, blastPoint1.rotation);
    }

    void ShotgunShoot()
    {
        AudioManager.instance.Play("Shoot");

        Instantiate(bullet, blastPoint1.position, blastPoint1.rotation);
        Instantiate(bullet, blastPoint2.position, blastPoint2.rotation);
        Instantiate(bullet, blastPoint3.position, blastPoint3.rotation);

        Instantiate(bulletShot, blastPoint1.position, blastPoint1.rotation);
    }

    void WeaponToggle()
    {
        if (currentWeapon == Weapon.pistol)
        {
            SetVariables(pistol.sprite, pistol.reloadSpeed, pistol.bulletSpeed, pistol.damage, pistol.recoil, pistol.gravity, 
                pistol.sizeX, pistol.sizeY);
        }
        else if (currentWeapon == Weapon.rifle)
        {
            SetVariables(rifle.sprite, rifle.reloadSpeed, rifle.bulletSpeed, rifle.damage, rifle.recoil, rifle.gravity, 
                rifle.sizeX, rifle.sizeY);
        }
        else if (currentWeapon == Weapon.shotgun)
        {
            SetVariables(shotgun.sprite, shotgun.reloadSpeed, shotgun.bulletSpeed, shotgun.damage, shotgun.recoil, shotgun.gravity, 
                shotgun.sizeX, shotgun.sizeY);
        }
        else if (currentWeapon == Weapon.sniper)
        {
            SetVariables(sniper.sprite, sniper.reloadSpeed, sniper.bulletSpeed, sniper.damage, sniper.recoil, sniper.gravity,
                sniper.sizeX, sniper.sizeY);
        }    
    }

    void SetVariables(Sprite sprite, float reload, float speed, float damage, float recoil, float gravity, float sizeX, float sizeY)
    {
        blasterSprite = sprite;
        reloadSpeed = reload;
        bulletSpeed = speed;
        bulletDamage = damage;
        bulletRecoil = recoil;
        bulletGravity = gravity;

        blasterSizeX = sizeX;
        blasterSizeY = sizeY;
    }

    void SetBlasterSize()
    {
        blaster.transform.localScale = new Vector2(blasterSizeX, blasterSizeY);
    }

    void SetBlasterSprite()
    {
        blaster.GetComponent<SpriteRenderer>().sprite = blasterSprite;
    }
}
