using UnityEngine;

[CreateAssetMenu(menuName = "New.../Bullet", fileName = "New Bullet")]
public class BulletType : ScriptableObject
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
