using UnityEngine;

public class WeaponDrops : MonoBehaviour
{
    public GameObject pistol;
    public GameObject rifle;
    public GameObject shotgun;
    public GameObject sniper;

    [HideInInspector] public GameObject chosenWeapon; 

    public static WeaponDrops instance;

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

    public void ChooseDrop()
    {
        int num = Mathf.RoundToInt(Random.Range(0f, 3f));

        if (num == 0)
        {
            chosenWeapon = pistol;
        }
        else if (num == 1)
        {
            chosenWeapon = rifle;
        }
        else if (num == 2)
        {
            chosenWeapon = shotgun;
        }
        else if (num == 3)
        {
            chosenWeapon = sniper;
        }
    }
}
