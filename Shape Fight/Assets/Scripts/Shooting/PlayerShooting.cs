using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform blastPoint1;
    public Transform blastPoint2;
    public Transform blastPoint3;

    public GameObject bullet;

    public BulletType pistol;
    public BulletType rifle;
    public BulletType shotgun;
    public BulletType sniper;
    public BulletType grenade;

    public enum Weapon {pistol, rifle, shotgun, sniper, grenadeLauncher};
    public Weapon currentWeapon;

    private float reloadSpeed;
    [HideInInspector] public float bulletSpeed;
    [HideInInspector] public float bulletDamage;
    [HideInInspector] public float bulletRecoil;
    [HideInInspector] public float bulletGravity;

    private float reloadTimer;

    void Update()
    {
        WeaponToggle();

        WeaponSelect();

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
    }

    void ShotgunShoot()
    {
        AudioManager.instance.Play("Shoot");

        Instantiate(bullet, blastPoint1.position, blastPoint1.rotation);
        Instantiate(bullet, blastPoint2.position, blastPoint2.rotation);
        Instantiate(bullet, blastPoint3.position, blastPoint3.rotation);
    }

    void WeaponSelect()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = Weapon.pistol;

            MessageManager.instance.SendMessageToChat("Pistol selected", Message.Color.blue);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = Weapon.rifle;

            MessageManager.instance.SendMessageToChat("Assault rifle selected", Message.Color.blue);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = Weapon.shotgun;

            MessageManager.instance.SendMessageToChat("Shotgun selected", Message.Color.blue);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentWeapon = Weapon.sniper;

            MessageManager.instance.SendMessageToChat("Sniper selected", Message.Color.blue);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentWeapon = Weapon.grenadeLauncher;

            MessageManager.instance.SendMessageToChat("SUPER GUN selected", Message.Color.yellow);
        }
    }

    void WeaponToggle()
    {
        if (currentWeapon == Weapon.pistol)
        {
            SetVariables(pistol.reloadSpeed, pistol.bulletSpeed, pistol.damage, pistol.recoil, pistol.gravity);
        }
        else if (currentWeapon == Weapon.rifle)
        {
            SetVariables(rifle.reloadSpeed, rifle.bulletSpeed, rifle.damage, rifle.recoil, rifle.gravity);
        }
        else if (currentWeapon == Weapon.shotgun)
        {
            SetVariables(shotgun.reloadSpeed, shotgun.bulletSpeed, shotgun.damage, shotgun.recoil, shotgun.gravity);
        }
        else if (currentWeapon == Weapon.sniper)
        {
            SetVariables(sniper.reloadSpeed, sniper.bulletSpeed, sniper.damage, sniper.recoil, sniper.gravity);
        }   
        else if (currentWeapon == Weapon.grenadeLauncher)
        {
            SetVariables(grenade.reloadSpeed, grenade.bulletSpeed, grenade.damage, grenade.recoil, grenade.gravity);
        }   
    }

    void SetVariables(float reload, float speed, float damage, float recoil, float gravity)
    {
        reloadSpeed = reload;
        bulletSpeed = speed;
        bulletDamage = damage;
        bulletRecoil = recoil;
        bulletGravity = gravity;
    }
}
