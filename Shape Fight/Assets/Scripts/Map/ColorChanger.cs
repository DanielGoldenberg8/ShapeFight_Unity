using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Experimental.Rendering.LWRP;

public class ColorChanger : MonoBehaviour
{
    public GameObject[] platforms;
    public Light2D[] lights;
    public Tilemap tilemap;

    [Space]

    public Color chosenColor;

    public static ColorChanger instance;

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

        ChooseColor();
    }

    void Start()
    {
        SetColor();
    }
    
    void ChooseColor()
    {
        int num = Mathf.FloorToInt(Random.Range(0f, 7f));

        if (num == 0)
        {
            chosenColor = Colors.instance.platformRed;
        }
        if (num == 1)
        {
            chosenColor = Colors.instance.platformOrange;
        }
        if (num == 2)
        {
            chosenColor = Colors.instance.platformYellow;
        }
        if (num == 3)
        {
            chosenColor = Colors.instance.platformGreen;
        }
        if (num == 4)
        {
            chosenColor = Colors.instance.platformBlue;
        }
        if (num == 5)
        {
            chosenColor = Colors.instance.platformPurple;
        }
        if (num == 6)
        {
            chosenColor = Colors.instance.platformPurple;
        }
    }

    void SetColor()
    {
        foreach (GameObject platform in platforms)
        {
            platform.GetComponent<SpriteRenderer>().color = chosenColor;
        }

        foreach (Light2D light in lights)
        {
            light.color = chosenColor;
        }

        tilemap.color = chosenColor;
    }
}
