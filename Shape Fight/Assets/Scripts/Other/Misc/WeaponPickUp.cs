using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public enum Drop {pistol, rifle, shotgun, sniper};
    public Drop drop;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShooting player = other.GetComponent<PlayerShooting>();

            switch (drop)
            {
                case Drop.pistol:
                player.currentWeapon = PlayerShooting.Weapon.pistol;
                break;
                case Drop.rifle:
                player.currentWeapon = PlayerShooting.Weapon.rifle;
                break;
                case Drop.shotgun:
                player.currentWeapon = PlayerShooting.Weapon.shotgun;
                break;
                case Drop.sniper:
                player.currentWeapon = PlayerShooting.Weapon.sniper;
                break;
            }

            Destroy(gameObject);
        }
    }
}
