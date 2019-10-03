using UnityEngine;

public class WeaponDrops : MonoBehaviour
{
    public GameObject rifle;
    public GameObject shotgun;
    public GameObject sniper;
    public GameObject nothing;

    [HideInInspector] public GameObject chosenDrop; 

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
        int num = Mathf.CeilToInt(Random.Range(0f, 100f));

        if (num <= 25)
        {
            int weapon = Mathf.CeilToInt(Random.Range(0f, 4f));

            if (weapon == 1)
            {
                chosenDrop = rifle;
            }
            if (weapon == 2)
            {
                chosenDrop = shotgun;
            }
            if (weapon == 3)
            {
                chosenDrop = sniper;
            }
        }
        else
        {
            chosenDrop = nothing;
        }
    }
}
