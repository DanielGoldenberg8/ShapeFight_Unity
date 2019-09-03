using UnityEngine;

[CreateAssetMenu(menuName = "New.../Weapon", fileName = "New Weapon")]
public class WeaponType : ScriptableObject
{
    public float damage;
    public float reloadSpeed;
    public float bulletSpeed;
    public float recoil;
    public float gravity;

    [Space]

    public float sizeX;
    public float sizeY;
}
